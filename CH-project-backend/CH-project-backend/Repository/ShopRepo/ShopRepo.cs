using CH_project_backend.Domain;
using CH_project_backend.Environment;
using Microsoft.EntityFrameworkCore;

namespace CH_project_backend.Repository.ShopRepo
{
    public class ShopRepo : IShopRepo
    {
        private readonly DatabaseContext context;

        public ShopRepo(DatabaseContext _context)
        {
            context = _context;
        }

        public async Task<bool> CreateShop (Shop shop)
        {
            await context.AddAsync(shop);
            return await Save();
        }
    }
}
