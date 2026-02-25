using Microsoft.EntityFrameworkCore;

namespace UniEdu.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Student> Students { get; set; }
    }
}
