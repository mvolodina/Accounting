using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounting.DAO
{
    public class MaterialDAO : iDatabaseActions<Material>
    {

        public void insert(Material obj)
        {
            Database db = new Database();
            db.GetTable<Material>().InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void update(Material obj)
        {
            Database db = new Database();
            Material mat = db.GetTable<Material>().Single(x => x.Id_mat == obj.Id_mat);
            mat.Name = obj.Name;
            mat.Price = obj.Price;
            db.SubmitChanges();
        }

        public IEnumerable<Material> Select()
        {
            return (new Database().GetTable<Material>().ToArray());
        }

        public void delete(Material obj)
        {
            Database db = new Database();
            db.GetTable<Material>().DeleteOnSubmit(db.GetTable<Material>().Single(x => x.Id_mat == obj.Id_mat));
            db.SubmitChanges();
        }

        public Material Select(int id)
        {
            return (Single(x => x.Id_mat == id));
        }

        public Material Single(Func<Material, bool> predicate)
        {
            return (new Database().GetTable<Material>().Single(predicate));
        }

        public IEnumerable<Material> Select(Func<Material, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}