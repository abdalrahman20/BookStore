using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WebAPI.Models
{
    [Table("BookCategory")]
    public class BookCategory
    {
        [Key]
        public int cateID { get; set; }

        public string cateName { get; set; }

        // Navigation property
        public BookClass bookClass { get; set; }

        public IEnumerable<Book> books { get; set; }
    }
}
