using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Agile_2018
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            RouteTable.Routes.MapPageRoute("Login", "Index", "~/Login.aspx");
            RouteTable.Routes.MapPageRoute("AllProjects", "2017-agile/team5/AllProjects", "~/Pages/AllProjects.aspx");
            RouteTable.Routes.MapPageRoute("ViewProject", "2017-agile/team5/ViewProject", "~/Pages/ViewProject.aspx");
        }
    }
}
