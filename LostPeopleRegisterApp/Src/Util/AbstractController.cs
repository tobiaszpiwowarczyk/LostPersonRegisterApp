using LostPeopleRegisterApp.Src.Config;
using LostPeopleRegisterApp.Src.LoginUtil;
using System.Web.Mvc;
using System.Web.Routing;

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


        /// <summary>
        /// Obiekt, który posłuży do zarządzania zalogowanymi użytkownikami
        /// </summary>
        /// <see cref="LoginService"/>
        protected LoginService loginService { get; private set; }




        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            this.appConfig = LostPersonAppConfig.INSTANCE;
            ViewBag.appConfig = this.appConfig;
            this.loginService = new LoginService(Session);
        }
    }
}