using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BookStore.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int bookID { get; set; }

        public string title { get; set; }

        public int price { get; set; }

        public string Genre { get; set; }

        // foreign Keys
        public int cateID { get; set; }

        public int authorID { get; set; }

        public int publisherID { get; set; }


        // Navigation property
        public BookCategory bookCategory { get; set; }

        public Author author { get; set; }

        public Publisher publisher { get; set; }

        public IEnumerable<Customer> customers { get; set; }
    }
}
