using Accounting.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.Controllers
{
    public class MaterialController : Controller
    {
        //
        // GET: /Material/
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Index()
        {
            MaterialDAO mdao = new MaterialDAO();
            return View(mdao.Select());
        }

        //
        // GET: /Material/Details/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Details(int id)
        {
            MaterialDAO mdao = new MaterialDAO();
            return View(mdao.Select(id));
        }

        //
        // GET: /Material/Create
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            return View(new Material());
        }

        //
        // POST: /Material/Create
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public ActionResult Create(Material mat)
        {
            try
            {
                MaterialDAO mdao = new MaterialDAO();
                mdao.insert(mat);
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Material/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int id)
        {
            MaterialDAO mdao = new MaterialDAO();
            return View(mdao.Select(id));
        }

        //
        // POST: /Material/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public ActionResult Edit(Material obj)
        {
            try
            {
                MaterialDAO mdao = new MaterialDAO();
                mdao.update(obj);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Material/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int id)
        {
            MaterialDAO mdao = new MaterialDAO();
            return View(mdao.Select(id));
        }

        //
        // POST: /Material/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                MaterialDAO mdao = new MaterialDAO();
                mdao.delete(new Material() { Id_mat = id});

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
