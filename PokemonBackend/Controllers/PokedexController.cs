using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonBackend.Data;
using PokemonBackend.Models;

namespace PokemonBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokedexController : ControllerBase
    {
        private readonly PokemonDbContext _context;

        public PokedexController(PokemonDbContext context)
        {
            _context = context;
        }

        // GET: api/pokedex
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pokemons = await _context.Pokemon.ToListAsync();

            Console.WriteLine($"[DEBUG] Retrieved {pokemons.Count} Pokémon from DB.");

            if (!pokemons.Any())
                return NotFound("No Pokémon found.");

            return Ok(pokemons);
        }

        // GET: api/pokedex/get-by-name?name=Pikachu
        [HttpGet("get-by-name")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Name parameter is required.");

            var pokemon = await _context.Pokemon
                .FirstOrDefaultAsync(p => p.Pokemon_Name.ToLower() == name.ToLower());

            Console.WriteLine($"[DEBUG] Searching Pokémon: {name}");

            return pokemon != null ? Ok(pokemon) : NotFound("Pokemon not found.");
        }


        // GET: api/pokedex/get-by-type?type=Electric
        [HttpGet("get-by-type")]
        public async Task<IActionResult> GetByType([FromQuery] string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return BadRequest("Type parameter is required.");

            var pokemons = await _context.Pokemon
                .Where(p => p.Element_Type == type)
                .ToListAsync();

            return pokemons.Any() ? Ok(pokemons) : NotFound("No Pokemon found with the specified type.");
        }

        // POST: api/pokedex
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pokemon dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Pokemon_Name) || string.IsNullOrWhiteSpace(dto.Element_Type))
                return BadRequest("Invalid Pokémon data.");

            Console.WriteLine($"[DEBUG] Adding Pokémon: {dto.Pokemon_Name}");

            _context.Pokemon.Add(dto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByName), new { name = dto.Pokemon_Name }, dto);
        }


        // PUT: api/pokedex
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Pokemon dto)
        {
            if (dto == null || dto.Id == 0)
                return BadRequest("Invalid Pokémon data.");

            var existingPokemon = await _context.Pokemon.FindAsync(dto.Id);
            if (existingPokemon == null)
                return NotFound("Pokemon not found.");

            existingPokemon.Pokemon_Image = dto.Pokemon_Image ?? existingPokemon.Pokemon_Image;
            existingPokemon.Pokemon_Height = dto.Pokemon_Height != 0 ? dto.Pokemon_Height : existingPokemon.Pokemon_Height;
            existingPokemon.Pokemon_Weight = dto.Pokemon_Weight != 0 ? dto.Pokemon_Weight : existingPokemon.Pokemon_Weight;
            existingPokemon.Element_Type = dto.Element_Type ?? existingPokemon.Element_Type;

            await _context.SaveChangesAsync();
            return Ok(existingPokemon);
        }

        // DELETE: api/pokedex/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pokemon = await _context.Pokemon.FindAsync(id);
            if (pokemon == null)
                return NotFound("Pokemon not found.");

            _context.Pokemon.Remove(pokemon);
            await _context.SaveChangesAsync();

            return Ok($"Pokemon {pokemon.Pokemon_Name} removed successfully.");
        }
    }
}
