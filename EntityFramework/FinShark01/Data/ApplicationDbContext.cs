using FinShark.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        private readonly DbContextOptions _dbContextOptions;

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>(x => x.HasKey(y => new { y.AppUserId, y.StockId }));

            builder.Entity<Portfolio>()
                .HasOne(x => x.Stock)
                .WithMany(y => y.Portfolios)
                .HasForeignKey(z => z.StockId);

            builder.Entity<Portfolio>()
                .HasOne(x => x.AppUser)
                .WithMany(y => y.Portfolios)
                .HasForeignKey(z => z.AppUserId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "f0181e56-0cb8-4cd6-9ca3-759598779948",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "2024-01-30"
                },
                new IdentityRole
                {
                    Id = "b615652c-ee08-4a36-9d96-3b035e30e0d2",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "2024-01-30"
                },
                new IdentityRole
                {
                    Id = "5b9e96bd-631c-47a5-9190-53968d834d3f",
                    Name = "SuperUser",
                    NormalizedName = "SUPERUSER",
                    ConcurrencyStamp = "2024-01-30"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            var hasher = new PasswordHasher<AppUser>();

            List<AppUser> users = new List<AppUser>
            {
                new AppUser
                {
                    Id = "3a2f3435-014f-42b7-a58f-6952bb5e0e4a",
                    Email = "x@x.x",
                    UserName = "x",
                    NormalizedEmail = "X@X.X",
                    NormalizedUserName = "X",
                    PasswordHash = hasher.HashPassword(null, "12345"),
                    ConcurrencyStamp = "2024-01-30",
                    SecurityStamp = "3a2f3435-014f-42b7-a58f-6952bb5e0e4a"
                },
                new AppUser
                {
                    Id = "145a2110-d515-47cb-96e5-ce0aeb7da52f",
                    Email = "y@x.x",
                    UserName = "y",
                    NormalizedEmail = "Y@Y.Y",
                    NormalizedUserName = "Y",
                    PasswordHash = hasher.HashPassword(null, "12345"),
                    ConcurrencyStamp = "2024-01-30",
                    SecurityStamp = "145a2110-d515-47cb-96e5-ce0aeb7da52f"
                }
            };
            builder.Entity<AppUser>().HasData(users);
            
        }
    }
}
