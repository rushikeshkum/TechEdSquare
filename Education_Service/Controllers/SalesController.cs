using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    public class SalesController : Controller
    {
        DB_techedEntities db = new DB_techedEntities();
        // GET: Sales
        public ActionResult Index()
        {
            ViewBag.sales = db.tblSales.ToList();//last
            return View();
        }
    }
}