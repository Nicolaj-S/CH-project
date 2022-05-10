using System.ComponentModel.DataAnnotations;

namespace CH_project_backend.Domain
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Header { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
        public List <User> Users { get; set;}
    }
}
