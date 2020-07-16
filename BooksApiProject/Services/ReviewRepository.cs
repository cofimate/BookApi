using BooksApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApiProject.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private BookDbContext reviewContext;

        public ReviewRepository(BookDbContext _reviewContext)
        {
            reviewContext = _reviewContext;
        }

        public bool Createreview(Review review)
        {
            reviewContext.AddAsync(review);
            return Save();
        }

        public bool DeleteReview(Review review)
        {
            reviewContext.Remove(review);
            return Save();
        }

        public Book GetBookOfReview(int reviewId)
        {
            var bookId=  reviewContext.Reviews.Where(r => r.Id == reviewId).Select(b => b.Book.Id).FirstOrDefault();
            return reviewContext.Books.Where(b => b.Id == bookId).FirstOrDefault();
        }

        public Review GetReview(int reviewId)
        {
            return reviewContext.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public Reviewer GetReviewerOfReview(int reviewId)
        {
            return reviewContext.Reviews.Where(r => r.Id == reviewId).Select(r => r.Reviewer).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return reviewContext.Reviews.OrderBy(r => r.Rating).ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return reviewContext.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        public ICollection<Review> GetReviewsOfBook(int bookId)
        {
            return reviewContext.Reviews.Where(r => r.Book.Id == bookId).ToList();
        }

        public bool IsDuplicatedReview(int reviewId, string headLine)
        {
            var review = reviewContext.Reviews.Where(r => r.Headline.ToLower()== headLine.Trim().ToLower()
                                        && r.Id != reviewId).FirstOrDefault();

            return (review == null) ? false : true;
        }

        public bool ReviewExists(int reviewId)
        {
            return reviewContext.Reviews.Any(r => r.Id == reviewId);
        }

        public bool Save()
        {
            var saved = reviewContext.SaveChanges();
            return (saved >= 0);
        }

        public bool UpdateReview(Review review)
        {
            reviewContext.Update(review);
            return Save();
        }

        public Book GetBook(int bookId)
        {
            return reviewContext.Books.Where(c => c.Id == bookId).FirstOrDefault();
        }
        public Reviewer GetReviewer(int reviewerId)
        {
            return reviewContext.Reviewers.Where(c => c.Id == reviewerId).FirstOrDefault();
        }
    }
}
