using LostPeopleRegisterApp.Src.LoginUtil;
using LostPeopleRegisterApp.Src.LostPersonUtil;
using LostPeopleRegisterApp.Src.Util;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace LostPeopleRegisterApp.Controllers
{
    /// <summary>
    /// Klasa, będąca kontrolerem, który będzie zarządzać informacjami w stronie
    /// głównej aplikacji
    /// </summary>
    /// <see cref="AbstractController"/>
    public class HomeController : AbstractController
    {
        /// <summary>
        /// Repozytorium z listą osób zaginionych
        /// </summary>
        /// <see cref="LostPersonRepository"/>
        private LostPersonRepository lostPersonRepository { get; set; }


        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            this.lostPersonRepository = LostPersonRepository.INSTANCE;
        }



        /// <summary>
        /// Metoda ta zwraca domyślną stronę do strony głównej
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.lostPersonList = this.lostPersonRepository.findAll();
            ViewBag.currentlyLoggedUser = this.loginService.getCurrentlyLoggedAccount();

            return View();
        }
    }
}