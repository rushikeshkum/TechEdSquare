using Education_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    [CustomAuthorizeRoles("Student")]
    public class UserVIdeoController : Controller
    {
        DB_techedEntities db=new DB_techedEntities();
        // GET: UserVIdeo
        public ActionResult AllVideo(int id)
        {
            if (User.Identity.IsAuthenticated)
            {   
                if (User.Identity.IsAuthenticated)
                {
                    var courseid = id;
                    var obj=db.tblCourseVideos.Where(w=> w.CourseId == courseid).ToList();
                    
                    if (obj!=null)
                    {
                        ViewBag.Videos = obj;
                    }

                    var course = db.tblClassCourses.FirstOrDefault(c => c.id == courseid);
                    if (course!=null)
                    {
                        ViewBag.Cname = course.CourseName;
                    }
                }


                //this is second way get course id from logged user
                //string username = User.Identity.Name;
                //var obj = db.tblStudentDatas.Where(w => w.StudentCourseUsername == username && w.StudentStatus.ToString() == "True").FirstOrDefault();
                //if (obj != null)
                //{
                //    var courceId = obj.SubscribedCourseId;
                    
                //    var course = db.tblClassCourses.Where(c => c.id == courceId).ToList();

                //    ViewBag.course = course;

                //}

            }
            return View();
        }
    }
}