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
            throw new NotImplementedException();
        }

        public bool Delete(LoanRequest entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<LoanRequest> FindAll()
        {
            throw new NotImplementedException();
        }

        public LoanRequest FindById(int id)
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

        public bool Update(LoanRequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
