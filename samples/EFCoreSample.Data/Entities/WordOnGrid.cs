namespace EFCoreSample.Data.Entities;

public class WordOnGrid
{
    public long Id { get; set; }

    public string Value { get; set; } = null!;

    public WordSet WordSet { get; set; } = null!;

    public Direction Direction { get; set; } = null!;
}
