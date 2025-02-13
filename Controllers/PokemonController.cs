using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
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
        private readonly IMapper _mapper;
        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))] //if the call will be succeed, then it will return 200 Ok and the return type will be IEnumerable.
        public IActionResult GetPokemons()
        {
            // it calls the GetPokemons method from the repository that we injected in the constructor. 
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

            if (!ModelState.IsValid) //it controls if the request is valid or not. 
            {
                return BadRequest(ModelState); // if its not a valid request than it returns BadRequest.
            }

            return Ok(pokemons); //if its valid, then it returns Ok and the result of GetPokemons method. 
            // it is the list of Pokemons. 
        }

        [HttpGet ("{pokemonId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)] // if its a bad request than its returning the 400 status code. 
        public IActionResult GetById(int pokemonId) // we will use the GetById method from the PokemonRepository class. 
        {
            if (!_pokemonRepository.IfPokemonExists(pokemonId)) // first we are checking the pokemon is whether exists or not. 
                return NotFound();

            var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetById(pokemonId)); // then if it can find the pokemon then we are running the GetById mwthod for getting thw details of the pokemon.
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpGet("{pokemonId}/rating")] //it should be the same name for the url and the method for the variable.
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokemonId) // if it will be a different name from the url's, than it will require 2 variable for id area. and thats not what we want. 
        {
            if(!_pokemonRepository.IfPokemonExists(pokemonId))
                return NotFound(); // the IActionResult interface allow us to use these methods. 

            var rating = _pokemonRepository.GetPokemonRating(pokemonId);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }

    }
}
