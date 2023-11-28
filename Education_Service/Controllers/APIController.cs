using Education_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        
    }
}