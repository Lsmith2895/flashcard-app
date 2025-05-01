using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlashCardApi.Data;
using FlashCardApi.Models;

namespace FlashCardApi.Controllers;

[ApiController]
[Route("api/flashcards")]
public class FlashCardsController : ControllerBase
{
    private readonly FlashCardDbContext _context;

    public FlashCardsController(FlashCardDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FlashCard>>> GetAll()
    {
        return await _context.FlashCards.ToListAsync();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FlashCard>> Get(Guid id)
    {
        var card = await _context.FlashCards.FindAsync(id);
        return card == null ? NotFound() : Ok(card);
    }

    [HttpPost]
    public async Task<ActionResult<FlashCard>> Create([FromBody] FlashCard flashCard)
    {
        _context.FlashCards.Add(flashCard);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = flashCard.Id }, flashCard);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, FlashCard updated)
    {
        if (id != updated.Id) return BadRequest();

        var card = await _context.FlashCards.FindAsync(id);
        if (card == null) return NotFound();

        card.Front = updated.Front;
        card.Back = updated.Back;
        card.IsFlipped = updated.IsFlipped;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var card = await _context.FlashCards.FindAsync(id);
        if (card == null) return NotFound();

        _context.FlashCards.Remove(card);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
