using LostPeopleRegisterApp.Src.AccountUtil;
using LostPeopleRegisterApp.Src.Util;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

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




        public LoginController()
        {
            this.accountRepository = AccountRepository.INSTANCE;
        }




        /// <summary>
        /// Metoda ta ma za zadanie wyswietlić stronę logowania
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() => View();



        /// <summary>
        /// Metoda ta ma za zadanie zalogować użytkownika wobec wprowadzonych danych
        /// logowania
        /// </summary>
        /// <param name="username">Nazwa użytkownika</param>
        /// <param name="password">Hasło</param>
        [HttpPost]
        public void doLogin(string username, string password)
        {
            Session["account"] = this.accountRepository.findByUsernameAndPassword(username, password);
        }



        /// <summary>
        /// Metoda ta ma zadanie sprawdzić poprawność wprowadzanych danych logowania
        /// </summary>
        /// <param name="username">Nazwa użytkownika</param>
        /// <param name="password">Hasło</param>
        /// <returns>
        ///     Zwraca ciąg znaków w postaci JSON, któy zawierać będzie stan walidacji wprowadzanych danych.
        /// </returns>
        [HttpPost]
        public string validate(string username, string password)
        {
            return JsonConvert.SerializeObject(new Dictionary<string, bool>() { { "valid", this.accountRepository.existsByUsernameAndPassword(username, password) } });
        }


        
        /// <summary>
        /// Metoda ta wylogowuje aktualnie zalogowego użytkownika.
        /// Po tym wszystkim aplikacja ponownie przekieowuje użytkownika na stronę główną
        /// </summary>
        /// <returns></returns>
        public ActionResult logout()
        {
            Session.Clear();
            return Redirect("/");
        }
    }
}