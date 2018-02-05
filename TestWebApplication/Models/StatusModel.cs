using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Models
{
    public class StatusModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string NameStatus { get; set; }
    }
}