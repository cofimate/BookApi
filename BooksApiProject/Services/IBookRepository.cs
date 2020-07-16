using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApiProject.Models;

namespace BooksApiProject.Services
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBook(int bookId);
        bool IsBookExists(int bookId);
    }
}
