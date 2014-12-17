using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounting.DAO
{
    public class UserInRolesDAO : iDatabaseActions<AspNetUserRoles>
    {
        public void insert(AspNetUserRoles obj)
        {
            Userbase db = new Userbase();
            db.GetTable<AspNetUserRoles>().InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void update(AspNetUserRoles obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AspNetUserRoles> Select()
        {
            throw new NotImplementedException();
        }

        public void delete(AspNetUserRoles obj)
        {
            throw new NotImplementedException();
        }

        public AspNetUserRoles Select(int id)
        {
            throw new NotImplementedException();
        }

        public AspNetUserRoles Single(Func<AspNetUserRoles, bool> predicate)
        {
            return (new Userbase().GetTable<AspNetUserRoles>().Single(predicate));
        }
        

        public IEnumerable<AspNetUserRoles> Select(Func<AspNetUserRoles, bool> predicate)
        {
            return (new Userbase().GetTable<AspNetUserRoles>().Where(predicate).ToArray());
        }

        public object Select(string p)
        {
            throw new NotImplementedException();
        }
    }
}