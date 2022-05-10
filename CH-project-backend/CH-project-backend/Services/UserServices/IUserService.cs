using CH_project_backend.Domain;

namespace CH_project_backend.Services.UserServices
{
    public interface IUserService
    {
        Task<ICollection<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsername(string username);

        //Task<bool> UserExistsByUsername(string username);
        //Task<bool> UserExistsByID(int id);
        //Task<bool> UserExistsByEmail(string email);

        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);
    }
}
