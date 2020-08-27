using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheThrift.Contracts;
using TheThrift.Data;

namespace TheThrift.Repository
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly ApplicationDbContext _db;
        public ExpensesRepository(ApplicationDbContext db)
        {
            _db = db; 
        }
        public bool Create(Expenses entity)
        {
            _db.Expensess.Add(entity);
            return Save();
        }

        public bool Delete(Expenses entity)
        {
            _db.Expensess.Remove(entity);
            return Save();
        }

        public ICollection<Expenses> FindAll()
        {
            var Expenses = _db.Expensess.ToList();
            return Expenses;
        }

        public Expenses FindById(int id)
        {
            var Expenses = _db.Expensess.Find(id);
            return Expenses;
        }

        public bool isExist(int id)
        {
            var exists = _db.Expensess.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Expenses entity)
        {
            _db.Expensess.Update(entity);
            return Save();
        }
    }
}
