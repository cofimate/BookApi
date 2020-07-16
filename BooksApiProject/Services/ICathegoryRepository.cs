using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApiProject.Models;

namespace BooksApiProject.Services
{
    public interface ICathegoryRepository
    {
        ICollection<Cathegory> GetCategories();
        Cathegory GetCategory(int cathegoryId);
        ICollection<Cathegory> GetCathegoriesOfABook(int bookId);
        ICollection<Book> GetBooksForCathegory(int cathegoryId);
        bool CathegoryExists(int cathegoryId);
        bool IsDuplicatedCathegory(int categoryId, string categoryName);
    }
}
