using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TestWebApplication.Models
{
    public class Product    //класс продуктов
    {
        
        [Required]
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        [Required]
        public string Name { get; set; }
        public string Brand { get; set; }
        [Required]
        public Category Category { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        //public Product()
        //{
        //}
        //public Product(string name, string description, Category category, double price, string brand = null, byte[] image = null)
        //{
        //    Image = image;
        //    Name = name;
        //    Brand = brand;
        //    Category = category;
        //    Price = price;
        //    Description = description;
        //}
    }
}
