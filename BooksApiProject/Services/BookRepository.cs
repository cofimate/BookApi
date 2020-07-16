using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApiProject.Models;

namespace BooksApiProject.Services
{
    public class BookRepository : IBookRepository
    {
        private BookDbContext bookContext;
        public BookRepository(BookDbContext _bookContext)
        {
            bookContext = _bookContext;
        }
        public ICollection<Book> GetBooks()
        {
            return bookContext.Books.ToList();
        }
        public Book GetBook(int bookId)
        {
            return bookContext.Books.Where(c => c.Id == bookId).FirstOrDefault();
        }
        public bool IsBookExists(int bookId)
        {
            return bookContext.Books.Any(b => b.Id == bookId);
        }
    }
}
