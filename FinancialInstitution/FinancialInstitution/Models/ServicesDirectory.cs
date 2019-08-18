using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialInstitution.Models
{
    public class ServicesDirectory
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите наименование")]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

 
    }
}