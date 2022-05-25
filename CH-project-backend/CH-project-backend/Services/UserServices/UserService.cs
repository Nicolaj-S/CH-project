using CH_project_backend.Domain;
using CH_project_backend.Model.Users;
using CH_project_backend.Repository.UserRepo;

namespace CH_project_backend.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepo Repo;

        public UserService(IUserRepo _Repo)
        {
            Repo = _Repo;
        }
        public async Task<ICollection<User>> GetAllUsers() => await Repo.GetAllUsers();
        public async Task<User> GetUserById(int id) => await Repo.GetUserById(id);
        public async Task<User> GetUserByUsername(string username) => await Repo.GetUserByUsername(username);

        public async Task<bool> CreateUser(User user) => await Repo.CreateUser(user);
        public async Task<bool> UpdateUser(User user) => await Repo.UpdateUser(user);
        public async Task<bool> DeleteUser(User user) => await Repo.DeleteUser(user);

        //jwtToken
        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress) => Repo.Authenticate(model, ipAddress);
        public AuthenticateResponse RefreshToken(string token, string ipAddress) => Repo.RefreshToken(token, ipAddress);
        public void RevokeToken(string token, string ipAddress) => Repo.RevokeToken(token, ipAddress);
    }
}
