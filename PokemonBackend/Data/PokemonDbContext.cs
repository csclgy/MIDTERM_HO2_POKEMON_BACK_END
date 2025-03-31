using Microsoft.EntityFrameworkCore;
using PokemonBackend.Models;

namespace PokemonBackend.Data
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options)
            : base(options) { }

        public DbSet<Pokemon> Pokemon { get; set; } = null!;
    }
}