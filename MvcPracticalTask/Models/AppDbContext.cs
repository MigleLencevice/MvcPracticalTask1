using Microsoft.EntityFrameworkCore;

namespace MvcPracticalTask.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Film> Films { get; set; }
    }
}