using CH_project_backend.Domain;
using System.Linq.Expressions;

namespace CH_project_backend.DTO
{
    public class RecipesDTO
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<int> Users { get; set; }

        public static Expression<Func<Recipes, RecipesDTO>> RecipesDetails => Recipes => new()
        {
            Title = Recipes.Title,
            Image = Recipes.Image,
            Description = Recipes.Description,
            Users = Recipes.Users.Select(x => x.Id).ToList(),
        };
    }
}
