using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheThrift.Contracts;
using TheThrift.Data;

namespace TheThrift.Repository
{
    public class LoanTypeRepository : ILoanTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public LoanTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LoanType entity)
        {
            _db.LoanTypes.Add(entity);
            return Save();
        }

        public bool Delete(LoanType entity)
        {
            _db.LoanTypes.Remove(entity);
            return Save();
        }

        public ICollection<LoanType> FindAll()
        {
            var loanTypes = _db.LoanTypes.ToList();
            return loanTypes;
        }

        public LoanType FindById(int id)
        {
            var loanTypes = _db.LoanTypes.Find(id);
            return loanTypes;
        }

        public ICollection<LoanType> GetEmployeeIdByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(int id)
        {
            var exists = _db.LoanTypes.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LoanType entity)
        {
            _db.LoanTypes.Update(entity);
            return Save();
        }
    }
}
