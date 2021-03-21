using System.Web.Mvc;
using System.Web.Routing;

namespace LostPeopleRegisterApp.Src.Config
{
    /// <summary>
    /// Klasa przechowująca zestaw metód do podstawowej konfiguracji routingu naszej aplikacji
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Metoda ta rejestruje podstawową konfigurację routingu.
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { 
                    controller = "Home",
                    action = "Index", 
                    id = UrlParameter.Optional 
                }
            );
        }
    }
}