using LostPeopleRegisterApp.Src.AccountUtil;
using LostPeopleRegisterApp.Src.LoginUtil;
using LostPeopleRegisterApp.Src.Util;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace LostPeopleRegisterApp.Controllers
{
    /// <summary>
    /// Klasa będąca kontrolerem zarządzającym stroną logowania
    /// </summary>
    /// <see cref="AbstractController"/>
    public class LoginController : AbstractController
    {
        /// <summary>
        /// Repozytorium z listą zarejestrowanych kont
        /// </summary>
        /// <see cref="AccountRepository"/>
        private AccountRepository accountRepository { get; set; }




        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            this.accountRepository = AccountRepository.INSTANCE;
        }




        /// <summary>
        /// Metoda ta ma za zadanie wyswietlić stronę logowania
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (this.loginService.isAccountLogged())
                return Redirect("/");

            return View();
        }



        /// <summary>
        /// Metoda ta ma za zadanie zalogować użytkownika wobec wprowadzonych danych
        /// logowania
        /// </summary>
        /// <param name="loginData">Obiekt z danymi logowania</param>
        /// <see cref="LoginData"/>
        [HttpPost]
        public void doLogin(LoginData loginData) => this.loginService.login(loginData);



        /// <summary>
        /// Metoda ta ma zadanie sprawdzić poprawność wprowadzanych danych logowania
        /// </summary>
        /// <param name="loginData">Obiekt z danymi logowania</param>
        /// <returns>
        ///     Zwraca ciąg znaków w postaci JSON, któy zawierać będzie stan walidacji wprowadzanych danych.
        /// </returns>
        /// <see cref="LoginData"/>
        [HttpPost]
        public ActionResult validate(LoginData loginData)
        {
            return Json(new Dictionary<string, bool>() { { "valid", this.accountRepository.existsByUsernameAndPassword(loginData.username, loginData.password) } });
        }


        
        /// <summary>
        /// Metoda ta wylogowuje aktualnie zalogowego użytkownika.
        /// Po tym wszystkim aplikacja ponownie przekieowuje użytkownika na stronę główną
        /// </summary>
        /// <returns></returns>
        public ActionResult logout()
        {
            this.loginService.logout();
            return Redirect("/");
        }
    }
}