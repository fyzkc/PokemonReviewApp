using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetById(int reviewId);
        bool IfReviewExists(int reviewId);
        Reviewer GetReviewerByReview(int reviewId);
        ICollection<Review> GetReviewsByPokemon(int pokemonId);

    }
}
