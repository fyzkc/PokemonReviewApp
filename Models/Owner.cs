namespace PokemonReviewApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gym { get; set; }

        //the one relationship is making like this. 
        //it doesn't include list format because it's a one relationship. 

        //this means, every owner can has only one country.
        public Country Country { get; set; }

        public ICollection<PokemonOwner> PokemonOwners { get; set; }

    }
}
