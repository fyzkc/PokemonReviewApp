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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] CategoryDto createCategory)
        {
            if (createCategory == null) //first we are checking if the entity that we gave as a parameter and want to add to the database is null or not.
                return BadRequest(ModelState);

            var category = _categoryRepository.GetCategories()
                .Where(c => c.Name.Trim().ToUpper() == createCategory.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            //Trim method removes the spaces from the text's begginning and the ending. 
            //ToUpper method makes the text's all letters upper. 
            //we are checking that if theres already a category with that name or not. 
            //if there's already a record with this same name, FirstOrDefault method will retun this record.
            //if there's no record with that spesific name, than the method will return null. 

            if(category != null) // if returned value isn't null, that means there's already a record with that spesific name.
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<Category>(createCategory); //we are mapping the entity to the CategoryDto.

            if(!_categoryRepository.CreateCategory(categoryMap)) //we are running the creating method from the repository and if it will return false, then it means there had some problem while saving. 
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return BadRequest(ModelState);
            }

            return Ok("Category created successfully"); //if there's no problem then the method will save the entity to the database and we can show a successful message. 
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int categoryId,  [FromBody] CategoryDto category)
        {
            if (category == null)
                return BadRequest(ModelState);

            if(categoryId != category.Id)
                return BadRequest(ModelState);

            if (!_categoryRepository.IfCategoryExists(categoryId))
                return NotFound();
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<Category>(category);

            if(!_categoryRepository.UpdateCategory(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500,ModelState);
            }

            return Ok("Category successfully updated");
        }
    }
}
