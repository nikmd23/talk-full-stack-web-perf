using System.Data.Entity;

namespace MiLB.Web.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            Database.SetInitializer(new DataContextInitializer());
        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Mascot> Mascots { get; set; }
    }
}