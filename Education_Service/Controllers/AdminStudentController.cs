using Education_Service.Models;
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
        public ActionResult AllStudent(int id = 0)
        {
            ViewBag.studentList = db.tblStudentDatas.ToList();
            if (id > 0)
            {
                return View(db.tblStudentDatas.Find(id));
            }
            return View();
        }
        
        
        [HttpPost]

        public ActionResult AllStudent(tblStudentData s)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.tblStudentDatas.Attach(s);
                    db.Entry(s).State = s.id > 0 ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;

                   
                    db.SaveChanges();

                    ViewBag.msg = "Saved Successfully";
                    ModelState.Clear();
                }

                catch (Exception er)
                {

                    ViewBag.msg = "Error-" + er.Message;
                }

            }
            else
            {

                ViewBag.msg = CommonRepo.GetAdditionalValidationIssues(ModelState);
            }
            ViewBag.studentList = db.tblStudentDatas.ToList();
          
            return View();
        }
        
        public ActionResult Delete(int id)
        {
            var obj = db.tblStudentDatas.Find(id);
            if (obj != null)
            {
                db.tblStudentDatas.Remove(obj);
                db.SaveChanges();
                TempData["msg"] = "Deleted Successfully";

            }
            return RedirectToAction("AllStudent");
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

        [HttpPost]
        public ActionResult AddStudent(tblStudentData stu)
        {
            if (stu!=null)
            {
                var obj = db.tblStudentDatas.Attach(stu);
                db.Entry(obj).State = stu.id > 0 ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;
                db.SaveChanges();

            }
            var studID = stu.id;
            return RedirectToAction("Index", "admintransaction", new { id = studID });
        }

    }
}