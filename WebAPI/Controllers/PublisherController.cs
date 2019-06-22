using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PublisherController : ApiController
    {
        private BookStoreDbContext db = new BookStoreDbContext();

        // GET api/Publisher
        /// <summary>
        /// GET Method to retrive all Publishers
        /// </summary>
        /// <returns>
        /// list of Publisher
        /// </returns>
        public IQueryable<Publisher> GetPublisher()
        {
            return db.publisher;
        }

        // GET api/Publisher/5
        /// <summary>
        /// GET Method to retrive only one Publisher
        /// </summary>
        /// <param name="id">
        /// Publisher id to retrive
        /// </param>
        /// <returns>
        /// one element of type Publisher
        /// </returns>
        public IHttpActionResult GetPublisher(int id)
        {
            Publisher publisher = db.publisher.FirstOrDefault(b => b.publisherID == id);
            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher);
        }

    }
}
