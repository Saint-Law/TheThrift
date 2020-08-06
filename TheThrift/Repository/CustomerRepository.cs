using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheThrift.Contracts;
using TheThrift.Data;

namespace TheThrift.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Customer entity)
        {
            _db.Customers.Add(entity);
            return Save();
        }

        public bool Delete(Customer entity)
        {
            _db.Customers.Remove(entity);
            return Save();
        }

        public ICollection<Customer> FindAll()
        {
            var customer = _db.Customers.ToList();
            return customer;
        }

        public Customer FindById(int id)
        {
            var customer = _db.Customers.Find(id);
            return customer;
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

        public bool Update(Customer entity)
        {
            _db.Customers.Update(entity);
            return Save();
        }
    }
}
