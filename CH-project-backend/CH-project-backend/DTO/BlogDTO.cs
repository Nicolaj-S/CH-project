using CH_project_backend.Domain;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CH_project_backend.DTO
{
    public class BlogDTO
    {
        public string Header { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public List<int> Users { get; set; }

        public static Expression<Func<Blog, BlogDTO>> BlogDetails => Blog => new()
        {
            Header = Blog.Header,
            Date = Blog.Date,
            Description = Blog.Description,
            Users = Blog.Users.Select(x => x.Id).ToList(),
        };
    }
}
