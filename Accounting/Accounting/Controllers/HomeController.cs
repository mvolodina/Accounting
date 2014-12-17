using Accounting.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Index()
        {

           return RedirectToAction("Index", "Orders");
        }
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Error(String message)
        {
            return View(message);
        }
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}