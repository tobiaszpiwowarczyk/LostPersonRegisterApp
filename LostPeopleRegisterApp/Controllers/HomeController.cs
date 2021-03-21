using LostPeopleRegisterApp.Src.AccountUtil;
using LostPeopleRegisterApp.Src.LostPersonUtil;
using LostPeopleRegisterApp.Src.Util;
using System.Web.Mvc;

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

        
        public HomeController()
        {
            this.lostPersonRepository = LostPersonRepository.INSTANCE;
        }


        /// <summary>
        /// Metoda ta zwraca domyślną stronę do strony głównej
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.lostPersonList = this.lostPersonRepository.findAll();
            ViewBag.currentlyLoggedUser = (Account)Session["account"];

            return View();
        }
    }
}