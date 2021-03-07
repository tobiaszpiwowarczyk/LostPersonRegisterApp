using LostPeopleRegisterApp.Src.Config;
using System.Web.Mvc;

namespace LostPeopleRegisterApp.Src.Util
{
    public class AbstractController : Controller
    {
        private LostPersonAppConfig appConfig { get; set; }

        public AbstractController()
        {
            this.appConfig = LostPersonAppConfig.INSTANCE;
            ViewBag.appConfig = this.appConfig;
        }
    }
}