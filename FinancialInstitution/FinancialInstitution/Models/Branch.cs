using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialInstitution.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Введите Имя")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите Страну")]
        [Display(Name = "Страна")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Введите Город")]
        [Display(Name = "Город")]
        public string City { get; set; }
        [Required(ErrorMessage = "Введите Улицу")]
        [Display(Name = "Улица")]
        public string Street { get; set; }
    }
}