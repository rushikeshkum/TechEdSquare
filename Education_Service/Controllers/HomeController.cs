using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    
    public class HomeController : Controller
    {   
        DB_techedEntities db = new DB_techedEntities(); 
        // GET: Home
        public ActionResult Index()
        {
            var obj = db.tblClassCourses.Where(c => c.CourseStatus == true).ToList();
            if (obj != null)
            {
                ViewBag.Allcourse = obj;

            }

            return View();
        }
    }
}