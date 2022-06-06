using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ScadaProject.CustomFilter
{
    public class SessionCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = filterContext.HttpContext;
            if ( ctx.Session.GetString("Username") == null)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
    public class SessionCheck2 : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = filterContext.HttpContext;
            if (ctx.Session.GetString("Username") != null)
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
    public class AdminCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = filterContext.HttpContext;
            if (ctx.Session.GetString("NhiemVu") != "admin")
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
    public class GiamSatCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = filterContext.HttpContext;
            if (ctx.Session.GetString("NhiemVu") != "Giam Sat" && ctx.Session.GetString("NhiemVu") != "admin")
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
    public class HienTruongCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = filterContext.HttpContext;
            if (ctx.Session.GetString("NhiemVu") != "Hien Truong" && ctx.Session.GetString("NhiemVu") != "admin")
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}