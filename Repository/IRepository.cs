using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
   public interface IRepository<T>
    {
        IList<T> list();
        T Find(int id);
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);

    }
}
