namespace EFCoreSample.Persistence.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using EFCoreSample.Domain.Entities;

public class SampleConfiguration : IEntityTypeConfiguration<Sample>
{
    private const int MaxLength = 400;
    
    public void Configure(EntityTypeBuilder<Sample> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Title).HasMaxLength(MaxLength).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(MaxLength).IsRequired();
        builder.HasData(GetSeedData());
    }

    private static IEnumerable<Sample> GetSeedData()
    {
        return new List<Sample>
        {
            new()
            {
                Title = "SampleTitle_1",
                Description = "SampleDescription_1"
            },
            new()
            {
                Title = "SampleTitle_2",
                Description = "SampleDescription_2"
            }
        };
    }
}
