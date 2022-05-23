using CH_project_backend.Domain;
using System.Linq.Expressions;

namespace CH_project_backend.DTO
{
    public class MenuDTO
    {
        public string ItemName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public static Expression<Func<Menu, MenuDTO>> MenuDetatils => Menu => new()
        {
            ItemName = Menu.ItemName,
            Image = Menu.Image,
            Description = Menu.Description,
        };
    }
}
