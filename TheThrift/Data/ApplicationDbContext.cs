using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheThrift.Models;

namespace TheThrift.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Expenses> Expensess { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<LoanRequest> LoanRequests { get; set; }
        public DbSet<LoanAllocation> LoanAllocations { get; set; } 
        public DbSet<Client> Clients { get; set; }
        public DbSet<TheThrift.Models.CustomerVM> CustomerVM { get; set; }
        public DbSet<TheThrift.Models.ClientVM> ClientVM { get; set; }

    }
}
