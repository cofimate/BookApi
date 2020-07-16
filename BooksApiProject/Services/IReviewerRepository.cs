using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApiProject.Models;

namespace BooksApiProject.Services
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        Reviewer GetReviewerOfReview(int reviewId);
        bool ReviewerExists(int reviewerId);
    }
}
