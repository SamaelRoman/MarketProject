using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMarketProject.Models
{
    public class Product
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле \"Название продукта\" обязательно должно быть заполнено!")]
        [Display(Name = "Название продукта")]
        [StringLength(160, ErrorMessage = "Поле \"Название продукта\" должно содержать от 1го до 160ти символов!")]
        [MaxLength(160)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        [Display(Name = "Изображение продукта")]
        [DataType(DataType.ImageUrl)]
        public string Img { get; set; }
        [Required(ErrorMessage = "Поле \"Цена продукта\" обязательно должно быть заполнено!")]
        [Display(Name = "Цена продукта")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Display(Name = "Наличие продукта")]
        public bool Available { get; set; }
        
        public int? CategoryId{ get; set; }
        [Display(Name = "Категория продукта")]
        public Category Category { get; set; }

        public int? BrandId { get; set; }
        [Display(Name = "Бренд продукта")]
        public Brand Brand { get; set; }


    }
}