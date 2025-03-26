using Microsoft.EntityFrameworkCore;

namespace SignalRHub.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
    }
}
