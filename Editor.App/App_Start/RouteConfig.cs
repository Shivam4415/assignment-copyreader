using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Editor.App.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;

            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
            GlobalConfiguration.Configuration.EnsureInitialized();

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            RouteTable.Routes.MapHttpRoute( name: "API Default", routeTemplate: "api/v1/{controller}/{id}", defaults: new { id = RouteParameter.Optional });

            // Web API configuration and services


            routes.MapPageRoute("login", "login", "~/LoginPage.aspx");
            //routes.MapPageRoute("editor1", "editor", "~/EditorPage.aspx");
            routes.MapPageRoute("editor", "editor/{editorId}", "~/EditorPage.aspx");
            routes.MapPageRoute("home", "home", "~/Home.aspx");
            routes.MapPageRoute("error", "error", "~/ErrorPage.aspx");

            routes.EnableFriendlyUrls(settings);


        }

    }
}