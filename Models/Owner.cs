namespace PokemonReviewApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gym { get; set; }

        //the one relationship is making like this. 
        //it doesn't include list format because it's a one relationship. 

        //this means, every owner can has only one country.
        public Country Country { get; set; }

    }
}
