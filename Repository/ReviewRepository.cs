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

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _dataContext.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
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

        public bool CreateReview(Review review)
        {
            _dataContext.Reviews.Add(review);
            return Save();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReview(Review review)
        {
            _dataContext.Update(review);
            return Save();
        }
    }
}
