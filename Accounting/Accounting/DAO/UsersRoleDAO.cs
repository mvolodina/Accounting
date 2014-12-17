using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounting.DAO
{
    public class UsersRoleDAO : iDatabaseActions<AspNetRoles>
    {
        public void insert(AspNetRoles obj)
        {
            throw new NotImplementedException();
        }

        public void update(AspNetRoles obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AspNetRoles> Select()
        {
            return (new Userbase().GetTable<AspNetRoles>().ToArray());
        }

        public void delete(AspNetRoles obj)
        {
            throw new NotImplementedException();
        }

        public AspNetRoles Select(int id)
        {
            throw new NotImplementedException();
        }

        public AspNetRoles Single(Func<AspNetRoles, bool> predicate)
        {
            return (new Userbase().GetTable<AspNetRoles>().Single(predicate));
        }

        public IEnumerable<AspNetRoles> Select(Func<AspNetRoles, bool> predicate)
        {
            throw new NotImplementedException();
        }

        internal List<AspNetRoles> Select(IEnumerable<AspNetUserRoles> enumerable)
        {
            List<AspNetRoles> role_list = new List<AspNetRoles>();
            foreach(AspNetUserRoles obj in enumerable){
                role_list.Add(new Userbase().GetTable<AspNetRoles>().Single(x => x.Id == obj.RoleId));
            }
            return (role_list);
        }
    }
}