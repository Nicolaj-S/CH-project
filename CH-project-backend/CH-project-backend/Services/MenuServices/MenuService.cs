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

        public Task<ICollection<Menu>> GetAllMenus()
        {
            throw new NotImplementedException();
        }

        public Task<Menu> GetMenuById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
