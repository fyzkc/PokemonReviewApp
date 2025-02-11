using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    // this interface will be using by PokemonRepository class. 
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
    }
}
