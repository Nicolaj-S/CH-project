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

        public async Task<bool> CreateMenu (Menu menu)
        {
            await context.AddAsync(menu);
            return await Save();
        }
    }
}
