using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheThrift.Data
{
    public class LoanRequest
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RequestingEmployeeId")]
        public Employee RequestingEmployee { get; set; }
        public string RequestingEmployeeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("LeaveTypeId")]
        public LoanType LoanType { get; set; }
        public int LoanTypeId { get; set; } 
        [DataType(DataType.Date)]
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public bool Cancelled { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        [ForeignKey("ApprovedById")]
        public Employee ApprovedBy { get; set; }
        public string ApprovedById { get; set; }
    }
}
