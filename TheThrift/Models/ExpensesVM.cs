using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheThrift.Models
{
    public class ExpensesVM
    {
        public int Id { get; set; }
        [Display(Name = "Expenses Type")]
        public string ExpensesType { get; set; }
        public int Amount { get; set; }
        public string Descriptions { get; set; }
        [Display(Name = "Date Of Expenses")]
        public DateTime DateOfExpenses { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
    }
}
