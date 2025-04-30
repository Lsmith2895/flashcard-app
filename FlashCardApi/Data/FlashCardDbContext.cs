using Microsoft.EntityFrameworkCore;
using FlashCardApi.Models;

namespace FlashCardApi.Data;

public class FlashCardDbContext : DbContext
{
    public FlashCardDbContext(DbContextOptions<FlashCardDbContext> options) : base(options) { }

    public DbSet<FlashCard> FlashCards => Set<FlashCard>();
}
