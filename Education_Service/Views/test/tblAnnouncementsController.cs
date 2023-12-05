using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Education_Service;

namespace Education_Service.Controllers
{
    public class tblAnnouncementsController : Controller
    {
        private DB_techedEntities db = new DB_techedEntities();

        // GET: tblAnnouncements
        public ActionResult Index()
        {
            var tblAnnouncements = db.tblAnnouncements.Include(t => t.tblClassCourse);
            return View(tblAnnouncements.ToList());
        }

        // GET: tblAnnouncements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAnnouncement tblAnnouncement = db.tblAnnouncements.Find(id);
            if (tblAnnouncement == null)
            {
                return HttpNotFound();
            }
            return View(tblAnnouncement);
        }

        // GET: tblAnnouncements/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.tblClassCourses, "id", "CourseName");
            return View();
        }

        // POST: tblAnnouncements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Date,CourseId,AnnouncementTitle,AnnouncementDiscription")] tblAnnouncement tblAnnouncement)
        {
            if (ModelState.IsValid)
            {
                db.tblAnnouncements.Add(tblAnnouncement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.tblClassCourses, "id", "CourseName", tblAnnouncement.CourseId);
            return View(tblAnnouncement);
        }

        // GET: tblAnnouncements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAnnouncement tblAnnouncement = db.tblAnnouncements.Find(id);
            if (tblAnnouncement == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.tblClassCourses, "id", "CourseName", tblAnnouncement.CourseId);
            return View(tblAnnouncement);
        }

        // POST: tblAnnouncements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Date,CourseId,AnnouncementTitle,AnnouncementDiscription")] tblAnnouncement tblAnnouncement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAnnouncement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.tblClassCourses, "id", "CourseName", tblAnnouncement.CourseId);
            return View(tblAnnouncement);
        }

        // GET: tblAnnouncements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAnnouncement tblAnnouncement = db.tblAnnouncements.Find(id);
            if (tblAnnouncement == null)
            {
                return HttpNotFound();
            }
            return View(tblAnnouncement);
        }

        // POST: tblAnnouncements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAnnouncement tblAnnouncement = db.tblAnnouncements.Find(id);
            db.tblAnnouncements.Remove(tblAnnouncement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
