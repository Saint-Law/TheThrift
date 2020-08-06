using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheThrift.Contracts;
using TheThrift.Data;

namespace TheThrift.Repository
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly ApplicationDbContext _db;
        public SalaryRepository(ApplicationDbContext db)
        {
            _db = db; 
        }
        public bool Create(Salary entity)
        {
            _db.Salaries.Add(entity);
            return Save();
        }

        public bool Delete(Salary entity)
        {
            _db.Salaries.Remove(entity);
            return Save();
        }

        public ICollection<Salary> FindAll()
        {
            var Salary = _db.Salaries.ToList();
            return Salary;
        }

        public Salary FindById(int id)
        {
            var Salary = _db.Salaries.Find(id);
            return Salary;
        }

        public bool isExist(int id)
        {
            var exists = _db.Salaries.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Salary entity)
        {
            _db.Salaries.Update(entity);
            return Save();
        }
    }
}
