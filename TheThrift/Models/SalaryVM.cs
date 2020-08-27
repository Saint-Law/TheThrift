using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheThrift.Models
{
    public class SalaryVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Staff Name")]
        public string StaffName { get; set; }
        [Required]
        public int Amount { get; set; }
        [Display(Name = "Salary Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
