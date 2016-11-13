using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Player.Contracts
{
    public interface IReadOnlyRepository<T>
    {
        T GetByKey(params object[] key);

        IQueryable<T> GetAll();

        IQueryable<T> Find(Expression<Func<T, bool>> expression);
    }
}
