using Microsoft.EntityFrameworkCore;

namespace MusicAwardsWebApp.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<AwardCategory> AwardCategories { get; set; }
        public DbSet<Nominee> Nominees { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<CategoryNominees> CategoryNominees { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
    }
}
