using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebApplication.Models
{
    public class Cart
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        public List<Request> RequestList { get; set; }

    }
}