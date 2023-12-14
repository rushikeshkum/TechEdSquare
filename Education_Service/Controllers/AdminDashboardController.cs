using Education_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Education_Service.Controllers
{
    [Authorize]

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