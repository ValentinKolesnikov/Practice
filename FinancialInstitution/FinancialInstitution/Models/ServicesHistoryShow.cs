using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialInstitution.Models
{
    public class ServicesHistoryShow
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Employee Employee { get; set; }

        public string ServicesDirectoryName { get; set; }

    }
}