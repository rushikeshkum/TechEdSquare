using Education_Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    [CustomAuthorizeRoles("Admin")]
    public class AdminVideoController : Controller
    {
        DB_techedEntities db = new DB_techedEntities();

        // Show all Video using this Action
        public ActionResult Index(int courseId)
        {
            var obj = db.tblCourseVideos.Where(c => c.CourseId == courseId).ToList();

            if (obj != null)
            {
                ViewBag.Allvideo = obj;
            }
            var course = db.tblClassCourses.FirstOrDefault(c => c.id == courseId);

            // Check if the course exists
            if (course != null)
            {
                // Store the course name in ViewBag
                ViewBag.idd = course.id;
                ViewBag.CourseName = course.CourseName;
                ViewBag.CourseDecription = course.CourseDiscription;
            }

            return View();
        }


        //Add update edite delete couurse section  ############################################################################## start
        public ActionResult AddVideo(int cid, int id = 0)
        {
            if (id > 0)
            {
                var boj = db.tblCourseVideos.Find(id);
                if (boj != null)
                {
                    return View(boj);
                }
            }
            ///In this Chek the condition if id is present if present then show data fro this id

            return View();

        }
        [HttpPost]
        public ActionResult AddVideo(tblCourseVideo v, int Cid)
        {
            if (v != null)
            {
                v.CourseId = Cid;
                db.tblCourseVideos.Attach(v);
                db.Entry(v).State = v.id > 0 ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
            int courseId = v != null ? v.CourseId : 0; //this code capture cust id from database

            return RedirectToAction("Index", new { courseId }); //it redirect using cource id to inex page
        }

        public ActionResult Delete(int id, int Cid)
        {
            try
            {
                var obj = db.tblCourseVideos.Find(id);
                if (obj != null) 
                {
                    db.tblCourseVideos.Remove(obj);
                    db.SaveChanges();
                }

                int courseId = Cid;
                return RedirectToAction("Index", new { courseId });

            }
            catch (Exception )
            {

                throw;
            }
        }





    }
}