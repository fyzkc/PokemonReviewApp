namespace PokemonReviewApp.Models
{
    public class PokemonCategory
    {
        //this is a join table for many-to-many relationship.
        //for many-to-many relationships, there should be a join table.
        //if one don't create a join table, then some of the data can be repeated at so many place.
        //and for this, provide the data integrity will be hard. 

        public int PokemonId { get; set; } //foreign keys
        public int CategoryId { get; set; }
        public Pokemon Pokemon { get; set; } //entities
        public Category Category { get; set; }
    }

}
