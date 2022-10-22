using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreSample.Data.DbContexts;
using EFCoreSample.Data.Entities;

namespace EFCoreSample.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordOnGridController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public WordOnGridController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<WordOnGrid>>> GetAllWordsOnGridAsync()
    {
        var wordsOnGrid = await _context.WordsOnGrid.AsNoTracking().ToListAsync();

        return wordsOnGrid;
    }
    
    [HttpPost]
    public WordOnGrid AddTaskAsync(WordOnGrid wordOnGrid)
    {
        _context.WordsOnGrid.Add(wordOnGrid);

        return wordOnGrid;
    }

    [HttpPut]
    public WordOnGrid UpdateTaskAsync(WordOnGrid wordOnGrid)
    {
        _context.WordsOnGrid.Update(wordOnGrid);

        return wordOnGrid;
    }

    [HttpDelete]
    public WordOnGrid RemoveTaskAsync(WordOnGrid wordOnGrid)
    {
        _context.Remove(wordOnGrid);

        return wordOnGrid;
    }
}
