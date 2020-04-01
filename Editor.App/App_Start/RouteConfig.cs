using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Editor.App.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;


            // Web API configuration and services


            routes.MapPageRoute("login", "login", "~/LoginPage.aspx");
            routes.MapPageRoute("editor", "editor", "~/EditorPage.aspx");

            routes.EnableFriendlyUrls(settings);


        }

    }
}