using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetById(int reviewerId);
        bool IfReviewerExists(int reviewerId);
        Reviewer GetReviewerByReview(int reviewId);
        bool CreateReviewer(Reviewer reviewer);
        bool Save();

    }
}
