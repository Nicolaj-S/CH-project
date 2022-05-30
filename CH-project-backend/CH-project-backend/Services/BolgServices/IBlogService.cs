using CH_project_backend.Domain;

namespace CH_project_backend.Services.BolgServices
{
    public interface IBlogService
    {
        Task<ICollection<Blog>> GetAllBlogs();
        Task<Blog> GetBlogById(int id);

        Task<bool> CreateBlog(Blog blog);
        Task<bool> UpdateBlog(Blog blog);
        Task<bool> DeleteBlog(Blog blog);
    }
}
