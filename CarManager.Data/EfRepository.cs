using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Data;

namespace CarManager.Data
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext dbContext;

        private IDbSet<T> dbSet;

        protected virtual IDbSet<T> DbSet
        {
            get
            {
                this.dbSet = this.dbSet ?? dbContext.Set<T>();
                return this.dbSet;
            }
        }

        public EfRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }
            this.dbSet.Remove(entity);
            return this.dbContext.SaveChanges();
        }

        public IQueryable<T> Table
        {
            get { return this.DbSet; }
        }

        public int Add(T entity)
        {
            this.DbSet.Add(entity);
            return this.dbContext.SaveChanges();
        }

        public int Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }
            return this.dbContext.SaveChanges();
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public int Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }
            this.DbSet.Add(entity);

            return this.dbContext.SaveChanges();
        }


    }
}
