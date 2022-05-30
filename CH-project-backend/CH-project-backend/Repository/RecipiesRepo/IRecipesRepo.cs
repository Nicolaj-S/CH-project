using CH_project_backend.Domain;

namespace CH_project_backend.Repository.RecipiesRepo
{
    public interface IRecipesRepo
    {
        Task<ICollection<Recipes>> GetAllRecipes();
        Task<Recipes> GetRecipesById(int id);

        Task<bool> CreateRecipes(Recipes recipes);
        Task<bool> UpdateRecipes(Recipes recipes);
        Task<bool> DeleteRecipes(Recipes recipes);
    }
}
