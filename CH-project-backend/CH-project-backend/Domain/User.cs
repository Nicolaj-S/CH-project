using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CH_project_backend.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public string Fullname { get { return FirstName + " " + LastName; } }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 8, ErrorMessage = "The passwords length must be 8 characters long")]
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public bool Admin { get; set; }

        public List <Cart> Items { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Recipes> Recipes { get; set; }
    }
}
