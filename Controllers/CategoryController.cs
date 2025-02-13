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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))] //if the call will be succeed, then it will return 200 Ok and the return type will be IEnumerable.
        public IActionResult GetCategories()
        {
            // it calls the GetCategories method from the repository that we injected in the constructor. 
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid) //it controls if the request is valid or not. 
            {
                return BadRequest(ModelState); // if its not a valid request than it returns BadRequest.
            }

            return Ok(categories); //if its valid, then it returns Ok and the result of GetCategories method. 
            // it is the list of Categories. 
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)] // if its a bad request than its returning the 400 status code. 
        public IActionResult GetById(int categoryId) // we will use the GetById method from the CategoryRepository class. 
        {
            if (!_categoryRepository.IfCategoryExists(categoryId)) // first we are checking the category is whether exists or not. 
                return NotFound();

            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetById(categoryId)); // then if it can find the category then we are running the GetById method for getting the details of the category.
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category); 
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemonByCategory(int categoryId)
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonByCategory(categoryId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }


    }
}
