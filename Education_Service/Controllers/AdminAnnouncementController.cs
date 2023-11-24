using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    public class AdminAnnouncementController : Controller
    {
        // GET: Announcement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MakeAnnouncement()
        {
            return View();
        }
    }
}