using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _dataContext;
        public CountryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ICollection<Country> GetCountries()
        {
            return _dataContext.Countries.ToList();
        }
        public Country GetById(int countryId)
        {
            return _dataContext.Countries.Where(c => c.Id == countryId).FirstOrDefault();
        }
        public ICollection<Owner> GetOwnersByCountry(int countryId)
        {
            return _dataContext.Owners.Where(o => o.Country.Id == countryId).ToList();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _dataContext.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }        

        public bool IfCountryExists(int countryId)
        {
            return _dataContext.Countries.Any(c => c.Id == countryId);
        }

        public bool CreateCountry(Country country)
        {
            _dataContext.Add(country);
            return Save();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
