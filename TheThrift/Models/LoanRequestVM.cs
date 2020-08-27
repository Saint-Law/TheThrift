using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheThrift.Models
{
    public class LoanRequestVM
    {

        public int Id { get; set; }
        public EmployeeVM RequestingEmployee { get; set; }
        [Display(Name ="Employee Name")]
        public string RequestingEmployeeId { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime EndDate { get; set; }
        //this was used to bring the table 
        public LoanTypeVM LoanType { get; set; }
        public int LoanTypeId { get; set; }

        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }
        [Display(Name = "Date Actioned")]
        public DateTime DateActioned { get; set; }
        [Display(Name = "Approval State")]
        public bool? Approved { get; set; }
        public EmployeeVM ApprovedBy { get; set; }
        [Display(Name = "Approver Name")]
        public string ApprovedById { get; set; }
        public bool Cancelled { get; set; }
        [Display(Name = "Employee Comments")]
        [MaxLength(300)]
        public string RequestComments { get; set; }        
    }

    public class AdminLoanRequestViewVM
    {
        [Display(Name = "Total Number of Requests")]
        public int TotalRequests { get; set; }
        [Display(Name = "Approved Requests")]
        public int ApprovedRequests { get; set; }
        [Display(Name = "Pending Requests")]
        public int PendingRequests { get; set; }
        [Display(Name = "Rejected Requests")]
        public int RejectedRequests { get; set; }
        public List<LoanRequestVM> LoanRequests { get; set; }
    }

    public class CreateLoanRequestVM
    {
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime EndDate { get; set; }

        //this is for the dropdown 
        public IEnumerable<SelectListItem> LoanTypes { get; set; }
        [Display(Name ="Loan Type")]
        public int LoanTypeId { get; set; }
        [Display(Name = "Comments")]
        [MaxLength(300)]
        public string RequestComments { get; set; }
    }
}
