using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    [Table("BookClassification")]
    public class BookClass
    {
        [Key]
        public int classID { get; set; }

        public string className { get; set; }

        // Navigation property
        public IEnumerable<BookCategory> bookCategories { get; set; }
    }
}