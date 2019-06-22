using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{


    public class BookStoreDbContext : DbContext
    {
        public virtual DbSet<BookClass> bookClass { get; set; }

        public virtual DbSet<BookCategory> bookCategory { get; set; }

        public virtual DbSet<Book> book { get; set; }

        public virtual DbSet<Author> author { get; set; }

        public virtual DbSet<Publisher> publisher { get; set; }

        public virtual DbSet<Customer> customer { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
    }
}