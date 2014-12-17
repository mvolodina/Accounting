using Accounting.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.Controllers
{
    public class StorageController : Controller
    {
        //
        // GET: /Storage/
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Index()
        {
            StorageDAO sdao = new StorageDAO();
            return View(sdao.Select());
        }

        //
        // GET: /Storage/Details/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Storage/Create
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Storage/Create
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Storage/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int id)
        {
            Storage obj = new StorageDAO().Select(id);
            return View(obj);
        }

        //
        // POST: /Storage/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public ActionResult Edit(Storage obj)
        {
            try
            {
                new StorageDAO().reduceCount(obj);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home", ex.ToString());
            }
        }

        //
        // GET: /Storage/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Storage/Delete/5
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
    }
}
