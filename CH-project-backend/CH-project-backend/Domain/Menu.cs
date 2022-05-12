using System.ComponentModel.DataAnnotations;

namespace CH_project_backend.Domain
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
