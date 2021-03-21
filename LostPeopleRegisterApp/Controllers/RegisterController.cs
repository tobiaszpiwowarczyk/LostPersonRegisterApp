using LostPeopleRegisterApp.Src.AccountUtil;
using LostPeopleRegisterApp.Src.AccountUtil.Validation;
using LostPeopleRegisterApp.Src.Util;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

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


        
        public RegisterController()
        {
            this.accountRepository = AccountRepository.INSTANCE;
        }




        /// <summary>
        /// Metoda ta ma zadanie wyświetlić stronę rejestracji użytkownika
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() => View();



        /// <summary>
        /// Metoda ma za zadanie zarejestrować nowego konta do naszego systemu.
        /// </summary>
        /// <param name="account">Dane konta, które ma być zarejestrowane</param>
        /// <returns></returns>
        /// <see cref="Account"/>
        [HttpPost]
        public string doRegister(Account account)
        {
            this.accountRepository.create(account);
            return JsonConvert.SerializeObject(new Dictionary<string, bool>() { { "registered", this.accountRepository.existsByUsername(account.username) } });
        }



        /// <summary>
        /// Metoda ta ma sprawdzać poprawnośc wprowadzanych danych w trakcie rejestracji
        /// </summary>
        /// <returns>
        ///     Zwraca ciąg znaków w postaci JSON, która zawierać będzie informacje o poprawności wprowadzonych danych.
        /// </returns>
        public string validate()
        {
            List<AccountValidationResult> validationResults = new List<AccountValidationResult>();

            string username = Request.Form["username"];
            string emailAddress = Request.Form["emailAddress"];

            if (username != null)
                validationResults.Add(new AccountValidationResult("username", !this.accountRepository.existsByUsername(username)));

            if (emailAddress != null)
                validationResults.Add(new AccountValidationResult("emailAddress", this.accountRepository.existsByEmail(emailAddress)));

            return JsonConvert.SerializeObject(validationResults);
        }
    }
}