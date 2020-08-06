using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheThrift.Data
{
    public class Expenses
    {
        public int Id { get; set; }
        public string ExpensesType { get; set; }
        public int Amount { get; set; }
        public string Descriptions { get; set; }
        public DateTime DateOfExpenses { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
