using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    public class AdminVideoController : Controller
    {
        DB_techedEntities db = new DB_techedEntities();

        // Show all Video using this Action
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddVideo()
        {
            return View();
        }

        //public ActionResult Index2(int courseId)
        //{

        //    var obj = db.tblCourseVideos.Where(c => c.CourseId == courseId).ToList();
        //    if (obj != null)
        //    {
        //        ViewBag.Allvideo = obj;

        //    }

        //    return View();
        //}
        public ActionResult Index2(int courseId)
        {
            var obj = db.tblCourseVideos.Where(c => c.CourseId == courseId).ToList();

            if (obj != null)
            {
                ViewBag.Allvideo = obj;
            }

            return View();
        }
    }
}