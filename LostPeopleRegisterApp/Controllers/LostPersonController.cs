using LostPeopleRegisterApp.Src.LostPersonUtil;
using LostPeopleRegisterApp.Src.LostPersonUtil.ImageUtil;
using LostPeopleRegisterApp.Src.Util;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace LostPeopleRegisterApp.Controllers
{
    /// <summary>
    /// Klasa będąca kontrolerem zarządzającym osobami zaginionymi
    /// </summary>
    public class LostPersonController : AbstractController
    {
        /// <summary>
        /// Serwis do zarządzania osobami zaginionymi
        /// </summary>
        /// <see cref="LostPersonService"/>
        private LostPersonService lostPersonService { get; set; }



        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            this.lostPersonService = new LostPersonService(this.loginService);
        }



        /// <summary>
        /// Metoda ma za zadanie zwrócić i wyświetlić stronę główną do wyświetlenia 
        /// wyniku wyszukiwania osób zaginionych
        /// </summary>
        /// <param name="q">Podstawowe kryteria wyszukiwania osoby zaginionej</param>
        /// <param name="criteria">
        ///     Informacja o tym, czy należy korzystać z podstawowego lub zaawansowanego
        ///     wyszukiwania osób zaginionych
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(string q, bool criteria = false)
        {
            LostPersonSearchCriteria searchCriteria = (LostPersonSearchCriteria)Session["searchCriteria"];

            ViewBag.query = q;
            ViewBag.criteria = searchCriteria;
            ViewBag.lostPeople = criteria ? this.lostPersonService.findByAdvancedCriteria(searchCriteria) : this.lostPersonService.findByBasicCriteria(q);
            ViewBag.currentlyLoggedUser = this.loginService.getCurrentlyLoggedAccount();

            return View();
        }



        /// <summary>
        /// Metoda ma za zadanie zwrócić i wyświetlić stronę ze szczegółami osoby zaginionej
        /// </summary>
        /// <param name="lostPersonId">Identyfikator osoby zaginionej</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(int lostPersonId)
        {
            ViewBag.lostPerson = this.lostPersonService.findById(lostPersonId);
            ViewBag.currentlyLoggedUser = this.loginService.getCurrentlyLoggedAccount();
            return View();
        }



        /// <summary>
        /// Metoda ma za zadanie stworzyć nową osobę zaginioną do bazy
        /// </summary>
        /// <returns>
        ///     Zwraca obiekt JSON z informacją o poporawnym utworzeniu nowj osoby zaginionej
        /// </returns>
        [HttpPost]
        public ActionResult createLostPerson()
        {
            this.lostPersonService.createLostPerson(JsonConvert.DeserializeObject<LostPerson>(Request.Form["document"], new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            }), Request.Files);

            return Json(new { created = true });
        }



        /// <summary>
        /// Metoda ma za zadanie wyszukać listę osób zaginionych według wprowadzonej w wyszukiwarkę wartości
        /// </summary>
        /// <param name="q">Wprowadzona wartość w wyszukiwarce</param>
        /// <returns>
        ///     Zwraca obiekt w postaci JSON-a z danymi osób zaginionych spełniających kryteria wyszukiwania
        /// </returns>
        [HttpGet]
        public ActionResult findByBasicCriteria(string q) 
            => Json(this.lostPersonService.findByBasicCriteria(q)
                    .Select(x => new { x.id, x.firstName, x.lastName, image = x.images.Count > 0 ? LostPersonImageUtils.convertImageToBase64(this.appConfig.dataFolder.path + LostPersonUtils.getFullFilePath(x) + "\\" + x.images[0].imageName) : "" }).ToList());



        /// <summary>
        /// Metoda ma za zadanie dostarczyć kryteria do wykonania zaawansowanego wyszukiwania
        /// osób zaginionych
        /// </summary>
        /// <param name="criteria">Obiekt zawierający zaawansowane kryteria</param>
        /// <returns>
        ///     Zwraca obiekt w postaci JSON z informacją o poprawnym wprowadzeniu zaawansowanych kryteriów wyszukiwania
        /// </returns>
        /// <see cref="LostPersonSearchCriteria"/>
        [HttpPost]
        public ActionResult provideAdvancedCriteria(LostPersonSearchCriteria criteria)
        {
            Session["searchCriteria"] = criteria;
            return Json(new { created = Session["searchCriteria"] != null });
        }



        /// <summary>
        /// Metoda ma za zadanie oznaczyć osobę zaginioną jako osobę odnalezioną
        /// </summary>
        /// <param name="lostPersonId">Identyfikator osoby zaginionej</param>
        /// <returns>
        ///     Zwraca obiekt w postaci JSON z informacją o poprawnym zaktualizowaniu danych osoby zaginionej
        /// </returns>
        [HttpPost]
        public ActionResult makeLostPersonFound(int lostPersonId)
        {
            this.lostPersonService.makeLostPersonFound(lostPersonId);
            return Json(new { updated = true });
        }
    }
}