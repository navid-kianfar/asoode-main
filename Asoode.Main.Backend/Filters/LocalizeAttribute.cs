using System;
using System.Globalization;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Asoode.Main.Backend.Filters
{
    public class LocalizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Path.Value.Contains(".")) return;
            string culture = context.RouteData.Values["culture"]?.ToString();
            if (string.IsNullOrEmpty(culture))
            {
                culture = context.HttpContext.Request.Headers["culture"];
                if (string.IsNullOrEmpty(culture))
                {
                    culture = context.HttpContext.Request.Cookies["culture"];
                }
            }

            if (string.IsNullOrEmpty(culture))
            {
                culture = "fa";
            }

            context.HttpContext.Response.Cookies.Delete("culture");
            context.HttpContext.Response.Cookies.Append("culture", culture);
            context.HttpContext.Response.Headers.Add("culture", culture);
            var info = CultureInfo.GetCultureInfo(culture);
            if (context.Controller is Controller controller)
            {
                controller.ViewBag.Lang = culture;
                controller.ViewBag.Direction = info.TextInfo.IsRightToLeft ? "rtl" : "ltr";
            }

            Thread.CurrentThread.CurrentUICulture = info;
            Thread.CurrentThread.CurrentCulture = info;

            base.OnActionExecuting(context);
        }
    }
}