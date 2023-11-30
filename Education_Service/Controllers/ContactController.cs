using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    public class ContactController : Controller
    {
        DB_techedEntities db = new DB_techedEntities();

        // GET: Contact
        public ActionResult Index(int id = 0)
        {
            


            List<SelectListItem> clist = new List<SelectListItem>();
            var objlist = db.tblClassCourses.Select(s => new { s.id, s.CourseName }).ToList();
            foreach (var item in objlist)
            {
                SelectListItem o = new SelectListItem();
                o.Text = item.CourseName;
                o.Value = item.id.ToString();
                clist.Add(o);

            }
            ViewBag.clist = clist;

            if (id > 0)
            {
                var course = db.tblClassCourses.Where(w => w.id == id).FirstOrDefault();

                if (course != null)
                {
                    var obj = course.id;
                    return View(obj);
                }


            }

            return View(tupleModel);
        }
        [HttpPost]
        public ActionResult Index(tblEnquiry enq)
        {
            if (enq != null)
            {
                db.tblEnquiries.Attach(enq);
                db.Entry(enq).State = enq.id > 0 ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;
                db.SaveChanges();

            }
            return RedirectToAction("index");
        }

        public ActionResult Index2(tblEnquiry enq)
        {
            return View();
        }
    }
}