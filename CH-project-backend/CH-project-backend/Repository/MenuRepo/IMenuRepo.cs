using CH_project_backend.Domain;

namespace CH_project_backend.Repository.MenuRepo
{
    public interface IMenuRepo
    {
        Task<ICollection<Menu>> GetAllMenus();
        Task<Menu> GetMenuById(int id);
        Task<Menu> GetMenuByName(string ItemName);

        Task<bool> CreateMenu(Menu menu);
        Task<bool> UpdateMenu(Menu menu);
        Task<bool> DeleteMenu(Menu menu);
    }
}
