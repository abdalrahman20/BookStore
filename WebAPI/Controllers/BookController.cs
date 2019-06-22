using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class BookController : ApiController
    {
        private BookStoreDbContext db = new BookStoreDbContext();

        // GET api/allBooks
        /// <summary>
        /// GET Method to retrive all Books
        /// </summary>
        /// <returns>
        /// list of Book
        /// </returns>
        public IQueryable<Book> GetBook()
        {
            return (IQueryable<Book>)db.book;
        }

        // GET api/Book/5
        /// <summary>
        /// GET Method to retrive only one Book
        /// </summary>
        /// <param name="id">
        /// book id to retrive
        /// </param>
        /// <returns>
        /// one element of type Book
        /// </returns>
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            Book book = db.book.FirstOrDefault(b => b.bookID == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // PUT api/Book/5
        /// <summary>
        /// PUT Method to update a specific record in Book Table
        /// </summary>
        /// <param name="obj">
        /// The new Book data
        /// </param>
        /// <returns>
        /// The Status of the PUT Method (OK or NOT)
        /// </returns>
        public IHttpActionResult PutBook(Book obj)
        {
            Book book = db.book.FirstOrDefault(b => b.bookID == obj.bookID);
            if (book == null)
            {
                return NotFound();
            }

            book.title = obj.title;
            book.Genre = obj.Genre;
            book.price = obj.price;
            db.SaveChanges();

            return Ok();
        }

        // POST api/Book
        /// <summary>
        /// POST Method to add a new record in Book Table
        /// </summary>
        /// <param name="book">
        /// The data of Book to add
        /// </param>
        /// <returns>
        /// The Status of the POST Method (OK or NOT)
        /// </returns>
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.book.Add(book);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = book.bookID }, book);
            return Ok();
        }

        // DELETE api/Book/5
        /// <summary>
        /// Delete Method that's delete a spicific record from BookClass Table
        /// </summary>
        /// <param name="id">
        /// The BookClass id which will be deleted
        /// </param>
        /// <returns>
        /// The status of Delete Method (OK or NOT)
        /// </returns>
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.book.FirstOrDefault(b => b.bookID == id);
            if (book == null)
            {
                return NotFound();
            }

            db.book.Remove(book);
            db.SaveChanges();
            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}