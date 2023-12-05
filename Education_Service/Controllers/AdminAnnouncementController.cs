using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    public class AdminAnnouncementController : Controller
    {
        DB_techedEntities db = new DB_techedEntities();
        
        // GET: Announcement
        public ActionResult Index()
        {
            List<tblAnnouncement> announcements = GetAnnouncementsFromDataSource();

            return View();
        }

        private List<tblAnnouncement> GetAnnouncementsFromDataSource()
        {
            throw new NotImplementedException();
        }

        public ActionResult MakeAnnouncement( int id =0)
        {

            List<SelectListItem> ClassCourseList = new List<SelectListItem>();
            using (var db = new DB_techedEntities())
            {
                var objlist = db.tblClassCourses.Select(b => new { b.id, b.CourseName }).ToList();
                foreach (var item in objlist)
                {
                    SelectListItem o = new SelectListItem();
                    o.Text = item.CourseName;
                    o.Value = item.id.ToString();
                    ClassCourseList.Add(o);
                }
                
            }
           
            ViewBag.ClassCourseList = ClassCourseList;
            ViewBag.Announcements = db.tblAnnouncements.ToList();//last

            if (id>0)
            {
                var obj = db.tblAnnouncements.Find(id);
                return View( "MakeAnnouncement",obj);
            }


            return View("MakeAnnouncement");
        }
        [HttpPost]
        public ActionResult MakeAnnouncement(tblAnnouncement a)
        {
            using (var ctx = new DB_techedEntities())
            {
                a.Date = DateTime.Now;
                
                ctx.tblAnnouncements.Attach(a);
                ctx.Entry(a).State = a.id > 0 ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;
                ctx.SaveChanges();
                return RedirectToAction("MakeAnnouncement");
            }
        }
        public ActionResult EditAnnouncement(int id)
        {
            
            return View("MakeAnnouncement");
        }

      
        public ActionResult DeleteAnnouncement(int id)
        {
            try
            {
                using (var ctx = new DB_techedEntities())
                {
                    tblAnnouncement obj = ctx.tblAnnouncements.Find(id);
                    if (obj != null)
                    {
                        ctx.tblAnnouncements.Remove(obj);
                        ctx.SaveChanges();
                        ViewBag.message = "Rec deleted";
                    }
                }
            }
            catch (Exception )
            {

                
            }
            

            return RedirectToAction("MakeAnnouncement");
        }
    }
}
       