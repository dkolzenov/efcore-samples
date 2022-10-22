namespace EFCoreSample.Data.Entities;

public class Direction
{
    public long Id { get; set; }

    public int RowMovement { get; set; }

    public int ColumnMovement { get; set; }

    public string Layout { get; set; } = null!;

    public string DirectionType { get; set; } = null!;
}
