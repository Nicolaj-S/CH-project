using CH_project_backend.Domain;

namespace CH_project_backend.Services.MenuServices
{
    public interface IMenuService
    {
        Task<ICollection<Menu>> GetAllMenus();
        Task<Menu> GetMenuById(int id);
        Task<Menu> 
    }
}
