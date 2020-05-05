using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DAL
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        T Create(T entity);

        T Update(T entity, int id);

        void Delete(T entity);
    }
}
