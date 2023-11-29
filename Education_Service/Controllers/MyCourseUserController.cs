using Education_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    [CustomAuthorizeRoles("Student")]
    public class MyCourseUserController : Controller
    {
        DB_techedEntities db = new DB_techedEntities();

        // GET: MyCourseUser
        public ActionResult MyCourse()
        {
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                var obj = db.tblStudentDatas.Where(w => w.StudentCourseUsername == username && w.StudentStatus.ToString()=="True").FirstOrDefault();
                if (obj != null)
                {
                    
                    var courceId = obj.SubscribedCourseId;

                    var course = db.tblClassCourses.Where(c => c.id == courceId).ToList();

                    ViewBag.course=course;

                }


            }
            else
            {
                ViewBag.course = null;
            }

            return View();
        }


    }
}