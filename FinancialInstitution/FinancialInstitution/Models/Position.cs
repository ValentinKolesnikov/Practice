using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinancialInstitution.Models
{
    public class Position
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название должности")]
        [Display(Name = "Название должности")]
        public string Name { get; set; }

        [Display(Name = "Работа с клиентами")]
        public bool Flag { get; set; }

    }
}