using CH_project_backend.Domain;
using CH_project_backend.Repository.BlogRepo;

namespace CH_project_backend.Services.BolgServices
{
    public class BlogService
    {
        private readonly IBlogRepo Repo;

        public BlogService(IBlogRepo _Repo)
        {
            Repo = _Repo;
        }

        public async Task<ICollection<Blog>> GetAllBlogs() => await Repo.GetAllBlogs();
        public async Task<Blog> GetBlogById(int id) => await Repo.GetBlogById(id);

        public async Task<bool> CreateBlog(Blog blog) => await Repo.CreateBlog(blog);
        public async Task<bool> UpdateBlog(Blog blog) => await Repo.UpdateBlog(blog);
        public async Task<bool> DeleteBlog(Blog blog) => await Repo.DeleteBlog(blog);

        
    }
}
