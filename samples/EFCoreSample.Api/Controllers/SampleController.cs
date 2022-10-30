namespace EFCoreSample.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using EFCoreSample.Persistence.DbContexts;
using EFCoreSample.Domain.Entities;

/// <summary>
/// Пример контроллера
/// </summary>
[ApiController]
[Route("api/samples")]
public class SampleController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SampleController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Получить образцы
    /// </summary>
    /// <returns>Список образцов</returns>
    [HttpGet]
    public async Task<List<Sample>> GetAllAsync()
    {
        var samples = await _context.Samples.AsNoTracking().ToListAsync();

        return samples;
    }
    
    /// <summary>
    /// Добавить образец
    /// </summary>
    /// <param name="sample">Образец</param>
    /// <returns>Список образцов</returns>
    [HttpPost]
    public async Task<Sample> AddAsync(Sample sample)
    {
        _context.Samples.Add(sample);
        await _context.SaveChangesAsync();

        return sample;
    }

    /// <summary>
    /// Обновить образец
    /// </summary>
    /// <param name="sample">Образец</param>
    /// <returns>Список образцов</returns>
    [HttpPut]
    public async Task<Sample> UpdateAsync(Sample sample)
    {
        _context.Samples.Update(sample);
        await _context.SaveChangesAsync();

        return sample;
    }

    /// <summary>
    /// Удалить образец
    /// </summary>
    /// <param name="sample">Образец</param>
    /// <returns>Список образцов</returns>
    [HttpDelete]
    public async Task<Sample> RemoveAsync(Sample sample)
    {
        _context.Remove(sample);
        await _context.SaveChangesAsync();

        return sample;
    }
}
