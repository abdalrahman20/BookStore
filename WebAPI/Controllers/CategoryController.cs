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
    public class CategoryController : ApiController
    {
        private BookStoreDbContext db = new BookStoreDbContext();

        // GET api/Category
        /// <summary>
        /// GET Method to retrive all Book Categories
        /// </summary>
        /// <returns>
        /// list of Category
        /// </returns>
        public IQueryable<BookCategory> GetbookCategory()
        {
            return db.bookCategory;
        }

        // GET api/Category/5
        /// <summary>
        /// GET Method to retrive only one Book Category
        /// </summary>
        /// <param name="id">
        /// category id to retrive
        /// </param>
        /// <returns>
        /// one element of type BookCategory
        /// </returns>
        public IHttpActionResult GetbookCategory(int id)
        {
            BookCategory category = db.bookCategory.FirstOrDefault(b => b.cateID == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}