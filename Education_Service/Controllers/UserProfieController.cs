using Education_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    [CustomAuthorizeRoles("Student")]
    public class UserProfieController : Controller
    {
        // GET: UserProfie
        public ActionResult profile()
        {
            return View();
        }
    }
}