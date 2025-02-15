using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _dataContext;
        public ReviewRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Review GetById(int reviewId)
        {
            return _dataContext.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public Reviewer GetReviewerByReview(int reviewId)
        {
            return _dataContext.Reviews.Where(r => r.Id == reviewId).Select(rr => rr.Reviewer).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _dataContext.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsByPokemon(int pokemonId)
        {
            return _dataContext.Reviews.Where(p => p.Pokemon.Id == pokemonId).ToList();
        }

        public bool IfReviewExists(int reviewId)
        {
            return _dataContext.Reviews.Any(r => r.Id == reviewId);
        }
    }
}
