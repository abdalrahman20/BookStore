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
    public class ClassificationController : ApiController
    {
        private BookStoreDbContext db = new BookStoreDbContext();

        // GET api/Classification
        /// <summary>
        /// GET Method to retrive all Book Classess
        /// </summary>
        /// <returns>
        /// list of BookClass
        /// </returns>
        
        public IQueryable<BookClass> GetbookClass()
        {
            return (IQueryable<BookClass>)db.bookClass;
        }

        // GET api/Classification/5
        /// <summary>
        /// GET Method to retrive only one Book Class
        /// </summary>
        /// <param name="id">
        /// bookClass id to retrive
        /// </param>
        /// <returns>
        /// one element of type BookClass
        /// </returns>
        [ResponseType(typeof(BookClass))]
        public IHttpActionResult GetBookClass(int id)
        {
            BookClass bookclass = db.bookClass.FirstOrDefault(b => b.classID == id);
            if (bookclass == null)
            {
                return NotFound();
            }

            return Ok(bookclass);
        }

        // PUT api/Classification/5
        /// <summary>
        /// PUT Method to update a specific record in BookClass Table
        /// </summary>
        /// <param name="obj">
        /// The new BookClass data
        /// </param>
        /// <returns>
        /// The Status of the PUT Method (OK or NOT)
        /// </returns>
        public IHttpActionResult PutBookClass(BookClass obj)
        {
            BookClass bookclass = db.bookClass.FirstOrDefault(b => b.classID == obj.classID);
            if (bookclass == null)
            {
                return NotFound();
            }

            bookclass.className = obj.className;
            db.SaveChanges();

            return Ok();
        }

        // POST api/Classification
        /// <summary>
        /// POST Method to add a new record in BookClass Table
        /// </summary>
        /// <param name="bookclass">
        /// The data of BookClass to add
        /// </param>
        /// <returns>
        /// The Status of the POST Method (OK or NOT)
        /// </returns>
        [ResponseType(typeof(BookClass))]
        public IHttpActionResult PostBookClass(BookClass bookclass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.bookClass.Add(bookclass);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = bookclass.classID }, bookclass);
            return Ok();
        }

        // DELETE api/Classification/5
        /// <summary>
        /// Delete Method that's delete a spicific record from BookClass Table
        /// </summary>
        /// <param name="id">
        /// The BookClass id which will be deleted
        /// </param>
        /// <returns>
        /// The status of Delete Method (OK or NOT)
        /// </returns>
        [ResponseType(typeof(BookClass))]
        public IHttpActionResult DeleteBookClass(int id)
        {
            BookClass bookclass = db.bookClass.FirstOrDefault(b => b.classID == id);
            if (bookclass == null)
            {
                return NotFound();
            }

            db.bookClass.Remove(bookclass);
            db.SaveChanges();
            return Ok(bookclass);
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