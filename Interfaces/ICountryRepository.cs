using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetById(int countryId);
        bool IfCountryExists(int countryId);
        ICollection<Owner> GetOwnersByCountry(int countryId);
        Country GetCountryByOwner(int ownerId);
        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountry(Country country);
        bool Save();
    }
}
