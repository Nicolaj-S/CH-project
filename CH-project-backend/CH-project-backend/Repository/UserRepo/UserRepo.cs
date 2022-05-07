using CH_project_backend.Domain;
using CH_project_backend.Environment;
using Microsoft.EntityFrameworkCore;

namespace CH_project_backend.Repository.UserRepo
{
    public class UserRepo : IUserRepo
    {
        private readonly DatabaseContext context;

        public UserRepo(DatabaseContext _context)
        {
            context = _context;
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
            return await context.User.Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        public User Login(User authUser)
        {
            //Getting the users credentials to find if password is encrypted
            var user = context.User.SingleOrDefault(x => x.Username == authUser.Username);
            //if its not encrypt data and change the password in our database
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(authUser.Password, user.Password);
            //If password is encrypted and the user is trying to login decrypt the password and encrypt after login
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

        public async Task<bool> UserExistsByEmail(string email)
        {
            return await context.User.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> UserExistsByID(int id)
        {
            return await context.User.AnyAsync(u => u.Id == id);
        }

        public async Task<bool> UserExistsByUsername(string username)
        {
            return await context.User.AnyAsync(u => u.Username == username);
        }
    }
}
