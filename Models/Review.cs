namespace PokemonReviewApp.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        //every review can has only one reviewer at a time. 
        public Reviewer Reviewer { get; set; }

        //every review can be made for only one pokemon at a time. 
        public Pokemon Pokemon { get; set; }
    }
}
