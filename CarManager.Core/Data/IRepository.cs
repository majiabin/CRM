using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.Data
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
