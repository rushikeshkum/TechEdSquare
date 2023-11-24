using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    public class AdminStudentController : Controller
    {
        // GET: AdminStudent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddStudent()
        {
            return View();
        }
    }
}