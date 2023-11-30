using Education_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Education_Service.Controllers
{
    [CustomAuthorizeRoles("Admin")]

    public class AdminDashboardController : Controller
    {
       DB_techedEntities db =new DB_techedEntities();
        public ActionResult Index()
        {
            return View();
        }

        

        public ActionResult jay()
        {
            return View();
        }
    }
}