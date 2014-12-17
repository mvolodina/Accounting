using Accounting.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.Controllers
{
    public class OrdersController : Controller
    {
        //
        // GET: /Orders/
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Index()
        {
            OrdersDAO odao = new OrdersDAO();
            return View(odao.Select());
        }
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            return View(new Orders());
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public ActionResult Create(Orders obj)
        {
            OrdersDAO odao = new OrdersDAO();
            odao.insert(obj);
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int id)
        {
            OrdersDAO odao = new OrdersDAO();
            return View(odao.Select(id));
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public ActionResult Edit(Orders obj)
        {
            OrdersDAO odao = new OrdersDAO();
            odao.update(obj);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int id){
            OrdersDAO odao = new OrdersDAO();
            Orders ord = odao.Select(id);
            odao.delete(ord);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public ActionResult Delete(Orders obj)
        {
            OrdersDAO odao = new OrdersDAO();
            odao.delete(obj);
            return RedirectToAction("Index");
            
        }
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Complite(int id)
        {
            OrdersDAO odao = new OrdersDAO();
            Orders ord = odao.Single(x => x.Id_ord == id);
            ord.Status = new StatusDAO().Single(x => x._name == "Выполнен").Id;
            StorageDAO stoDao = new StorageDAO();
            Storage add = stoDao.Single(x=> x.FK_mat == ord.FK_Mat1);
            if (add == null)
            {
                add = new Storage()
                {
                    FK_mat = ord.FK_Mat1,
                    Number = ord.Number
                };
                stoDao.insert(add);
            }
            else
            {
                add.Number += ord.Number;
                stoDao.update(add);
            }
            odao.update(ord);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Manager")]
        public PartialViewResult OrderList(int id)
        {
            return PartialView(new OrdersDAO().Select().ToArray());
        }
    }
}