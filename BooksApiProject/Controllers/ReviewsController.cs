using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BooksApiProject.Services;
using BooksApiProject.Dtos;
using BooksApiProject.Models;



namespace BooksApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private IReviewRepository reviewRepository;
        public ReviewsController(IReviewRepository _reviewRepository)
        {
            reviewRepository = _reviewRepository;
        }

        [HttpGet("{reviewId}",Name ="GetReview")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetReview(int reviewId)
        {
            if (!reviewRepository.ReviewExists(reviewId))
                return NotFound();

            var review = reviewRepository.GetReview(reviewId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(review);
        }

        //api/Reviews
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetCountries()
        {
            var reviews = reviewRepository.GetReviews().ToList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }
        //api/reviews/Id
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(200)]
        public IActionResult CreateReview([FromBody]Review reviewToCreate)
        {
            // need to verify if the Book and Reviewer on the reviewToCreate are valid
            //user ReviewerExist and BookExists from the corresponding repository if not exists respond 404

            if (reviewToCreate == null)
                return BadRequest(ModelState);

   
            var review = reviewRepository.GetReviews().Where(c => c.Headline.Trim().ToLower() == reviewToCreate.Headline.Trim().ToLower()).FirstOrDefault();

            if (review!= null)
            {
                ModelState.AddModelError("", $"Country {reviewToCreate.Headline} already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            reviewToCreate.Book = reviewRepository.GetBook(reviewToCreate.Book.Id);
            reviewToCreate.Reviewer = reviewRepository.GetReviewer(reviewToCreate.Reviewer.Id);

            //reviewToCreate.Book = 

            if (!reviewRepository.Createreview(reviewToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong saveing {reviewToCreate.Headline}");
                return StatusCode(500, ModelState);

            }
            var reviewDto = new ReviewDto();
            reviewDto.Id = reviewToCreate.Id;
            reviewDto.Rating = reviewToCreate.Rating;
            reviewDto.Headline = reviewToCreate.Headline;
            reviewDto.ReviewText = reviewToCreate.ReviewText;
            
            return Ok(reviewDto);
        }
        [HttpGet("review/GetBookOfReview/{reviewId}")]
        public IActionResult GetBookOfReview(int reviewId)
        {
            var book = GetBookOfReview(reviewId);
            return Ok(book);
        }
    }
}