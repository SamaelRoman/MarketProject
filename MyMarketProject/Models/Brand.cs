using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMarketProject.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле \"Название бренда\" обязательно должно быть заполнено!")]
        [DataType(DataType.Text)]
        [MaxLength(25, ErrorMessage = "Поле \"Название бренда\" должно содержать от 1го до 25ти символов")]
        [StringLength(25)]
        [Display(Name = "Название бренда")]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public Brand()
        {
            Categories = new List<Category>();
        }
    }
}