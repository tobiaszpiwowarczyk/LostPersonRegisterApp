using LostPeopleRegisterApp.Src.AccountUtil;
using LostPeopleRegisterApp.Src.AccountUtil.Validation;
using LostPeopleRegisterApp.Src.Util;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace LostPeopleRegisterApp.Controllers
{
    /// <summary>
    /// Klasa, która jest kontrolerem do zarządzania rejestracją użytkownika
    /// </summary>
    /// <see cref="AbstractController"/>
    public class RegisterController : AbstractController
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
        /// Metoda ta ma zadanie wyświetlić stronę rejestracji użytkownika
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (this.loginService.isAccountLogged())
                return Redirect("/");

            return View();
        }



        /// <summary>
        /// Metoda ma za zadanie zarejestrować nowego konta do naszego systemu.
        /// </summary>
        /// <param name="account">Dane konta, które ma być zarejestrowane</param>
        /// <returns></returns>
        /// <see cref="Account"/>
        [HttpPost]
        public ActionResult doRegister(Account account)
        {
            account.accountRoleId = 1;
            this.accountRepository.create(account);
            return Json(new Dictionary<string, bool>() { { "registered", this.accountRepository.existsByUsername(account.username) } });
        }



        /// <summary>
        /// Metoda ta ma sprawdzać poprawnośc wprowadzanych danych w trakcie rejestracji
        /// </summary>
        /// <returns>
        ///     Zwraca ciąg znaków w postaci JSON, która zawierać będzie informacje o poprawności wprowadzonych danych.
        /// </returns>
        public ActionResult validate(Account account) => Json(new List<AccountValidationResult>()
            {
                new AccountValidationResult("username", account.username != null && !this.accountRepository.existsByUsername(account.username)),
                new AccountValidationResult("emailAddress", account.emailAddress != null && !this.accountRepository.existsByEmail(account.emailAddress))
            });
    }
}