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
        public bool Admin { get; set; }
        public string Password { get; set; }
        public List<int> BlogId { get; set; }
        public List<int> RecipeId { get; set; }

        public static Expression<Func<User, UserDTO>> UserDetails => User => new()
        {
            UserName = User.UserName,
            FirstName = User.FirstName,
            LastName = User.LastName,
            Email = User.Email,
            Admin = User.Admin,
            Password = User.Password,
            BlogId = User.Blogs.Select(x => x.Id).ToList(),
            RecipeId = User.Recipes.Select(x => x.Id).ToList(),
        };
    }
}
