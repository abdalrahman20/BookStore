using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    [Table("Author")]
    public class Author
    {
        [Key]
        public int authorID { get; set; }
        
        public string authorName { get; set; }

        // Navigation property
        public IEnumerable<Book> books { get; set; }
    }
}