using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetById(int reviewId);
        bool IfReviewExists(int reviewId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        ICollection<Review> GetReviewsByPokemon(int pokemonId);

    }
}
