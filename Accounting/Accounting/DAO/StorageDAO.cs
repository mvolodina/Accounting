using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounting.DAO
{
    public class StorageDAO : iDatabaseActions<Storage>
    {

        public void insert(Storage obj)
        {
            Database db = new Database();
            db.GetTable<Storage>().InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void reduceCount(Storage obj)
        {
           
            Storage add = this.Single(x => x.FK_mat == obj.FK_mat);
            if (add == null)
            {
                add = new Storage()
                {
                    FK_mat = obj.FK_mat,
                    Number = obj.Number
                };
                this.insert(add);
            }
            else
            {
                if (add.Number < obj.Number)
                {
                    throw new NotEnougException("Not enough items in Storage");
                }
                else
                {
                    add.Number -= obj.Number;
                    update(add);
                }
            }
        }

        public void update(Storage obj)
        {
            Database db = new Database();
            Storage mat = db.GetTable<Storage>().Single(x => x.Id_st == obj.Id_st);
            mat.Number = obj.Number;
            db.SubmitChanges();
        }

        public IEnumerable<Storage> Select()
        {
            return (new Database().GetTable<Storage>().ToArray());
        }

        public void delete(Storage obj)
        {
            Database db = new Database();
            Storage ondelete = db.GetTable<Storage>().Single(x => x.Id_st == obj.Id_st);
            db.GetTable<Storage>().DeleteOnSubmit(ondelete);
            db.SubmitChanges();
        }

        public Storage Select(int id)
        {
            return (Single(x => x.Id_st == id));
        }

        public Storage Single(Func<Storage, bool> predicate)
        {
            return (new Database().GetTable<Storage>().SingleOrDefault(predicate));
        }

        public IEnumerable<Storage> Select(Func<Storage, bool> predicate)
        {
            return (new Database().GetTable<Storage>().Where(predicate).ToArray());
        }
    }
}