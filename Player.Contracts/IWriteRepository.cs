using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Contracts
{
    public interface IWriteRepository<in T>
    {
        void Add(T entity);

        void Remove(T entity);

        void Save();
    }
}
