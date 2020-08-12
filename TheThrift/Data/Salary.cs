using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheThrift.Data
{
    public class Salary
    {
        public int Id { get; set; }
        public string StaffName { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
    }
}
