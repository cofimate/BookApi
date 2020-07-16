using System;
using System.Collections.Generic;
using System.Text;
using BooksApiProject.Services;
using System.Linq;
using System.Threading.Tasks;
using BooksApiProject.Models;

namespace XUnitTestProject1
{
    public static class FakeDataClass
    {
        public static void SeedDataContext(this BookDbContext context)
        {
            var booksAuthors = new List<BookAuthor>()
            {
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "321",
                        Title = "Don Quijote de la Mancha",
                        DatePublished = new DateTime(1604,1,1),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Cathegory = new Cathegory() { Name = "Action"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { Headline = "Awesome Book", ReviewText = "El Mejor", Rating = 5,
                             Reviewer = new Reviewer(){ FirstName = "John", LastName = "Smith" } },
                            new Review { Headline = "Terrible Book", ReviewText = "El mejor libro de toda la historia", Rating = 5,
                             Reviewer = new Reviewer(){ FirstName = "Peter", LastName = "Griffin" } },
                            new Review { Headline = "Have to read", ReviewText = "Por siempre Quijot", Rating = 5,
                             Reviewer = new Reviewer(){ FirstName = "Paul", LastName = "Griffin" } }
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Miguel",
                        LastName = "Cervantes",
                        Country = new BooksApiProject.Models.Country()
                        {
                            Name = "Spain"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "3234",
                        Title = "Moby Dick",
                        DatePublished = new DateTime(1878,10,1),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Cathegory = new Cathegory() { Name = "Western"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { Headline = "Awesome Book", ReviewText = "Epic of Human adventure", Rating = 4,
                             Reviewer = new Reviewer(){ FirstName = "Frank", LastName = "Cher" } }
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Herman",
                        LastName = "Melville",
                        Country = new BooksApiProject.Models.Country()
                        {
                            Name = "USA"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "12345",
                        Title = "Cecilio Best Book",
                        DatePublished = new DateTime(2019,2,2),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Cathegory = new Cathegory() { Name = "Educational"}},
                            new BookCategory { Cathegory = new Cathegory() { Name = "Computer Programming"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { Headline = "Awesome Programming Book", ReviewText = "Reviewing Cec Best Book and it is awesome beyond words", Rating = 5,
                             Reviewer = new Reviewer(){ FirstName = "Cec", LastName = "Cofi" } }
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Cecilio",
                        LastName = "Cofler",
                        Country = new BooksApiProject.Models.Country()
                        {
                            Name = "Argentina"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "123456",
                        Title = "Three Musketeers",
                        DatePublished = new DateTime(2019,2,2),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Cathegory = new Cathegory() { Name = "Action"}},
                            new BookCategory { Cathegory = new Cathegory() { Name = "History"}}
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Alexander",
                        LastName = "Dumas",
                        Country = new BooksApiProject.Models.Country()
                        {
                            Name = "France"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "1234567",
                        Title = "Big Romantic Book",
                        DatePublished = new DateTime(1879,3,2),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Cathegory = new Cathegory() { Name = "Romance"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { Headline = "Good Romantic Book", ReviewText = "This book made me cry a few times", Rating = 5,
                             Reviewer = new Reviewer(){ FirstName = "Allison", LastName = "Kutz" } },
                            new Review { Headline = "Horrible Romantic Book", ReviewText = "My wife made me read it and I hated it", Rating = 1,
                             Reviewer = new Reviewer(){ FirstName = "Kyle", LastName = "Kutz" } }
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Anita",
                        LastName = "Powers",
                        Country = new BooksApiProject.Models.Country()
                        {
                            Name = "Canada"
                        }
                    }
                }
            };

        }
    }
}
