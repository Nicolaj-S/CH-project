using CH_project_backend.Domain;

namespace CH_project_backend.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserService userRepo;

        public UserService(IUserService _userRepo)
        {
            userRepo = _userRepo;
        }

        public async Task<ICollection<User>> GetAllUsers() => await userRepo.GetAllUsers();
        public async Task<User> GetUserById(int id) => await userRepo.GetUserById(id);
        public async Task<User> GetUserByUsername(string username) => await userRepo.GetUserByUsername(username);

        //public async Task<bool> UserExistsByUsername(string username) => await userRepo.UserExistsByUsername(username);
        //public async Task<bool> UserExistsByID(int id) => await userRepo.UserExistsByID(id);
        //public async Task<bool> UserExistsByEmail(string email) => await userRepo.UserExistsByEmail(email);

        public async Task<bool> CreateUser(User user) => await userRepo.CreateUser(user);
        public async Task<bool> UpdateUser(User user) => await userRepo.UpdateUser(user);
        public async Task<bool> DeleteUser(User user) => await userRepo.DeleteUser(user);
    }
}
