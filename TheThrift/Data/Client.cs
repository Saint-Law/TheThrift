using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheThrift.Data
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AccountNo { get; set; }
        public int ThriftPlan { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Display(Name = "Office Address")]
        public string OfficeAddress { get; set; }
        public string ShopNo { get; set; }
        public string Contact { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateRegistered { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
    }
}
