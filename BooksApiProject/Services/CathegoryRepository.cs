using BooksApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BooksApiProject.Services
{
    public class CathegoryRepository : ICathegoryRepository
    {
        private BookDbContext categoryContext;
        public CathegoryRepository(BookDbContext _categoryContext)
        {
            categoryContext = _categoryContext;
        }
        public bool CathegoryExists(int cathegoryId)
        {
            return categoryContext.Cathegories.Any(c => c.Id == cathegoryId); 
        }

        public ICollection<Book> GetBooksForCathegory(int cathegoryId)
        {
            return categoryContext.BookCategories.Where(c => c.CategoryId == cathegoryId).Select(b => b.Book).ToList();
        }

        public ICollection<Cathegory> GetCategories()
        {
            return categoryContext.Cathegories.OrderBy(c => c.Name).ToList();
        }

        public Cathegory GetCategory(int cathegoryId)
        {
            return categoryContext.Cathegories.Where(c => c.Id == cathegoryId).FirstOrDefault();
        }

        public ICollection<Cathegory> GetCathegoriesOfABook(int bookId)
        {
            return categoryContext.BookCategories.Where(b => b.BookId == bookId).Select(c => c.Cathegory).ToList();
        
        }

        public bool IsDuplicatedCathegory(int categoryId, string categoryName)
        {
            var category = categoryContext.Cathegories.Where(c => c.Name.Trim().ToLower() == categoryName.Trim().ToLower()
                                        && c.Id != categoryId).FirstOrDefault();

            return (category == null) ? false : true;
        }
    }
}
