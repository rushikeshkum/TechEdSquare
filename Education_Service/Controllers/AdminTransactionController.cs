using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    public class AdminTransactionController : Controller
    {
        DB_techedEntities db = new DB_techedEntities();

        // GET: AdminTransaction
        public ActionResult Index(int id=0)
        {

            List<SelectListItem> trytype = new List<SelectListItem>();

            var objlist = db.tblTrnModes.Select(s => new { s.id, s.TrnMode }).ToList();
            foreach (var item in objlist)
            {
                SelectListItem o = new SelectListItem();
                o.Text = item.TrnMode;
                o.Value = item.id.ToString();
                trytype.Add(o);
            }

            List<SelectListItem> coursel = new List<SelectListItem>();
            var courseist = db.tblClassCourses.Select(s => new { s.id, s.CourseName }).ToList();
            foreach (var item in courseist)
            {
                SelectListItem c = new SelectListItem();
                c.Text = item.CourseName;
                c.Value = item.id.ToString();
                coursel.Add(c);
            }

            ViewBag.course = coursel;
            ViewBag.trnmodes = trytype;

            if (id>0)
            {
                var cou = db.tblTransactions.Find(id);
                return View(cou);


            }


            return View();
        }

        [HttpPost]

        public ActionResult Index(tblTransaction trn)
        {
            db.tblTransactions.Attach(trn);
            db.Entry(trn).State = trn.id > 0 ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;
            db.SaveChanges();



            return RedirectToAction("index");
        }

        
    }
}