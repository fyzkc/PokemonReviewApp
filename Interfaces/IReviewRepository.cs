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
        bool CreateReview(Review review);
        bool UpdateReview(Review review);
        bool DeleteReview(Review review);
        bool DeleteReviews(List<Review> reviews);
        bool Save();

    }
}
