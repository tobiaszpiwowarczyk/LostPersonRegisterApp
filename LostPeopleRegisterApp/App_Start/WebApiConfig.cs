using System.Web.Http;

namespace LostPeopleRegisterApp
{
    /// <summary>
    /// Klasa zawiera metodę, która będzie odpowiedzialna za podstawową konfigurację
    /// routingu w naszej aplikacji.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Metoda ta rejestruje nowe przekierowania do aplikacji.
        /// Metoda ta zawiera konfigurację, która dodaje domyślną stronę startową
        /// </summary>
        /// <param name="config">Klasa dostarczająca zestaw metód do konfiguracji routingu</param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
