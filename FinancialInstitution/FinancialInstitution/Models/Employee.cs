using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinancialInstitution.Models
{
    public class Employee
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Введите отчество")]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        public string Branch { get; set; }
        public string Position { get; set; }

        [Required(ErrorMessage = "Выберите должность")]
        [Display(Name = "Должность")]
        public int PositionId { get; set; }

        [Required(ErrorMessage = "Выберите филиал")]
        [Display(Name = "Филиал")]
        public int BranchId { get; set; }

        [Required(ErrorMessage = "Некорректная дата")]
        [Display(Name = "Дата рождения")]
        public System.DateTime BirthDay { get; set; }

    }
}