using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PokemonBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokedexController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(PokemonRepository.GetAllPokemons());
        }

        [HttpGet]
        [Route("get-by-name")]
        public IActionResult GetByName(String? name)
        {
            var result = PokemonRepository.GetAllPokemons().Where(i => i.Name.ToLower() == name.ToLower()).SingleOrDefault();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PokemonDto dto)
        {
            try{
                PokemonRepository.AddPokemon(dto);
                return Created();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] PokemonDto dto)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] PokemonDto dto)
        {
            return Ok();
        }
    }
}
