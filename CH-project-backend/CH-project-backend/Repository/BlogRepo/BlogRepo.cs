using CH_project_backend.Domain;
using CH_project_backend.Environment;
using Microsoft.EntityFrameworkCore;

namespace CH_project_backend.Repository.BlogRepo
{
    public class BlogRepo : IBlogRepo
    {
        private DatabaseContext context;

        public BlogRepo(DatabaseContext _context)
        {
            context = _context;
        }

        public async Task<bool> CreateBlog(Blog blog)
        {
            await context.AddAsync(blog);
            return await Save();
        }

        public async Task<bool> DeleteBlog(Blog blog)
        {
            context.Remove(blog);
            return await Save();
        }

        public async Task<bool> UpdateBlog(Blog blog)
        {
            context.Update(blog);
            return await Save();
        }

        public async Task<ICollection<Blog>> GetAllBlogs()
        {
            return await context.Blog.ToListAsync();
        }

        public async Task<Blog> GetBlogById(int id)
        {
            return await context.Blog.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
