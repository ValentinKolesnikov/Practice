using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialInstitution.Models
{
    public class ServicesHistoryEdit
    {
        
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Выберите сотрудника")]
        [Display(Name = "Сотрудник")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Выберите услугу")]
        [Display(Name = "Услуга")]
        public int ServicesDirectoryId { get; set; }

        [Required(ErrorMessage = "Выберите филиал")]
        [Display(Name = "Филиал")]
        public int BranchId { get; set; }

        public int ClientId { get; set; }

        public int Id { get; set; }
    }
}