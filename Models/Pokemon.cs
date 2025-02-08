namespace PokemonReviewApp.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        //there is one-to-many relationship between Review and Pokemon. 
        //the many side of the relationships should be in a list format. and the most recommended list format
        //for making relations is ICollection.
        //because ef can work more flexible with ICollection instead of List.

        //this means every pokemon can has many reviews. 
        public ICollection<Review> Reviews { get; set; }


        //for many-to-many relationship, we should use the join tables
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
    }
}
