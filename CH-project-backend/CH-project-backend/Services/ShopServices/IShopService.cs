using CH_project_backend.Domain;

namespace CH_project_backend.Services.ShopServices
{
    public interface IShopService
    {
        Task<ICollection<Shop>> GetAllShops();
        Task<Shop> GetShopById(int id);
        Task<Shop> 
    }
}
