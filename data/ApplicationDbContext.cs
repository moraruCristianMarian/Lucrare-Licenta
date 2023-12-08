using Microsoft.EntityFrameworkCore;

namespace data
{
    public class ApplicationDbContext : DbContext
    {   
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
