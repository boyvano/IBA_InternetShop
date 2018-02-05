using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApplication.Models
{
    public class Category //Наш Граф
    {
        [Required]
        [Key]
        public int Id { get;  set; }
        public List<Category> Parents { get;  set; }
        public List<Category> Children { get;  set; }
        public List<Product> Products { get; set; }
        [Required]
        public string Name { get; set; }        
    }
}
