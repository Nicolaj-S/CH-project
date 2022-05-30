using CH_project_backend.Domain;
using CH_project_backend.Environment;
using CH_project_backend.Repository.MenuRepo;
using Microsoft.EntityFrameworkCore;

namespace CH_project_backend.Repository.MenuRepo
{
    public class MenuRepo : IMenuRepo
    {
        private readonly DatabaseContext context;

        public MenuRepo(DatabaseContext _context)
        {
            context = _context;
        }

        public async Task<bool> CreateMenu(Menu menu)
        {
            await context.AddAsync(menu);
            return await Save();
        }

        public async Task<bool> DeleteMenu(Menu menu)
        {
            context.Remove(menu);
            return await Save();
        }

        public async Task<bool> UpdateMenu(Menu menu)
        {
            context.Update(menu);
            return await Save();
        }

        public async Task<ICollection<Menu>> GetAllMenus()
        {
            return await context.Menu.ToListAsync();
        }

        public async Task<Menu> GetMenuByName(string ItemName)
        {
            return await context.Menu.Where(u => u.ItemName == ItemName).FirstOrDefaultAsync();
        }

        public async Task<Menu> GetMenuById(int id)
        {
            return await context.Menu.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
