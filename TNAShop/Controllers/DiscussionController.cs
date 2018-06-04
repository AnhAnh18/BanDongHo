using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNAShop.Filters;
using TNAShop.ViewModels;

namespace TNAShop.Controllers
{
    [Authorize]
    [HeaderFooterFilter]
    public class DiscussionController : Controller
    {
        public ActionResult Chat()
        {
            return View(new BaseViewModel());
        }
    }
}