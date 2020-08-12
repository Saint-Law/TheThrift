using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheThrift.Contracts;
using TheThrift.Data;

namespace TheThrift.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _db;
        public ClientRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Client entity)
        {
            _db.Clients.Add(entity);
            return Save();
        }

        public bool Delete(Client entity)
        {
            _db.Clients.Remove(entity);
            return Save();
        }

        public ICollection<Client> FindAll()
        {
            var customer = _db.Clients.ToList();
            return customer;
        }

        public Client FindById(int id)
        {
            var customer = _db.Clients.Find(id);
            return customer;
        }

        public bool isExist(int id)
        {
            var exists = _db.Clients.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Client entity)
        {
            _db.Clients.Update(entity);
            return Save();
        }
    }
}
