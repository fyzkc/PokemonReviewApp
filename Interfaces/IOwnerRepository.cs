using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetById(int ownerId);
        bool IfOwnerExists(int ownerId);
        Country GetTheCountryOfOwner(int ownerId);
        ICollection<Pokemon> GetPokemonsByOwner(int ownerId);
        ICollection<Owner> GetOwnersByPokemon(int pokemonId);
    }
}
