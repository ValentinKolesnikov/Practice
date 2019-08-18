using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialInstitution.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите Имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Введите Фамилия")]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Введите Отчество")]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Введите Дату Рождения")]
        [Display(Name = "Дата рождения")]
        public System.DateTime BirthDay { get; set; }
        [Required(ErrorMessage = "Выберите Страну")]
        [Display(Name = "Страна")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Выберите Город")]
        [Display(Name = "Город")]
        public string City { get; set; }
        [Required(ErrorMessage = "Введите Улицу")]
        [Display(Name = "Улица")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Введите Серию и номер паспорта")]
        [Display(Name = "Серия и номер паспорта")]
        public string PassportSeriesAndNumber { get; set; }
        [RegularExpression(@"\b\d{4}-\d{4}-\d{4}-\d{4}", ErrorMessage = "Некорректный ввод")]
        [Display(Name = "Номер карты")]
        public string CardNumber { get; set; }
    }
}