using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounting.DAO
{
    public class OrdersDAO : iDatabaseActions<Orders>
    {
        public void insert(Orders obj)
        {
            
            Database db = new Database();
            obj.Status = new StatusDAO().Single(x => x._name == "Оформлен").Id;
            db.GetTable<Orders>().InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void update(Orders obj)
        {
            Database db = new Database();
            foreach (Orders item in db.GetTable<Orders>().ToArray().Where(ord => ord.Id_ord == obj.Id_ord))
            {
              
                item.Number = obj.Number;
                item.Status = obj.Status;
                item.FK_Mat1 = obj.FK_Mat1;
                item.FK_Sup = obj.FK_Sup;
            }
            db.SubmitChanges();
        }

        public IEnumerable<Orders> Select()
        {
            Database db = new Database();
            return (db.GetTable<Orders>().ToArray());
        }

        public void delete(Orders obj)
        {
            Database db = new Database();
            StatusDAO sdao = new StatusDAO();
            int status_id = sdao.Single(s => s._name == "Удален").Id;
            db.GetTable<Orders>().Single(ord => ord.Id_ord == obj.Id_ord).Status = status_id;
            db.SubmitChanges();
        }


        public Orders Select(int id)
        {
            return (new Database().GetTable<Orders>().Single(obj => obj.Id_ord == id));
        }


        public Orders Single(Func<Orders, bool> predicate)
        {
            return (new Database().GetTable<Orders>().Single(predicate));
        }

        public IEnumerable<Orders> Select(Func<Orders, bool> predicate)
        {
            return (new Database().GetTable<Orders>().Where(predicate));
        }
    }
}