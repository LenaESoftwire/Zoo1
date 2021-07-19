using Microsoft.EntityFrameworkCore;
using Zoo.DBModels;

namespace Zoo
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Keeper> Keepers { get; set; }
        
    }
}