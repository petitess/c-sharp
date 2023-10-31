
using Microsoft.EntityFrameworkCore;

namespace Entity.data
{
    //DataContextEF : DbContext = DataContextEF inherits DbContext
    public class DataContextEF : DbContext
    {
        public DbSet<Computer.Models.Computer>? Computer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;",
                    option => option.EnableRetryOnFailure());

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computer.Models.Computer>()
                .ToTable("Computer", "TutorialAppSchema").HasKey(c => c.ComputerId);
        }

    }
}
