using CH_project_backend.Domain;
using CH_project_backend.Repository.MenuRepo;

namespace CH_project_backend.Services.MenuServices
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepo Repo;

        public MenuService(IMenuRepo _Repo)
        {
            Repo = _Repo;
        }

        public async Task<ICollection<Menu>> GetAllMenus() => await Repo.GetAllMenus();
        public async Task<Menu> GetMenuById(int id) => await Repo.GetMenuById(id);
        public async Task<Menu> GetMenuByName(string ItemName) => await Repo.GetMenuByName(ItemName);

        public async Task<bool> CreateMenu(Menu menu) => await Repo.CreateMenu(menu);
        public async Task<bool> UpdateMenu(Menu menu) => await Repo.UpdateMenu(menu);
        public async Task<bool> DeleteMenu(Menu menu) => await Repo.DeleteMenu(menu);

    }
}
