using CH_project_backend.Auth;
using CH_project_backend.Domain;
using CH_project_backend.Environment;
using CH_project_backend.Helpers;
using CH_project_backend.Model.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CH_project_backend.Repository.UserRepo
{
    public class UserRepo : IUserRepo
    {
        private DatabaseContext context;
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

        public async Task<bool> UpdateUser(User user)
        {
            context.Update(user);
            return await Save();
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await context.User.ToListAsync();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await context.User.Where(u => u.UserName == username).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await context.User.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress)
        {
            var user = context.User.SingleOrDefault(x => x.UserName == model.UserName);

            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                throw new Exception("Username or password is incorrect");
            }

            var jwtToken = jwtUtils.GenerateJwtToken(user);
            var refreshToken = jwtUtils.GenerateRefreshToken(ipAddress);
            user.RefreshTokens.Add(refreshToken);

            removeOldRefreshTokens(user);

            context.Update(user);
            context.SaveChanges();

            return new AuthenticateResponse(user, jwtToken, refreshToken.Token);
        }

        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            var user = GetUserByRefreshToken(token);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            if (refreshToken.IsRevoked)
            {
                revokeDescendantRefreshTokens(refreshToken, user, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
                context.Update(user);
                context.SaveChanges();
            }

            if (!refreshToken.IsActive)
            {
                throw new AppException("Invalid token");
            }

            var newRefreshToken = rotateRefreshToken(refreshToken, ipAddress);
            user.RefreshTokens.Add(newRefreshToken);

            removeOldRefreshTokens(user);

            context.Update(user);
            context.SaveChanges();

            var JwtToken = jwtUtils.GenerateJwtToken(user);
            return new AuthenticateResponse(user, JwtToken, refreshToken.Token);
        }

        public void RevokeToken(string token, string ipAddress)
        {
            var user = GetUserByRefreshToken(token);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            if (!refreshToken.IsActive)
            {
                throw new AppException("invalid token");
            }

            revokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");
            context.Update(user);
            context.SaveChanges();
        }

        private User GetUserByRefreshToken(string token)
        {
            var user = context.User.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
            if (user == null)
            {
                throw new Exception("Invalid token");
            }
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
            user.RefreshTokens.RemoveAll(x => !x.IsActive && x.Created.AddDays(appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        }


        public void revokeDescendantRefreshTokens(RefreshToken refreshToken, User user, string ipAddress, string reason)
        {

            if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            {
                var childToken = user.RefreshTokens.Single(x => x.Token == refreshToken.ReplacedByToken);
                if (childToken.IsActive)
                {
                    revokeRefreshToken(childToken, ipAddress, reason);
                }
                else
                {
                    revokeDescendantRefreshTokens(childToken, user, ipAddress, reason);
                }
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
