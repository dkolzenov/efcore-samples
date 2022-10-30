namespace EFCoreSample.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using EFCoreSample.Persistence.DbContexts;
using EFCoreSample.Domain.Entities;

[ApiController]
[Route("api/samples")]
public class SampleController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SampleController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<List<Sample>> GetAllAsync()
    {
        var samples = await _context.Samples.AsNoTracking().ToListAsync();

        return samples;
    }
    
    [HttpPost]
    public async Task<Sample> AddAsync(Sample sample)
    {
        _context.Samples.Add(sample);
        await _context.SaveChangesAsync();

        return sample;
    }

    [HttpPut]
    public async Task<Sample> UpdateAsync(Sample sample)
    {
        _context.Samples.Update(sample);
        await _context.SaveChangesAsync();

        return sample;
    }

    [HttpDelete]
    public async Task<Sample> RemoveAsync(Sample sample)
    {
        _context.Remove(sample);
        await _context.SaveChangesAsync();

        return sample;
    }
}
