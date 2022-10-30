namespace EFCoreSample.Domain.Interfaces;

/// <summary>
/// Базовая сущнсоть
/// </summary>
public interface IBaseEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long Id { get; set; }
}
