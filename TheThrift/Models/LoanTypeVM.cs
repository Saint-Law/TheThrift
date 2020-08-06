using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheThrift.Models
{
    public class LoanTypeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Default Numbers of Time")]
        public int DefaultDays { get; set; }
        [Display(Name="Date Created")]
        public DateTime DateCreated { get; set; }
    }
}
