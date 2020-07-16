using BooksApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApiProject.Services
{
    public class ReviewerRepository : IReviewerRepository
    {
        private BookDbContext reviewContext;
        public ReviewerRepository(BookDbContext _reviewContext)
        {
            reviewContext = _reviewContext;
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            return reviewContext.Reviewers.Where(c => c.Id == reviewerId).FirstOrDefault();
        }

        public Reviewer GetReviewerOfReview(int reviewId)
        {
            return reviewContext.Reviews.Where(r => r.Id == reviewId).Select(r => r.Reviewer).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return reviewContext.Reviewers.OrderBy(r => r.LastName).ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return reviewContext.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return reviewContext.Reviewers.Any(r => r.Id == reviewerId);
        }
    }
}
