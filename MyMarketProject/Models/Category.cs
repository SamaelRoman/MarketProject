using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMarketProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле \"Название категории\" обязательно должно быть заполнено!")]
        [DataType(DataType.Text)]
        [MaxLength(25,ErrorMessage = "Поле \"Название категории\" должно содержать от 1го до 25ти символов")]
        [StringLength(25)]
        [Display(Name = "Название категории")]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public virtual ICollection<Brand> Brands{ get; set; }
        public Category()
        {
            Brands = new List<Brand>();
        }


    }
}