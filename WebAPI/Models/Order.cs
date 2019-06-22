using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Order
    {
        [Key, Column(Order = 1)]
        public int bookID { get; set; }

        [Key, Column(Order = 2)]
        public int customerID { get; set; }

        // Navigation property
        public Book book { get; set; }

        public Customer customer { get; set; }
    }
}