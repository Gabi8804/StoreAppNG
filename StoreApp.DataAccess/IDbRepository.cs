using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess
{
    public interface IDbRepository<T> where T: class
    {
        void Create(T entity);
        List<T> ReadAll();
        T ReadById(int id);
        void Delete(int id);
        void Update(T entity);
    }
}
