using LostPeopleRegisterApp.Src.Config;
using System.Web.Mvc;

namespace LostPeopleRegisterApp.Src.Util
{
    /// <summary>
    /// Klasa, która dziedziczy klasę <see cref="Controller"/>, która będzie służyła do
    /// tworzenia nowych kontrolerów wraz z dodatkowymi atrybutami
    /// </summary>
    public class AbstractController : Controller
    {
        /// <summary>
        /// Pole przechowujące konfigurację naszej aplikacji
        /// </summary>
        /// <see cref="LostPersonAppConfig"/>
        protected LostPersonAppConfig appConfig { get; set; }

        public AbstractController()
        {
            this.appConfig = LostPersonAppConfig.INSTANCE;
            ViewBag.appConfig = this.appConfig;
        }
    }
}