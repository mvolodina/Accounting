using Accounting.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.Controllers
{
    public class SupplierController : Controller
    {
        //
        // GET: /Supplier/
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Index()
        {
            SupplierDAO dao = new SupplierDAO();
            return View(dao.Select());
        }

        //
        // GET: /Supplier/Details/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Details(int id)
        {
            return View(new SupplierDAO().Select(id));
        }

        //
        // GET: /Supplier/Create
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            return View(new Supplier());
        }

        //
        // POST: /Supplier/Create
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public ActionResult Create(Supplier sup)
        {
            try
            {
                // TODO: Add insert logic here
                new SupplierDAO().insert(sup);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Supplier/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Supplier/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Supplier/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Supplier/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
 
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public PartialViewResult Orders(int id)
        {
            return PartialView(new OrdersDAO().Select(x => x.FK_Sup == id));
        }
    }
}
