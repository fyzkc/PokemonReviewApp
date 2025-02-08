namespace PokemonReviewApp.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //this means every country can has many owners. 
        public ICollection<Owner> Owners { get; set; }
    }
}
