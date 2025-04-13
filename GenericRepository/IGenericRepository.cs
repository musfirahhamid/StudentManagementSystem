using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.GenericRepository
    {
        public interface IGenericRepository<T> where T : class
            {
            IEnumerable<T> GetAll();
            IQueryable<T> GetAllActive();
            IQueryable<T> GetAllDeleted();
            T GetById(object id);
            void Insert(T obj);
            void Update(T obj);
            void Delete(object id);
            void Restore(object id);
            void Save();
            }
    }
