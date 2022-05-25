using CH_project_backend.Repository.RecipiesRepo;

namespace CH_project_backend.Services.RecipesServices
{
    public class RecipesService
    {
        private readonly IRecipesRepo userRepo;

        public RecipesService(IRecipesRepo _userRepo)
        {
            userRepo = _userRepo;
        }
    }
}
