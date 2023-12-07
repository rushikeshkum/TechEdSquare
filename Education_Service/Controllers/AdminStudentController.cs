using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    [Authorize]
    public class AdminStudentController : Controller
    {
        DB_techedEntities db = new DB_techedEntities();

        // GET: AdminStudent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddStudent()
        {
            List<SelectListItem> ClassCourseList = new List<SelectListItem>();
            using (var db = new DB_techedEntities())
            {
                var objlist = db.tblClassCourses.Select(s => new { s.id, s.CourseName }).ToList();
                foreach (var item in objlist)
                {
                    SelectListItem o = new SelectListItem();
                    o.Text = item.CourseName;
                    o.Value = item.id.ToString();
                    ClassCourseList.Add(o);
                }
            }

            ViewBag.Courselist = ClassCourseList;
            return View("AddStudent");
        }

        
    }
}