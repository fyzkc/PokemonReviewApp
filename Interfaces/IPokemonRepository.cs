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
        bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);
        //when we add a new entity to the Pokemons table, we must change the PokemonOwners and PokemonCategories tables too.
        //Because a Pokemon must have a relationship between owner and the category.
        //so that when we are creating a new pokemon, we should create a new record to PokemonOwners and PokemonCategories tables too. 
        bool UpdatePokemon(Pokemon pokemon);
        bool DeletePokemon(Pokemon pokemon);
        bool Save();
    }
}
