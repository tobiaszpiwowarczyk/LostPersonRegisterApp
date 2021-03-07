using LostPeopleRegisterApp.Src.Util;
using System.Web.Mvc;

namespace LostPeopleRegisterApp.Controllers
{
    public class HomeController : AbstractController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}