using CH_project_backend.Domain;
using CH_project_backend.Environment;
using Microsoft.EntityFrameworkCore;

namespace CH_project_backend.Repository.RecipiesRepo
{
    public class RecipesRepo : IRecipesRepo
    {
        private DatabaseContext context;

        public RecipesRepo(DatabaseContext _context)
        {
            context = _context;
        }

        public async Task<bool> CreateRecipes(Recipes recipes)
        {
            await context.AddAsync(recipes);
            return await Save();
        }

        public async Task<bool> DeleteRecipes(Recipes recipes)
        {
            context.Remove(recipes);
            return await Save();
        }

        public async Task<bool> UpdateRecipes(Recipes recipes)
        {
            context.Update(recipes);
            return await Save();
        }

        public async Task<ICollection<Recipes>> GetAllRecipes()
        {
            return await context.Recipes.ToListAsync();
        }

        public async Task<Recipes> GetRecipesById(int id)
        {
            return await context.Recipes.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
