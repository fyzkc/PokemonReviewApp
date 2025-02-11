using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")] //api will has an endpoint such as "api/pokemon".
    [ApiController]
    public class PokemonController : Controller
    {
        // IPokemonRepository is injecting via constructor method. 
        // whatever the class that inherits the IPokemonRepository can be injected here. 
        // The injection will be made in Program.cs.
        private readonly IPokemonRepository _pokemonRepository;
        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))] //if the call will be succeed, then it will return 200 Ok and the return type will be IEnumerable.
        public IActionResult GetPokemons()
        {
            // it calls the GetPokemons method from the repository that we injected in the constructor. 
            var pokemons = _pokemonRepository.GetPokemons();
            
            if(!ModelState.IsValid) //it controls if the request is valid or not. 
            {
                return BadRequest(ModelState); // if its not a valid request than it returns BadRequest.
            }

            return Ok(pokemons); //if its valid, then it returns Ok and the result of GetPokemons method. 
            // it is the list of Pokemons. 
        }
    }
}
