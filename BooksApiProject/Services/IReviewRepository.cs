using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApiProject.Models;

namespace BooksApiProject.Services
{
    public interface IReviewRepository
    {
        //ICollection<Review> GetReviews();
        //Review GetReview(int reviewerId);
        //ICollection<Review> GetReviewsByReviewer(int reviewerId);
        //Reviewer GetReviewerOfReview(int reviewId);
        //bool ReviewExists(int reviewerId);

        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfBook(int bookId);
        Book GetBookOfReview(int reviewId);
        bool ReviewExists(int reviewId);
        bool IsDuplicatedReview(int reviewId, string headLine);
        bool Createreview(Review  review);
        bool UpdateReview(Review review);
        bool DeleteReview(Review review);
        bool Save();
        Book GetBook(int bookId);
        Reviewer GetReviewer(int reviewerId);
    }
}
