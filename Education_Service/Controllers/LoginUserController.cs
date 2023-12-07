using Education_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Education_Service.Controllers
{
    public class LoginUserController : Controller
    {
        DB_techedEntities db= new DB_techedEntities();
        // GET: LoginUser
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin obj)
        {

            var user = db.tblStudentDatas.Where(w => w.StudentCourseUsername.ToLower() == obj.UserUserName.ToLower() && w.StudentLoginPassword == obj.UserPassword).FirstOrDefault();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(obj.UserUserName, false);
                //FormsAuthentication.SetAuthCookie(user.id.ToString(), false);
                return RedirectToAction("Index", "home");
            }
            else
            {
                ViewBag.msg = "Invalid credentials";
            }

            return View();
        }

        public ActionResult ULogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}