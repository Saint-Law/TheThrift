using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheThrift.Contracts;
using TheThrift.Data;

namespace TheThrift.Repository
{
    public class LoanRequestRepository : ILoanRequestRepository
    {
        private readonly ApplicationDbContext _db;
        public LoanRequestRepository(ApplicationDbContext db)
        {
            _db = db; 
        }
        public bool Create(LoanRequest entity)
        {
            _db.LoanRequests.Add(entity);
            return Save();
        }

        public bool Delete(LoanRequest entity)
        {
            _db.LoanRequests.Remove(entity);
            return Save();
        }

        public ICollection<LoanRequest> FindAll()
        {
            var requests = _db.LoanRequests
                .Include(r => r.RequestingEmployee)
                .Include(r => r.ApprovedBy)
                .Include(r => r.LoanType)
                .ToList();
            return requests;
        }

        public LoanRequest FindById(int id)
        {
            var requests = _db.LoanRequests
                .Include(r => r.RequestingEmployee)
                .Include(r => r.ApprovedBy)
                .Include(r => r.LoanType)
                .FirstOrDefault( r => r.Id==id);
            return requests;
        }

        public bool isExist(int id)
        {
            var exists = _db.LoanTypes.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var exist = _db.SaveChanges();
            return exist > 0;
        }

        public bool Update(LoanRequest entity)
        {
            _db.LoanRequests.Update(entity);
            return Save();
        }
    }
}
