using Accounting.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Accounting.DAO;
using System.Data.Linq;

namespace Accounting.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(new UsersDAO().Select());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new Models.RegisterViewModel());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Models.RegisterViewModel user)
        {
            AccountController ac = new AccountController();
            Task<ActionResult> a = ac.Register(user);
            string role_id = new UsersRoleDAO().Single(x=> x.Name == "Manager").Id;
            string id = new UsersDAO().Single(x => x.UserName == user.UserName).Id;
            AspNetUserRoles au = new DAO.AspNetUserRoles()
            {
                UserId = id,
                RoleId = role_id
            };
            new UserInRolesDAO().insert(au);
            return Redirect("index");
        }
        [Authorize(Roles ="Admin")]
        public ActionResult SetRole(String id)
        {
            return View(new AspNetUserRoles() {UserId = id});
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult SetRole(AspNetUserRoles obj)
        {
            new UserInRolesDAO().insert(obj);
            return Redirect("Index");
        }
        [Authorize(Roles = "Admin")]
        public PartialViewResult RoleList(String id)
        {
            return PartialView(new UsersRoleDAO().Select(new UserInRolesDAO().Select(x => x.UserId == id)));
        }
	}
}