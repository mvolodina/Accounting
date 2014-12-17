using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Accounting.DAO
{
    public class SupplierDAO : iDatabaseActions<Supplier>
    {
        Database db;

        public SupplierDAO()
        {
            db = new Database();
        }
        public void insert(Supplier obj)
        {
            db.GetTable<Supplier>().InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void update(Supplier obj)
        {
            var tab = from data in db.GetTable<Supplier>() where data.Id_sup == obj.Id_sup select data;
            foreach (Supplier sup in tab)
            {
                sup.Address = obj.Address;
                sup.E_mail = sup.E_mail;
                sup.Name = obj.Name;
                sup.Orders = sup.Orders;
                sup.Phone = sup.Phone;
            }
            db.SubmitChanges();
        }

        public IEnumerable<Supplier> Select()
        {
            return (new Database().GetTable<Supplier>().ToArray());
        }

        public void delete(Supplier obj)
        {
            throw new NotImplementedException();
        }


        public Supplier Select(int id)
        {
            return (db.GetTable<Supplier>().Single(obj => obj.Id_sup == id));
        }


        public Supplier Single(Func<Supplier, bool> predicate)
        {
            return (db.GetTable<Supplier>().Single(predicate));
        }

        public IEnumerable<Supplier> Select(Func<Supplier, bool> predicate)
        {
            throw new NotImplementedException();
        }

    }
}