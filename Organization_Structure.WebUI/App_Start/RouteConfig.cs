using System.Web.Mvc;
using System.Web.Routing;

namespace Organization_Structure.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


			routes.MapRoute(null,
				"",
				new
				{
					controller = "Employee",
					action = "List",
					group = (int?)null,
					page = 1
				}
			);

			routes.MapRoute(
				name: null,
				url: "Page{page}",
				defaults: new { controller = "Employee", action = "List" }
			);

			routes.MapRoute(null,
				"{group}",
				new { controller = "Employee", action = "List", page = 1 }
			);

			routes.MapRoute(null,
				"{group}/Page{page}",
				new { controller = "Employee", action = "List" },
				new { page = @"\d+" }
			);

			routes.MapRoute(null, "{controller}/{action}");


		}
    }
}
