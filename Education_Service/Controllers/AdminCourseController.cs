using Education_Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
//using YourNamespaceContainingCustomAuthorizeRoles;
//using Authorization;

namespace Education_Service.Controllers
{
    [CustomAuthorizeRoles("Admin")]
    public class AdminCourseController : Controller
    {
        DB_techedEntities db = new DB_techedEntities();

        // GET: AdminCourse
        public ActionResult Index() //to show all courses
        {
            //var obj = db.tblClassCourses.Where(c => c.CourseStatus==true).ToList();
            //if (obj!=null) 
            //{
            //    ViewBag.Allcourse = obj;

            //}
           
            ViewBag.Allcourse = db.tblClassCourses.ToList();
            return View();
        }
        public ActionResult AddCourse(int id = 0)
        {
            List<SelectListItem> ClassCourseCategory = new List<SelectListItem>();
            using (var db = new DB_techedEntities())
            {
                var objlist = db.tblClassCategories.Select(s => new { s.id, s.CategoryName }).ToList();
                foreach (var item in objlist)
                {
                    SelectListItem o = new SelectListItem();
                    o.Text = item.CategoryName;
                    o.Value = item.id.ToString();
                    ClassCourseCategory.Add(o);

                }
            }
            // In your controller action that renders the view
            ViewBag.CourseStatuses = new List<SelectListItem>
            {
                 new SelectListItem { Text = "Active", Value = "True" },
                 new SelectListItem { Text = "Deactive", Value = "False" }
            };

            ViewBag.CourseCatergories = ClassCourseCategory;

            if (id > 0)
            {
                var obj = db.tblClassCourses.Find(id);
                return View(obj);
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(tblClassCourse c ,HttpPostedFileBase CourseImage)
        {
            if (CourseImage != null)
            {
                string path = Server.MapPath("~/UploadedCourseImg/");//file upload code. This is sv obj
                CourseImage.SaveAs(path + CourseImage.FileName);
                c.CourseImage = CourseImage.FileName;//in tbl vender in that clmn(image) that photo's name saved
            }


            if (c != null)
            {
                db.tblClassCourses.Attach(c);
                db.Entry(c).State = c.id > 0 ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;
                if (CourseImage == null && c.id > 0)//v.id= if it comes for update otherwise it goes for insert
                {
                    db.Entry(c).Property(x => x.CourseImage).IsModified = false;
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");
       

    }
            public ActionResult DeleteCourse()
            {
                return View();
            }

        }
    } 
