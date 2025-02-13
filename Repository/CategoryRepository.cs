using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
             _context = context;
        }
        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
        
        public Category GetById(int categoryId)
        {
            return _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
        }
        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            // because of the pokemon and the category has a relationship and they have a join table,
            // we are getting the data from the pokemoncategory table. 
            // we are searching the data with the same id number as we sent into the method as a parameter,
            // and select the pokemon property in the pokemoncategory table. 
            // because we want to reach the pokemons by its category. 
            return _context.PokemonCategories.Where(p=> p.CategoryId == categoryId).Select(p => p.Pokemon).ToList();
        }

        public bool IfCategoryExists(int categoryId)
        {
            return _context.Categories.Any(c => c.Id == categoryId);
        }
    }
}
