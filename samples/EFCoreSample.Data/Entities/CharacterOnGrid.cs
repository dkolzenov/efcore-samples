namespace EFCoreSample.Data.Entities;

public class CharacterOnGrid
{
    public long Id { get; set; }

    public string Value { get; set; } = null!;

    public Alphabet Alphabet { get; set; } = null!;
}
