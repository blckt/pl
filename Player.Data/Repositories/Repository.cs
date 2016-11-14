using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Player.Contracts;

namespace Player.Data.Repositories
{
    public class Repository<T> : IReadWriteRepository<T> where T : class, IEntity
    {
        private DbContext context;
        private readonly DbSet<T> entites;
        public Repository(DbContext context)
        {
            this.context = context;
            this.entites = context.Set<T>();
        }

        public void Add(T entity)
        {
            this.entites.Add(entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this.entites.Where(expression);
        }

        public IQueryable<T> GetAll()
        {
            return this.entites;
        }

        public T GetByKey(params object[] key)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            this.entites.Remove(entity);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
