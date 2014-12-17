using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DAO
{
    interface iDatabaseActions<T>
    {
        void insert(T obj);
        void update(T obj);
        IEnumerable<T> Select();
        void delete(T obj);

        T Select(int id);
        T Single(Func<T,bool> predicate);

        IEnumerable<T> Select(Func<T, bool> predicate);
    }
}
