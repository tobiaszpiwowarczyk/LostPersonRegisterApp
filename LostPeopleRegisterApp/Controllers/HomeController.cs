using LostPeopleRegisterApp.Src.LostPersonUtil;
using LostPeopleRegisterApp.Src.Util;
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
        /// Serwis do zarządzania listą osób zaginionych
        /// </summary>
        /// <see cref="LostPersonService"/>
        private LostPersonService lostPersonService { get; set; }




        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            this.lostPersonService = new LostPersonService(this.loginService);
        }



        /// <summary>
        /// Metoda ta zwraca domyślną stronę do strony głównej
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.lostPersonList = this.lostPersonService.findLastCreatedLostPeople(5);
            ViewBag.currentlyLoggedUser = this.loginService.getCurrentlyLoggedAccount();

            return View();
        }
    }
}