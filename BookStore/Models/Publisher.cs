using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    [Table("Publisher")]
    public class Publisher
    {
        [Key]
        public int publisherID { get; set; }

        public string publisherName { get; set; }

        // Navigation property
        public IEnumerable<Book> books { get; set; }
    }
}