namespace EFCoreSample.Data.Entities;

public class DataGrid
{
    public long Id { get; set; }
    
    public int Row { get; set; }
    
    public int Column { get; set; }

    public string Size { get; set; } = null!;

    public List<WordOnGrid> WordOnGrids { get; set; } = null!;

    public List<CharacterOnGrid> CharacterOnGrids { get; set; } = null!;
}
