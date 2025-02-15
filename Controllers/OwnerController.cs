using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwners()
        {
            var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(owners);
        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetById(int ownerId)
        {
            if (!_ownerRepository.IfOwnerExists(ownerId))
                return NotFound();

            var owner = _mapper.Map<OwnerDto>(_ownerRepository.GetById(ownerId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owner);
        }


        [HttpGet("owner/{pokemonId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnersByPokemon(int pokemonId)
        {
            var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwnersByPokemon(pokemonId));
            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(owners);
        }

        [HttpGet("pokemon/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonsByOwner(int ownerId)
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_ownerRepository.GetPokemonsByOwner(ownerId));
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(pokemons);
        }

        [HttpGet("country/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetTheCountryOfOwner(int ownerId)
        {
            var country = _mapper.Map<CountryDto>(_ownerRepository.GetTheCountryOfOwner(ownerId));
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(country);
        }
    }
}
