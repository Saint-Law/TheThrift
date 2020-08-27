using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheThrift.Models
{
    public class LoanAllocaitionVM
    {
        public int Id { get; set; }
        [Display(Name = "Number of Days")]
        public int NumberOfDays { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        public EmployeeVM Employee { get; set; }
        public string EmployeeId { get; set; }
        public int Period { get; set; }
        public LoanTypeVM LoanType { get; set; }
        public int LoanTypeId { get; set; }

    }

    public class CreateLoanAllocationVM
    {
        public int NumberUpdated { get; set; } 
        public List<LoanTypeVM> LoanTypes { get; set; }
    }

    public class EditLoanAllocationVM
    {
        public int Id { get; set; }
        public EmployeeVM Employee { get; set; }
        public string EmployeeId { get; set; }
        [Display(Name = "Number Of Days")]
        public int NumberofDays { get; set; }
        public LoanTypeVM LoanType { get; set; } 
    }

    public class ViewLoanAllocationVM
    {
        public EmployeeVM Employee { get; set; }
        public string EmployeeId { get; set; }
        public List<LoanAllocaitionVM> LoanAllocations { get; set; } 
    }
}
