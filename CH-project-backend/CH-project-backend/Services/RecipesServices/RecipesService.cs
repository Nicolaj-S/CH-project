using CH_project_backend.Domain;
using CH_project_backend.Repository.RecipiesRepo;

namespace CH_project_backend.Services.RecipesServices
{
    public class RecipesService
    {
        private readonly IRecipesRepo Repo;


        public RecipesService(IRecipesRepo _Repo)
        {
            Repo = _Repo;
        }

        public async Task<ICollection<Recipes>> GetAllRecipes() => await Repo.GetAllRecipes();
        public async Task<Recipes> GetRecipesById(int id) => await Repo.GetRecipesById(id);

        public async Task<bool> CreateRecipes(Recipes recipes) => await Repo.CreateRecipes(recipes);
        public async Task<bool> UpdateRecipes(Recipes recipes) => await Repo.UpdateRecipes(recipes);
        public async Task<bool> DeleteRecipes(Recipes recipes) => await Repo.DeleteRecipes(recipes);
    }
}
