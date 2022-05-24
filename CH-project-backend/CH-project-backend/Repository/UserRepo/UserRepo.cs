using CH_project_backend.Auth;
using CH_project_backend.Domain;
using CH_project_backend.Environment;
using CH_project_backend.Helpers;
using CH_project_backend.Model.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CH_project_backend.Repository.UserRepo
{
    public class UserRepo : IUserRepo
    {
        private readonly DatabaseContext context;
        private IJwtUtils jwtUtils;
        private readonly AppSettings appSettings;

        public UserRepo(DatabaseContext _context, IJwtUtils _jwtUtils, IOptions<AppSettings> _appSettings)
        {
            context = _context;
            jwtUtils = _jwtUtils;
            appSettings = _appSettings.Value;
        }
        public async Task<bool> CreateUser(User user)
        {
            await context.AddAsync(user);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return await Save();
        }

        public async Task<bool> DeleteUser(User user)
        {
            context.Remove(user);
            return await Save();
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await context.User.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await context.User.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await context.User.Where(u => u.UserName == username).FirstOrDefaultAsync();
        }

        public User Login(User authUser)
        {
            //Getting the users credentials to find if password is encrypted
            var user = context.User.SingleOrDefault(x => x.UserName == authUser.UserName);
            //if its not encrypt data and change the password in our database
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(authUser.Password, user.Password);
            //If password is encrypted and the user is trying to login decrypt the password
            if (isValidPassword)
            {
                return user;
            }
            return null;
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateUser(User user)
        {
            context.Update(user);
            return await Save();
        }










        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress)
        {
            var user = context.User.SingleOrDefault(x => x.UserName == model.Username);

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                throw new AppException("Username or password is incorrect");

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = jwtUtils.GenerateJwtToken(user);
            var refreshToken = jwtUtils.GenerateRefreshToken(ipAddress);
            user.RefreshTokens.Add(refreshToken);

            // remove old refresh tokens from user
            removeOldRefreshTokens(user);

            // save changes to db
            context.Update(user);
            context.SaveChanges();

            return new AuthenticateResponse(user, jwtToken, refreshToken.Token);
        }

        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            var user = getUserByRefreshToken(token);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            if (refreshToken.IsRevoked)
            {
                // revoke all descendant tokens in case this token has been compromised
                revokeDescendantRefreshTokens(refreshToken, user, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
                context.Update(user);
                context.SaveChanges();
            }

            if (!refreshToken.IsActive)
                throw new AppException("Invalid token");

            // replace old refresh token with a new one (rotate token)
            var newRefreshToken = rotateRefreshToken(refreshToken, ipAddress);
            user.RefreshTokens.Add(newRefreshToken);

            // remove old refresh tokens from user
            removeOldRefreshTokens(user);

            // save changes to db
            context.Update(user);
            context.SaveChanges();

            // generate new jwt
            var jwtToken = jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken, newRefreshToken.Token);
        }

        public void RevokeToken(string token, string ipAddress)
        {
            var user = getUserByRefreshToken(token);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            if (!refreshToken.IsActive)
                throw new AppException("Invalid token");

            // revoke token and save
            revokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");
            context.Update(user);
            context.SaveChanges();
        }

        private User getUserByRefreshToken(string token)
        {
            var user = context.User.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
                throw new AppException("Invalid token");

            return user;
        }

        private RefreshToken rotateRefreshToken(RefreshToken refreshToken, string ipAddress)
        {
            var newRefreshToken = jwtUtils.GenerateRefreshToken(ipAddress);
            revokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return newRefreshToken;
        }

        private void removeOldRefreshTokens(User user)
        {
            // remove old inactive refresh tokens from user based on TTL in app settings
            user.RefreshTokens.RemoveAll(x =>
                !x.IsActive &&
                x.Created.AddDays(appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        }

        private void revokeDescendantRefreshTokens(RefreshToken refreshToken, User user, string ipAddress, string reason)
        {
            // recursively traverse the refresh token chain and ensure all descendants are revoked
            if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            {
                var childToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);
                if (childToken.IsActive)
                    revokeRefreshToken(childToken, ipAddress, reason);
                else
                    revokeDescendantRefreshTokens(childToken, user, ipAddress, reason);
            }
        }

        private void revokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
        }

    }
}
