using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    // this interface will be using by PokemonRepository class. 
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetById(int pokemonId); // it gets the details of the pokemon by its id number
        Pokemon GetByName(string pokemonName); // it gets the details of the pokemon by its name
        decimal GetPokemonRating(int pokemonId); // it gets the rating of the pokemon by its id number
        bool IfPokemonExists(int pokemonId); // it gets if the pokemon exists or not by its id number

    }
}
