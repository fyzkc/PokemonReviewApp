using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        // PokemonRepository class uses DataContext class for database processes. 
        // DataContext is injecting via constructor method. 
        private readonly DataContext _context;
        public PokemonRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Pokemon> GetPokemons() // this method was defined in IPokemonRepository interface.
        {
            // this method will listing the data in Pokemons table by their Id numbers. 
            // the return type is a list cuz the method was defined as ICollection.
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }
    }
}
