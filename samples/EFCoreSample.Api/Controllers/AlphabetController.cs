using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreSample.Persistence.DbContexts;
using EFCoreSample.Persistence.Entities;

namespace EFCoreSample.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlphabetController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AlphabetController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<List<Alphabet>> GetAllAsync()
    {
        var alphabets = await _context.Alphabets.AsNoTracking().ToListAsync();

        return alphabets;
    }
    
    [HttpPost]
    public async Task<Alphabet> AddAsync(Alphabet alphabet)
    {
        _context.Alphabets.Add(alphabet);
        await _context.SaveChangesAsync();

        return alphabet;
    }

    [HttpPut]
    public async Task<Alphabet> UpdateAsync(Alphabet alphabet)
    {
        _context.Alphabets.Update(alphabet);
        await _context.SaveChangesAsync();

        return alphabet;
    }

    [HttpDelete]
    public async Task<Alphabet> RemoveAsync(Alphabet alphabet)
    {
        _context.Remove(alphabet);
        await _context.SaveChangesAsync();

        return alphabet;
    }
}
