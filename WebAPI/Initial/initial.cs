using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Initial
{
    public class initial
    {
        BookStoreDbContext db;
        
        public initial()
        {
            db = new BookStoreDbContext();
        }

        public void InitialData()
        {
            List<BookClass> classList = new List<BookClass>
            {
                new BookClass{className = "GENERALITIES"},
                new BookClass{className = "PHILOSOPHY"},
                new BookClass{className = "RELIGIONS"},
                new BookClass{className = "SCIENCE"}
            };

            List<BookCategory> categoryList = new List<BookCategory>
            {
                new BookCategory{cateName = "Computer Science" , bookClass = classList[0]},
                new BookCategory{cateName = "Knowledge" , bookClass = classList[0]},
                new BookCategory{cateName = "Theory of philosophy" , bookClass = classList[1]},
                new BookCategory{cateName = "Ontology" , bookClass = classList[1]},
                new BookCategory{cateName = "Religious ethics" , bookClass = classList[2]},
                new BookCategory{cateName = "Concepts of God" , bookClass = classList[2]},
                new BookCategory{cateName = "Natural history" , bookClass = classList[3]},
                new BookCategory{cateName = "Natural history" , bookClass = classList[3]}
            };

            List<Author> authorList = new List<Author>
            {
                new Author{authorName = "Abdalrahman"},
                new Author{authorName = "Ahmed"},
                new Author{authorName = "Saleh"},
                new Author{authorName = "Abdullah"}
            };

            List<Publisher> publisherList = new List<Publisher>
            {
                new Publisher{publisherName = "Mohammed"},
                new Publisher{publisherName = "Ali"},
                new Publisher{publisherName = "Khaled"},
                new Publisher{publisherName = "Salah"},
                new Publisher{publisherName = "Amr"}
            };

            List<Book> BookList = new List<Book>
            {
                new Book{title = "Storage" , price = 12 , Genre = "Dummy" , bookCategory = categoryList[0] , author = authorList[0] , publisher = publisherList[0]},
                new Book{title = "Peripherals" , price = 15 , Genre = "Dummy" , bookCategory = categoryList[0] , author = authorList[0] , publisher = publisherList[0]},
                new Book{title = "Interfacing and communications" , price = 20 , Genre = "Dummy" , bookCategory = categoryList[0] , author = authorList[0] , publisher = publisherList[0]},
                new Book{title = "General works on specific types of computers" , price = 35 , Genre = "Dummy" , bookCategory = categoryList[0] , author = authorList[1] , publisher = publisherList[1]},
                new Book{title = "Intellectual Life" , price = 20 , Genre = "Dummy" , bookCategory = categoryList[1] , author = authorList[1] , publisher = publisherList[1]},
                new Book{title = "Scholarship and Learning" , price = 25 , Genre = "Dummy" , bookCategory = categoryList[1] , author = authorList[1] , publisher = publisherList[1]},
                new Book{title = "Humanities" , price = 33 , Genre = "Dummy" , bookCategory = categoryList[1] , author = authorList[2] , publisher = publisherList[2]},
                new Book{title = "Research" , price = 10 , Genre = "Dummy" , bookCategory = categoryList[1] , author = authorList[2] , publisher = publisherList[2]},
                new Book{title = "Mythologies" , price = 20 , Genre = "Dummy" , bookCategory = categoryList[2] , author = authorList[2] , publisher = publisherList[2]},
                new Book{title = "The Poetics of Space" , price = 40 , Genre = "Dummy" , bookCategory = categoryList[2] , author = authorList[3] , publisher = publisherList[3]},
                new Book{title = "Being and Time" , price = 10 , Genre = "Dummy" , bookCategory = categoryList[2] , author = authorList[3] , publisher = publisherList[3]},
                new Book{title = "Meditations" , price = 30 , Genre = "Dummy" , bookCategory = categoryList[2] , author = authorList[3] , publisher = publisherList[3]}
            };

            db.bookClass.AddRange(classList);
            db.book.AddRange(BookList);
            db.SaveChanges();
        }
    }
}