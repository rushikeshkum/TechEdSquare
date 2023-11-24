using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    public class RegisterUserController : Controller
    {
        // GET: RegisterUser
        public ActionResult Register()
        {
            return View();
        }
    }
}