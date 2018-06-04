using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNAShop.Application;
using TNAShop.ViewModels;

namespace TNAShop.Filters {
    public class HeaderFooterFilter :ActionFilterAttribute {
        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            ViewResult v = filterContext.Result as ViewResult;
            if (v != null) {
                BaseViewModel bvm = (BaseViewModel)v.Model ;
                if (bvm != null) {
                    bvm.Brands = new BrandService().GetBrands();
                    bvm.Categories = new CategoryService().Get();
                    bvm.Straps = new StrapService().Get();
                    bvm.PriceFilterings = new PriceFilteringService().Get();
                }
            }
        }
    }
}