using LostPeopleRegisterApp.Src.LostPersonUtil.Address.ConverterUtil;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Mvc;

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

            config
                .Formatters
                .JsonFormatter
                .SerializerSettings
                .Converters.Add(new LostPersonAddressJsonConverter());
        }
    }
}
