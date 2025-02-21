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
        bool CreateOwner(Owner owner);
        bool UpdateOwner(Owner owner);
        bool DeleteOwner(Owner owner);
        bool Save();
    }
}
