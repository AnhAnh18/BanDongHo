using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TNAShop.Data;

namespace TNAShop.Filters {
    public class AdminFilter : ActionFilterAttribute {
        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated == true) {
                
                string userId = HttpContext.Current.User.Identity.GetUserId();
                ApplicationDbContext db = new ApplicationDbContext();
                var role = (from r in db.Roles where r.Name.Contains("admin") select r).FirstOrDefault();
                var users = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();
                if (users.Find(x => x.Id == userId) != null) {
                } else {
                    filterContext.Result = new ContentResult() { Content = "Bạn không có quyền truy cập vào đây" };
                }
            } else {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary() {
                    {"action","Login" },
                    {"controller","account" },
                    {"Area" ,""}
                });
            }
        }
    }
}