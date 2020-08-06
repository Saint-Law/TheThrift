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
        public bool Create(LoanAllocation entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(LoanAllocation entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<LoanAllocation> FindAll()
        {
            throw new NotImplementedException();
        }

        public LoanAllocation FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(LoanAllocation entity)
        {
            throw new NotImplementedException();
        }
    }
}
