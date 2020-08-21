using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheThrift.Data
{
    public class LoanAllocation
    {
        [Key]
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public LoanType LoanType { get; set; }

        [ForeignKey("LoanTypeId")]
        public int LoanTypeId { get; set; }
        public int Period { get; set; }
    }
}
