using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.DataAccess.Interfaces;
using TimeTracking.Domain.Models;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.Services.Implementation
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : BaseEntity
    {
        private IGenericDb<T> _db;
        public List<T> GetAll()
        {
            return _db.GetAll();
        }

        public T GetById(int id)
        {
            return _db.GetById(id);
        }

        public List<T> GetFiltered(Func<T, bool> predicate)
        {
            return _db.FilterBy(predicate);
        }

        public void Insert(T entity)
        {
            _db.Add(entity);
        }

        public bool Update(T entity)
        {
            _db.Update(entity);
            return true;
        }
        public void RemoveById(int id)
        {
            _db.RemoveById(id);
        }
        public bool Exists(int id)
        {
            return _db.Exists(id);
        }
        public void Seed(List<T> entities)
        {
            if (_db.GetAll().Count > 0)
            {
                return;
            }
            foreach (var entity in entities)
            {
                if (!_db.Exists(entity.Id))
                {
                    _db.Add(entity);
                }
            }
        }
    }
}
