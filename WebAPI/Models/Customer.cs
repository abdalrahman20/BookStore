using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WebAPI.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int custID { get; set; }

        public string custName { get; set; }

        public string phone { get; set; }

        // Navigation property
        public IEnumerable<Book> Books { get; set; }
    }
}
