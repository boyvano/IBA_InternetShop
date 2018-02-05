using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestWebApplication.Models
{
    // Модель Заявка
    public class Request
    {
        [Required]
        [Key]
        // ID 
        public int Id { get; set; }
        // Статус заявки
        [Display(Name = "Статус")]
        [Required]
        public StatusModel Status { get; set; }
        [Required]
        // ID Пользователя
        public ApplicationUser User { get; set; }
        [Required]
        // ID Продукта 
        [Display(Name = "Товар")]
        public Product Product { get; set; }
        [Required]
        // Количество продукта 
        [Display(Name = "Количество")]
        public int ProductCount { get; set; }

        //Итоговая Цена
        [Display(Name = "Общая стоимость")]
        public double TotalPrice()
        {
            return (Product.Price * ProductCount);
        }
    }
}