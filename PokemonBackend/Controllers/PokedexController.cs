using Microsoft.AspNetCore.Mvc;
using PokemonBackend.Models;
using PokemonBackend.Data;
using PokemonBackend;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokedexController : ControllerBase
    {
        private readonly PokemonDbContext _repository;

        public PokedexController(PokemonDbContext repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pokemons = _repository.GetAllPokemon();
            return Ok(pokemons);
        }
    }
}
