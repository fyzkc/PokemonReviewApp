﻿using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _dataContext;
        public ReviewerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Reviewer GetById(int reviewerId)
        {
            return _dataContext.Reviewers.Where(r => r.Id == reviewerId).FirstOrDefault();
        }

        public Reviewer GetReviewerByReview(int reviewId)
        {
            return _dataContext.Reviews.Where(r => r.Id == reviewId).Select(rr => rr.Reviewer).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _dataContext.Reviewers.ToList();
        }

        public bool IfReviewerExists(int reviewerId)
        {
            return _dataContext.Reviewers.Any(r => r.Id == reviewerId);
        }
    }
}
