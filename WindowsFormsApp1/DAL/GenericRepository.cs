using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model.Context;

namespace WindowsFormsApp1.DAL
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private OtoContext _otoContext;
        public GenericRepository(OtoContext otoContext)
        {
            _otoContext = otoContext;
        }

        public IQueryable<T> GetAll()
        {
            return _otoContext.Set<T>().AsNoTracking();
        }

        public T GetById(int id)
        {
            return _otoContext.Set<T>().Find(id);
        }

        public T Create(T entity)
        {
            _otoContext.Set<T>().Add(entity);
            _otoContext.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _otoContext.Set<T>().Remove(entity);
            _otoContext.SaveChanges();
        }

        public T Update(T entity, int id)
        {
            if (entity == null)
                return null;

            T existing = _otoContext.Set<T>().Find(id);
            if (existing != null)
            {
                //_otoContext.Entry(existing).CurrentValues.SetValues(entity);
                _otoContext.Entry(existing).CurrentValues.SetValues(entity);
                _otoContext.SaveChanges();
            }
            return existing;
        }
    }
}
