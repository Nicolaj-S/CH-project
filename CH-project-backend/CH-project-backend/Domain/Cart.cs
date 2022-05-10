using System.ComponentModel.DataAnnotations;

namespace CH_project_backend.Domain
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public List <User> Users { get; set; }
        public ICollection<Shop> Shop { get; set; }
    }
}
