using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheThrift.Contracts;
using TheThrift.Data;

namespace TheThrift.Repository
{
    public class LoanAllocationRepository : ILoanAllocationRepository
    {
        private readonly ApplicationDbContext _db;
        public LoanAllocationRepository(ApplicationDbContext db)
        {
            _db = db; 
        }

        public bool CheckAllocation(int loantypeid, string employeeid)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .Where(q => q.EmployeeId == employeeid 
                        && q.LoanTypeId == loantypeid && q.Period == period)
                .Any();
        }

        public bool Create(LoanAllocation entity)
        {
            _db.LoanAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LoanAllocation entity)
        {
            _db.LoanAllocations.Remove(entity);
            return Save();
        }

        public ICollection<LoanAllocation> FindAll()
        {
            var loanAllocations = _db.LoanAllocations
                .Include(r => r.LoanType)
                .Include(s => s.Employee)
                .ToList();
            return loanAllocations;
        }

        public LoanAllocation FindById(int id)
        {
            var loanAllocations = _db.LoanAllocations
                .Include(r => r.LoanType)
                .Include(s => s.Employee)
                .FirstOrDefault(q => q.Id == id);
            return loanAllocations;
        }

        public ICollection<LoanAllocation> GetLoanAllocationByEmployee(string id)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .Where(q => q.EmployeeId == id && q.Period == period)
                .ToList();
        }

        public LoanAllocation GetLoanAllocationByEmployeeAndType(string id, int loantypeid)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .FirstOrDefault(q => q.EmployeeId == id && q.Period == period && q.LoanTypeId == loantypeid);
        }

        public bool isExist(int id)
        {
            var exists = _db.LoanAllocations.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LoanAllocation entity)
        {
            _db.LoanAllocations.Update(entity);
            return Save();
        }
    }
}
