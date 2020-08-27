using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheThrift.Models
{
    public class ClientVM
    {
        public int Id { get; set; }
        [Display(Name = "Account No")]
        public string AccountNo { get; set; }
        [Display(Name = "Thrift Plan")]
        public int ThriftPlan { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Display(Name = "Office Address")]
        public string OfficeAddress { get; set; }
        [Display(Name = "Shop No")]
        public string ShopNo { get; set; }
        [Display(Name = "Phone Number")]
        public string Contact { get; set; }
        [Display(Name = "Date Registered")]
        [DataType(DataType.Date)]
        public DateTime DateRegistered { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
    }
}
