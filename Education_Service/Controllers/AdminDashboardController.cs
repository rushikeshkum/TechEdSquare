using Education_Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace Education_Service.Controllers
{
    [CustomAuthorizeRoles("Admin")]

    public class AdminDashboardController : Controller
    {
        DB_techedEntities db =new DB_techedEntities();
   

     
        public ActionResult Index()
        {
            var obj = db.tblEnquiries.Include(t => t.tblClassCourse);
            return View(obj.ToList());
        }
         
      
    
        public ActionResult Add(int? id)
        {
            if (id != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tblEnquiry = db.tblEnquiries.Find(id);
            if (id != null)
            {
                return HttpNotFound();
            }
            ViewBag.InterestedIn = new SelectList(db.tblClassCourses, "id", "CourseName", tblEnquiry.InterestedIn);
            return View(tblEnquiry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "id,Name,EmailId,MobileNo,InterestedIn")] tblEnquiry tblEnquiry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEnquiry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InterestedIn = new SelectList(db.tblClassCourses, "id", "CourseName", tblEnquiry.InterestedIn);
            return View(tblEnquiry);
        }

        public ActionResult jay()
        {
            return View();
        }
    }
}