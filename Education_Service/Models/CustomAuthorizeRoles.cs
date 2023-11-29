using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Education_Service.Models
{
    public class CustomAuthorizeRoles : AuthorizeAttribute
    {
        DB_techedEntities db = new DB_techedEntities();

        string Role;
        public CustomAuthorizeRoles(string _role)
        {
            Role = _role;

        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated == false)
            {
                return false;

            }
            string username = httpContext.User.Identity.Name;

            var stud = db.tblStudentDatas.Where(w => w.StudentCourseUsername == username).FirstOrDefault();
            if (stud != null && stud.Roles == Role)
            {
                return true;
            }
            else if (stud == null)
            {
                var obj = db.tblAdmins.Where(w => w.AdminUsername == username).FirstOrDefault();
                if (obj!=null && obj.Rolle==Role)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

            return false;
        }



        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("UnauthorizeAcces/AccesDenied");
            // filterContext.Result = new RedirectToRouteResult(
            //new RouteValueDictionary
            //{
            //     { "controller", filterContext.RouteData.Values["controller"] },
            //     { "action", filterContext.RouteData.Values["action"] }
            //});

        }


    }
}
