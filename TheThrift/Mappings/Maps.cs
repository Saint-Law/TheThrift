using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheThrift.Data;
using TheThrift.Models;

namespace TheThrift.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<Expenses, ExpensesVM>().ReverseMap();
            CreateMap<Salary, SalaryVM>().ReverseMap();
            CreateMap<LoanType, LoanTypeVM>().ReverseMap();
            CreateMap<LoanRequest, LoanRequestVM>().ReverseMap();
            CreateMap<LoanAllocation, LoanAllocaitionVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
        }
    }
}
