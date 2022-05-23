using CH_project_backend.Domain;
using System.Linq.Expressions;

namespace CH_project_backend.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<int> Blogs { get; set; }
        public List<int> Recipes { get; set; }

        public static Expression<Func<User, UserDTO>> UserDetails => User => new()
        {
            UserName = User.UserName,
            FirstName = User.FirstName,
            LastName = User.LastName,
            Email = User.Email,
            Password = User.Password,
            Blogs = User.Blogs.Select(x => x.Id).ToList(),
            Recipes = User.Recipes.Select(x => x.Id).ToList(),
        };
    }
}
