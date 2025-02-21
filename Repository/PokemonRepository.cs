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
        public Pokemon GetById(int pokemonId)
        {
            return _context.Pokemons.Where(p => p.Id == pokemonId).FirstOrDefault();
            // it runs a query on the database and find the pokemon by the id number that we sent with the where statement.
            // then if it find the pokemon it will return the first or default one. 
            // FirstOrDefault method return the first data that it finds, if the data doesn't exist that it returns the default value of the variable type.
            // for example the default value of integer is 0.
        }

        public Pokemon GetByName(string pokemonName)
        {
            return _context.Pokemons.Where(p => p.Name == pokemonName).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokemonId)
        {
            // a pokemon can has many reviews and ratings. 
            // this code returns all the data from the Reviews table where the given id name is equal to the Id name from the Pokemons table. 
            // the Pokemon property is in the Reviews table cause they have a relation between them. 
            // the returning value is assigning to the rating variable. 
            var rating = _context.Reviews.Where(p => p.Pokemon.Id == pokemonId);

            // if there is no review data for the spesific pokemon then it returns 0.
            if (rating.Count() <= 0)
                return 0;

            // if there are some reviews for the spesific pokemon that we search for by its id, 
            // then this code find its average rating. 
            // rating variable holds the data from reviews table for a spesific pokemon. 
            // this table includes Rating property.
            // Sum(r=> r.Rating) line is getting the sum of the Rating column. 
            // rating.Count() line defines the number of data that returned from Reviews table for a spesific pokemon that has the id number we sent. 
            return ((decimal)rating.Sum(r=> r.Rating) / rating.Count());
        }
        public bool IfPokemonExists(int pokemonId)
        {
            return _context.Pokemons.Any(p=> p.Id == pokemonId);
            // Any() method checks whether the data is exists or not. 
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var owner = _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault(); //finding the record of the ownerId
            var category = _context.Categories.Where(c=> c.Id == categoryId).FirstOrDefault(); //finding the record of the categoryId

            var pokemonOwner = new PokemonOwner() //we are creating a new entity of PokemonOwner for adding to the database table
            {
                Owner = owner, //the Owner property from the PokemonOwner is the owner varible which we find it by using ownerId
                Pokemon = pokemon //the Pokemon property from the PokemonOwner is the pokemon varible which we passed it from the parameter of this method. 
            };

            _context.Add(pokemonOwner); //we are adding this new entity to the PokemonOwners table in the database.

            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon
            };

            _context.Add(pokemonCategory);
            _context.Add(pokemon); //we also adding the pokemon entity to the database table of Pokemons. 
            return Save();

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePokemon(Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }

        public bool DeletePokemon(Pokemon pokemon)
        {
            _context.Remove(pokemon);
            return Save();
        }
    }
}
