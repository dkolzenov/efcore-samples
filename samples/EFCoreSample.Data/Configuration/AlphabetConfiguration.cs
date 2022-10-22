using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCoreSample.Data.Entities;

namespace EFCoreSample.Data.Configuration;

public class AlphabetConfiguration : IEntityTypeConfiguration<Alphabet>
{
    public void Configure(EntityTypeBuilder<Alphabet> builder)
    {
        builder.HasData(GetSeedData(builder));
    }

    private static IEnumerable<Alphabet> GetSeedData(
        EntityTypeBuilder<Alphabet> builder)
    {
        return new List<Alphabet>
        {
            new()
            {
                Id = 1,
                Characters = "abcdefghijklmnopqrstuvwxyz",
                Script = "latin"
            },
            new()
            {
                Id = 2,
                Characters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя",
                Script = "cyrillic"
            }
        };
    }
}
