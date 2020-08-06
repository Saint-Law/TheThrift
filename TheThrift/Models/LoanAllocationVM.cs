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
        public LoanTypeVM LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public IEnumerable<SelectListItem> Employees { get; set; }
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
    }

    public class CreateLeaveAllocationVM
    {
        public int NumberUpdated { get; set; }
        public List<LoanTypeVM> LeaveTypes { get; set; }
    }

    public class EditLeaveAllocationVM
    {
        public int Id { get; set; }
        public EmployeeVM Employee { get; set; }
        public string EmployeeId { get; set; }
        [Display(Name = "Number Of Days")]
        public int NumberofDays { get; set; }
        public LoanTypeVM LeaveType { get; set; }
    }

    public class ViewAllocationVM
    {
        public EmployeeVM Employee { get; set; }
        public string EmployeeId { get; set; }
        public List<LoanAllocaitionVM> LeaveAllocaitions { get; set; }
    }
}
