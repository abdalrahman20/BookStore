using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using System.Net.Http;
using System.Net;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Book> List = new List<Book>();
            GlobalFunction.retraiveAll(out List, "Book");

            return View(List);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Book book;
            GlobalFunction.retraiveOne(out book, "Book/" + id);
            return View(book);
        }

        [HttpGet]
        public ActionResult Create()
        {
            IEnumerable<BookCategory> CategoryList = new List<BookCategory>();
            IEnumerable<Author> authorList = new List<Author>();
            IEnumerable<Publisher> publisherList = new List<Publisher>();

            GlobalFunction.retraiveAll(out CategoryList, "Category");
            GlobalFunction.retraiveAll(out authorList, "Author");
            GlobalFunction.retraiveAll(out publisherList, "Publisher");

            ViewBag.BookCate = CategoryList;
            ViewBag.author = authorList;
            ViewBag.publisher = publisherList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book obj)
        {
            BookCategory b;
            Author a;
            Publisher p;
            GlobalFunction.retraiveOne(out b, "Category/" + obj.cateID);
            GlobalFunction.retraiveOne(out a, "Author/" + obj.authorID);
            GlobalFunction.retraiveOne(out p, "Publisher/" + obj.publisherID);
            obj.bookCategory = b; obj.author = a; obj.publisher = p;
            if (!GlobalFunction.PostMethod(obj, "Book"))
            {
                return HttpNotFound();
            }
            return Redirect("~");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Book book;
            GlobalFunction.retraiveOne(out book, "Book/" + id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            GlobalFunction.PutMethod(ref book, "Book");
            return Redirect("~");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book;
            GlobalFunction.retraiveOne(out book, "Book/" + id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Book book;
            GlobalFunction.DeleteMethod(out book, "Book/" + id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return Redirect("~");
        }
    }
}