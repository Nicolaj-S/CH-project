using CH_project_backend;
using Microsoft.EntityFrameworkCore;

namespace CH_project_backend.Environment
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}
