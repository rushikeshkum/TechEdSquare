using Education_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Education_Service.Controllers
{
    public class APIController : Controller
    {
        DB_techedEntities db = new DB_techedEntities();
        ResponseModel rep = new ResponseModel();

        public ActionResult GetAllStudents()
        {
            var objlist = db.tblStudentDatas.
                Select(s => new { s.id, s.StudentName, s.StudentMobileNo, s.StudentMailId, s.StudentDOB, s.StudentPAN, s.StudentAddress, Course=s.tblClassCourse.CourseName, s.StudentLoginPassword, s.StudentStatus }).
                ToList();
            rep.Code = 0;
            rep.Message = objlist;
            return Json(rep, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveStudents(tblStudentData s)
        {

            try
            {
                s.Roles = "Student";
                db.tblStudentDatas.Add(s);
                db.SaveChanges();
                rep.Code = 0;
                rep.Message = "Inserted";
                return Json(rep, JsonRequestBehavior.AllowGet);
            }
            catch (Exception er)
            {
                rep.Code = -1;
                rep.Message = er.Message;
                return Json(er.Message, JsonRequestBehavior.AllowGet);

            }


        }

        public JsonResult DeleteStudent(int id)
        {
            try
            {
                var list = db.tblStudentDatas.Find(id);
                if (list!=null)
                {
                    db.tblStudentDatas.Remove(list);
                    db.SaveChanges();
                    rep.Code = 0;
                    rep.Message = "Deleted";
                    
                }
            }
            catch (Exception er)
            {
                rep.Code = -1;
                rep.Message = er.Message;
                
            }
            return Json(rep, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FindStudentById(int id)
        {
            try
            {
                var objlist = db.tblStudentDatas.
                  Select(s => new { s.id, s.StudentName, s.StudentMobileNo, s.StudentMailId, s.StudentDOB, 
                      s.StudentPAN, s.StudentAddress,Course = s.tblClassCourse.CourseName, s.StudentLoginPassword,
                      s.StudentStatus }).Where(w=>w.id==id).FirstOrDefault();

                rep.Code = 0;
                rep.Message = objlist;
               
            }
            catch (Exception er)
            {
                rep.Code = -1;
                rep.Message = er.Message;

            }
            return Json(rep, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllData()
       
        //API COURSES
        public ActionResult GetAllCourses()
        {
            var objlist = db.tblClassCourses.
                Select(c => new { c.id, c.CourseName, c.CourseCategory, c.BatchInfo, c.EducatorProfile, c.CourseDiscription, c.DetailedDiscription, c.CourseDuration, c.CourseFees, c.CoursePreviewLink,c.CourseStatus,c.CourseImage}).
                ToList();
            return Json(objlist, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //public JsonResult SaveCourses(tblClassCourse c)
        //{
        //    try
        //    {
        //        db.tblClassCourses.Add(c);
        //        db.SaveChanges();
        //        rep.Code = 0;
        //        rep.Message = "Course Inserted";
        //        return Json(rep, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception er)
        //    {
        //        rep.Code = -1;
        //        rep.Message = er.Message;
        //        return Json(er.Message, JsonRequestBehavior.AllowGet);

        //    }
        //}
        public JsonResult SaveCourse(tblClassCourse c)//passing material from outside 122
        {
            ResponseModel rep = new ResponseModel();


            if (ModelState.IsValid == false)
            {
                return Json(CommonRepo.GetAdditionalValidationIssues(ModelState), JsonRequestBehavior.AllowGet);
            }
            try
            {
                var oldclass = db.tblClassCourses.Find(c.id);
                if (oldclass != null)
                {
                    oldclass.CourseName = c.CourseName;
                    oldclass.CourseCategory = c.CourseCategory;
                    oldclass.BatchInfo = c.BatchInfo;
                    oldclass.EducatorProfile = c.EducatorProfile;
                    oldclass.CourseDiscription = c.CourseDiscription;
                    oldclass.DetailedDiscription = c.DetailedDiscription;
                    oldclass.CourseDuration = c.CourseDuration;
                    oldclass.CourseFees = c.CourseFees;
                    oldclass.CoursePreviewLink = c.CoursePreviewLink; 
                    oldclass.CourseStatus = c.CourseStatus;
                    oldclass.CourseImage = c.CourseImage;


                    db.tblClassCourses.Attach(oldclass);
                    db.Entry(oldclass).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    rep.Code = 0;
                    rep.Message = "Succesfully Course updated";
                }
                else
                {
                    db.tblClassCourses.Add(c);
                    db.SaveChanges();
                    rep.Message = "Succesfully Inserted";
                   
                }


                return Json(rep, JsonRequestBehavior.AllowGet);
            }
            catch (Exception er)
            {
                rep.Code = -1;
                rep.Message = er.Message;
                return Json(er.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult DeleteCourseById(int id)
        {
           

            if (id == 0)
            {
                rep.Code = -1;
                rep.Message = "Id must be greater than 1";

                return Json(rep, JsonRequestBehavior.AllowGet);
            }
            var obj = db.tblClassCourses.Find(id);
            if (obj != null)
            {
                db.tblClassCourses.Remove(obj);
                db.SaveChanges();

                rep.Code = 0;
                rep.Message = "Course Deleted Succesfully";
            }
            return Json(rep, JsonRequestBehavior.AllowGet);
        }
        
    }
}