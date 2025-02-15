using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Review GetById(int reviewerId);
        bool IfReviewExists(int reviewerId);

    }
}
