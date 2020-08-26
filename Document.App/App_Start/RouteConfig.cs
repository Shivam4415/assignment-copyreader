using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Document.App.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;

            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
            GlobalConfiguration.Configuration.EnsureInitialized();

            //var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);


            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);


            RouteTable.Routes.MapHttpRoute(name: "API Default", routeTemplate: "api/v1/{controller}/{id}", defaults: new { id = RouteParameter.Optional });


            routes.MapPageRoute("login", "login", "~/LoginPage.aspx");
            //routes.MapPageRoute("editor1", "editor", "~/EditorPage.aspx");
            routes.MapPageRoute("editor", "editor/{editorId}", "~/EditorPage.aspx");
            //routes.MapPageRoute("home", "home", "~/Home.aspx");
            routes.MapPageRoute("product", "product", "~/ProductPage.aspx");
            routes.MapPageRoute("error", "error", "~/Error.aspx");
            routes.MapPageRoute("register", "register", "~/Register.aspx");

            routes.EnableFriendlyUrls(settings);


        }

    }
}