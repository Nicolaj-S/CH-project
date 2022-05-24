using CH_project_backend.Domain;
using CH_project_backend.Model.Users;
using CH_project_backend.Repository.UserRepo;

namespace CH_project_backend.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo;

        public UserService(IUserRepo _userRepo)
        {
            userRepo = _userRepo;
        }

        public async Task<ICollection<User>> GetAllUsers() => await userRepo.GetAllUsers();
        public async Task<User> GetUserById(int id) => await userRepo.GetUserById(id);
        public async Task<User> GetUserByUsername(string username) => await userRepo.GetUserByUsername(username);
        

        public async Task<bool> CreateUser(User user) => await userRepo.CreateUser(user);
        public async Task<bool> UpdateUser(User user) => await userRepo.UpdateUser(user);
        public async Task<bool> DeleteUser(User user) => await userRepo.DeleteUser(user);

        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress) => userRepo.Authenticate(model, ipAddress);
        public AuthenticateResponse RefreshToken(string token, string ipAddress) => userRepo.RefreshToken(token, ipAddress);
        public void RevokeToken(string token, string ipAddress) => userRepo.RevokeToken(token, ipAddress);
    }
}
