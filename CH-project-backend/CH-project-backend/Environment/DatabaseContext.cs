using CH_project_backend;
using CH_project_backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace CH_project_backend.Environment
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
    }
}
