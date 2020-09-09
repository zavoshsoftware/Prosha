using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace ProshaSoft
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_BeginRequest()
        {
            ExecuteCore();

            if (!Context.Request.IsSecureConnection)
                Response.Redirect(Context.Request.Url.ToString().Replace("http:", "https:"));


        }
        private const string LanguageCookieName = "MyLanguageCookieName";
        protected void ExecuteCore()
        {
            var cookie = Request.Cookies[LanguageCookieName];
            string lang;
            if (cookie != null)
            {
                lang = cookie.Value;
            }
            else
            {
                lang = "fa-IR";
                var httpCookie = new HttpCookie(LanguageCookieName, lang) { Expires = DateTime.Now.AddYears(1) };
                Response.SetCookie(httpCookie);
            }
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);

            //var persianCulture = new PersianCulture();
            //Thread.CurrentThread.CurrentCulture = persianCulture;
            //Thread.CurrentThread.CurrentUICulture = persianCulture;
        }


        protected string StyleSheetPathFa
        {
            get
            {
                // pull the stylesheet name from a database or xml file...
                return ApplicationPath + "assets/css/style-rtl.css";
            }
        }
        protected string StyleSheetPath
        {
            get
            {
                // pull the stylesheet name from a database or xml file...
                return ApplicationPath + "assets/css/style-ltr.css";
            }
        }

        private string ApplicationPath
        {
            get
            {
                string result = Request.ApplicationPath;
                if (!result.EndsWith("/"))
                {
                    result += "/";
                }
                return result;
            }
        }
    }
}
