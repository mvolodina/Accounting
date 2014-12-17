using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounting.DAO
{
    public class UsersDAO : iDatabaseActions<AspNetUsers>
    {
        public void insert(AspNetUsers obj)
        {
            throw new NotImplementedException();
        }

        public void update(AspNetUsers obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AspNetUsers> Select()
        {
            return (new Userbase().GetTable<AspNetUsers>().ToArray());
        }

        public void delete(AspNetUsers obj)
        {
            throw new NotImplementedException();
        }

        public AspNetUsers Select(int id)
        {
            throw new NotImplementedException();
        }

        public AspNetUsers Single(Func<AspNetUsers, bool> predicate)
        {
            return (new Userbase().GetTable<AspNetUsers>().Single(predicate));
        }

        public IEnumerable<AspNetUsers> Select(Func<AspNetUsers, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}