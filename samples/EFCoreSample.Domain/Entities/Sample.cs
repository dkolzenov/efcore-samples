namespace EFCoreSample.Domain.Entities;

using EFCoreSample.Domain.Interfaces;

/// <summary>
/// Сущность, приведённая в качестве примера
/// </summary>
public class Sample : IBaseEntity
{
    /// <inheritdoc />
    public long Id { get; set; }

    /// <summary>
    /// Заголовок
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; } = null!;
}
