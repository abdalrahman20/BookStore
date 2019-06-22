using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AuthorController : ApiController
    {
        private BookStoreDbContext db = new BookStoreDbContext();

        // GET api/Author
        /// <summary>
        /// GET Method to retrive all Authors
        /// </summary>
        /// <returns>
        /// list of Author
        /// </returns>
        public IQueryable<Author> GetAuthor()
        {
            return db.author;
        }

        // GET api/Author/5
        /// <summary>
        /// GET Method to retrive only one Author
        /// </summary>
        /// <param name="id">
        /// Author id to retrive
        /// </param>
        /// <returns>
        /// one element of type Author
        /// </returns>
        public IHttpActionResult GetAuthor(int id)
        {
            Author author = db.author.FirstOrDefault(b => b.authorID == id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
    }
}
