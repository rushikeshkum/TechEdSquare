using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Service.Controllers
{
    public class AnnoucementUserController : Controller
    {
        // GET: AnnoucementUser
        DB_techedEntities db = new DB_techedEntities();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var usr = User.Identity.Name;
                var userdata = db.tblAnnouncements.Where(w => w.AnnouncementTitle == usr).FirstOrDefault();

                if (userdata != null)
                {
                    return View(userdata);

                }
            }
            return View();
            
        }
    }
}