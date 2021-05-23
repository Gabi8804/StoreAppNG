using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.DataAccess
{
    public class GenericRepository<T> : IDbRepository<T> where T:class
    {
        private readonly SmartStoreDBContext db;
        public DbSet<T> table = null;
       
        public GenericRepository()
        {
            db = new SmartStoreDBContext();
            table = db.Set<T>();
        }
        public void Create(T entity)
        {
            table.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = table.Find(id);
            table.Remove(product);
            db.SaveChanges();
        }

        public List<T> ReadAll()
        {
            return table.ToList();
        }

        public T ReadById(int id)
        {
            return table.Find(id);
        }

        public void Update(T entity)
        {
            var entry = db.Entry(entity);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
        
    }

}
