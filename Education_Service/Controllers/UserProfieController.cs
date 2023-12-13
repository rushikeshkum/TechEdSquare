using Education_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    
    [CustomAuthorizeRoles("Student")]
    public class UserProfieController : Controller
    {
        DB_techedEntities db = new DB_techedEntities();
        // GET: UserProfie
        public ActionResult profile()
        {
            if (User.Identity.IsAuthenticated)
            {
                var usr = User.Identity.Name;
                var userdata = db.tblStudentDatas.Where(w => w.StudentCourseUsername == usr).FirstOrDefault();

                if (userdata != null)
                { 
                    return View(userdata);
                 
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult profile(tblStudentData st)
        {
           
            var obj = db.tblStudentDatas.Find(st.id);
            if (obj != null)
            {
                obj.StudentName = st.StudentName;
                obj.StudentMobileNo = st.StudentMobileNo;
                obj.StudentAddress = st.StudentAddress;
                obj.StudentMailId = st.StudentMailId;
                obj.StudentDOB = st.StudentDOB;

                db.SaveChanges();

                ViewBag.msg = "Updated success";
                return RedirectToAction("profile");
            }

            //if (obj != null)
            //{
            //    db.StudentName = obj.StudentName;
            //    st.StudentMobileNo = obj.StudentMobileNo;

            //    db.SaveChanges();
            //    ViewBag.msg = "Updated success";
            //    return RedirectToAction("profile");
            //}
            

            //db.Entry(obj).State = st.id > 0 ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;
           
               return View( );
        }

    }
}