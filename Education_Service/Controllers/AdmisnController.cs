using Education_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    public class AdmisnController : Controller
    {
        DB_techedEntities db = new DB_techedEntities();
        // GET: LoginAdmin
        public ActionResult Alogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alogin(AdminLogin obj)
        {
            var user = db.tblAdmins.
                Where(w => w.AdminUsername.ToLower() == obj.UsernameAdmin.ToLower() &&
                w.AdminPassword == obj.PasswordAdmin).FirstOrDefault();
            if (user != null)
            {
                return RedirectToAction("Index", "AdminDashboard");
            }
            else
            {
                ViewBag.msg = "Invalid credentials";
            }


            return View();
        }
    }
}