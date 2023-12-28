using Education_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Education_Service.Controllers
{
    public class AdminController : Controller
    {
        DB_techedEntities db = new DB_techedEntities();
        // GET: LoginAdmin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminLogin obj)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            var user = db.tblAdmins.
                Where(w => w.AdminUsername.ToLower() == obj.UsernameAdmin.ToLower() &&
                w.AdminPassword == obj.PasswordAdmin).FirstOrDefault();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(obj.UsernameAdmin , false);

                return RedirectToAction("Index", "AdminCourse");
            }
            else
            {
                ViewBag.msg = "Invalid credentials";
            }

            return View();
        }

        public ActionResult LogOut() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}