using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class CoachConfiguration : IEntityTypeConfiguration<Coach>
{
    public void Configure(EntityTypeBuilder<Coach> builder)
    {
        builder.HasData(
            new Coach
            {
                Id = 1,
                Name = "Jose Mourinho",
                CreatedDate = new DateTime(2024, 01, 04),
                ModifiedDate = new DateTime(2024, 01, 04)//DateTime.Now

            },
            new Coach
            {
                Id = 2,
                Name = "Pep Guardiola",
                CreatedDate = new DateTime(2024, 01, 04),
                ModifiedDate = new DateTime(2024, 01, 04)//DateTime.Now
            },
            new Coach
            {
                Id = 3,
                Name = "Trevoir Williams",
                CreatedDate = new DateTime(2024, 01, 04),
                ModifiedDate = new DateTime(2024, 01, 04)//DateTime.Now
            }
            );
    }
}