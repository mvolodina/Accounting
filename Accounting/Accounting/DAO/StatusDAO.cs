using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounting.DAO
{
    public class StatusDAO : iDatabaseActions<Status>
    {
    

        public void insert(Status obj)
        {
            throw new NotImplementedException();
        }

        public void update(Status obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Status> Select()
        {
            throw new NotImplementedException();
        }

        public void delete(Status obj)
        {
            throw new NotImplementedException();
        }

        public Status Select(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Status> Select(Func<Status, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Status Single(Func<Status, bool> predicate)
        {
            return new Database().GetTable<Status>().Single(predicate);
        }
    }
}