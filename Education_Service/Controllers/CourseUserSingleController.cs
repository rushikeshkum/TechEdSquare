using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    public class CourseUserSingleController : Controller
    {
        DB_techedEntities db=new DB_techedEntities();
        
        public ActionResult Index(int id)
        {
            var course = db.tblClassCourses.FirstOrDefault(c => c.id == id);

            if (course != null)
            {
                ViewBag.CourseName=course.CourseName;
                ViewBag.CourseCategory = course.tblClassCategory.CategoryName;
                //ViewBag.EducatorProfile=course.EducatorProfile;
                ViewBag.CourseShortD = course.CourseDiscription;
                ViewBag.CourseDetaildD = course.DetailedDiscription;
                ViewBag.CourseDuration = course.CourseDuration;
                ViewBag.CourseFees = course.CourseFees;
                ViewBag.CourseImage = course.CourseImage;

            }

            return View();
        }


    }
}