using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviews()
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        public IActionResult GetById(int reviewId)
        {
            if (!_reviewRepository.IfReviewExists(reviewId))
                return NotFound();

            var review = _mapper.Map<ReviewDto>(_reviewRepository.GetById(reviewId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(review);
        }


        [HttpGet("reviewer/{reviewId}")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        public IActionResult GetReviewerByReview(int reviewId)
        {
            var reviewer = _mapper.Map<ReviewerDto>(_reviewRepository.GetReviewerByReview(reviewId));
            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(reviewer);
        }


        [HttpGet("review/{pokemonId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviewsByPokemon(int pokemonId)
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewsByPokemon(pokemonId));
            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(reviews);
        }
    }
}
