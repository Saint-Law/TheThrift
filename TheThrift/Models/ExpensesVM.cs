using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TheThrift.Data;

namespace TheThrift.Models
{
    public class ExpensesVM
    {
        public int Id { get; set; }
        public string ExpensesType { get; set; }
        [Required]
        public int Amount { get; set; } 
        [MaxLength(300)]
        public string Descriptions { get; set; }
        [Display(Name = "Date Of Expenses")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfExpenses { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; } 
    }    
    
}
