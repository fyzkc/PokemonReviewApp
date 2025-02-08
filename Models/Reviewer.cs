namespace PokemonReviewApp.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //this means every reviewer can has many reviews. 
        public ICollection<Review> Reviews { get; set; }
    }
}
