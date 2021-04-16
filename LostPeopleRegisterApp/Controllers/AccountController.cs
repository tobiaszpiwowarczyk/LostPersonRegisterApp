using LostPeopleRegisterApp.Src.AccountUtil;
using LostPeopleRegisterApp.Src.AccountUtil.Validation;
using LostPeopleRegisterApp.Src.Util;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace LostPeopleRegisterApp.Controllers
{
    /// <summary>
    /// Klasa, będąca kontrolerem do zarządzania zasobami, które będą widoczne na stronie
    /// do zarządzania danymi konta użytkownika
    /// </summary>
    /// <see cref="AbstractController"/>
    public class AccountController : AbstractController
    {
        /// <summary>
        /// Repozytorium do zarządzania kontami użytkowników
        /// </summary>
        /// <see cref="AccountRepository"/>
        private AccountRepository accountRepository { get; set; }



        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            this.accountRepository = AccountRepository.INSTANCE;
        }



        /// <summary>
        /// Metoda ma za zadanie wyświetlić stronę odpowiedzialną za wyśiwetlanie
        /// bądź ewentualną modyfikację danych konta użytkownika.
        /// Metoda sprawdza, czy użytkownik jest zalogowany.
        /// Jeżeli nie jest, wówczas jest przekierowywany na stronę główną.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (!this.loginService.isAccountLogged())
                return Redirect("/");
            else
            {
                ViewBag.currentlyLoggedUser = this.loginService.getCurrentlyLoggedAccount();
                ViewBag.currentPath = Request.Url.AbsolutePath;
            }

            return View();
        }



        /// <summary>
        /// Metoda ma za zadanie wywietlić stronę, która będzie 
        /// zawierała listę wszystkich użytkowników. Dostęp do tego mają
        /// tylko administratrzy
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            if (!this.loginService.isAccountLogged() || !AccountUtils.isAdmin(this.loginService.getCurrentlyLoggedAccount()))
                return Redirect("/");

            ViewBag.currentlyLoggedUser = this.loginService.getCurrentlyLoggedAccount();
            ViewBag.accounts = this.accountRepository.findAll();

            return View();
        }



        /// <summary>
        /// Metoda ma za zadanie zaktualizować dane użytkownika i zapisać te dane w bazie danych
        /// </summary>
        /// <param name="account">Dane konta, które mają być zaktualizowane</param>
        /// <returns>
        ///     Zwraca ciąg znaków w postaci JSON, który zawiera informacje o tym, czy dane użytkownika
        ///     zostały aktualizowane pomyślnie
        /// </returns>
        /// <see cref="Account"/>
        [HttpPost]
        public ActionResult updateAccountDetails(Account account)
        {
            Account currentAccount = AccountUtils.updateAccount(this.loginService.getCurrentlyLoggedAccount(), account);

            if (account.accountRoleId == 0)
            {
                currentAccount.accountRoleId = this.loginService.getCurrentlyLoggedAccount().accountRole.id;
            }

            this.accountRepository.update(currentAccount);
            this.loginService.update(currentAccount);

            ViewBag.currentlyLoggedUser = this.loginService.getCurrentlyLoggedAccount();

            return Json(new Dictionary<string, bool>() { { "updated", true } });
        }



        /// <summary>
        /// Metoda ma za zadanie zaktualizować uprawnienia użytkownika
        /// </summary>
        /// <param name="accountId">Identyfikator konta</param>
        /// <param name="roleId">Identyfikator roli, na którą należy zaktualizować</param>
        /// <returns>
        ///     Zwraca obiekt w postaci JSON z informacją o pomyślnej aktualizacji konta
        /// </returns>
        [HttpPost]
        public ActionResult updateAccountRole(int accountId, int roleId)
        {
            if (this.loginService.isAccountLogged() && AccountUtils.isAdmin(this.loginService.getCurrentlyLoggedAccount()))
            {
                Account foundAccount = this.accountRepository.findById(accountId);
                foundAccount.accountRoleId = roleId;
                this.accountRepository.update(foundAccount);

                return Json(new { updated = true });
            }

            return Json(new { updated = false });
        }



        /// <summary>
        /// Metoda ma za zadanie zaktualizować hasło użytkownika.
        /// </summary>
        /// <param name="updatePasswordEntity">Obiket, który przechowuje dane przesłane po zaktualizowaniu hasła</param>
        /// <returns>
        ///     Zwraca ciąg znaków jako w postaci JSON, który zawiera informacje o tym, 
        ///     czy hasło zostało zaktualizowane pomyślnie
        /// </returns>
        /// <see cref="AccountUpdatePasswordEntity"/>
        [HttpPost]
        public ActionResult updatePassword(AccountUpdatePasswordEntity updatePasswordEntity)
        {
            Account account = this.loginService.getCurrentlyLoggedAccount();
            account.password = updatePasswordEntity.newPassword;
            this.accountRepository.update(account);

            return Json(new Dictionary<string, bool>() { 
                { "updated", this.accountRepository.findByUsernameAndPassword(account.username, account.password).password == updatePasswordEntity.newPassword } 
            });
        }



        /// <summary>
        /// Metoda ta ma sprawdzać poprawność wprowadzanych danych w trakcie dodawania, bądź edycji danych konta
        /// </summary>
        /// <returns>
        ///     Zwraca ciąg znaków w postaci JSON, która zawierać będzie informacje o poprawności wprowadzonych danych.
        /// </returns>
        [HttpPost]
        public ActionResult validate(Account account) => Json(new List<AccountValidationResult>()
            {
                new AccountValidationResult(
                    "username",
                    account.username != null && (
                        this.loginService.getCurrentlyLoggedAccount().username == account.username ||
                        !this.accountRepository.existsByUsername(account.username)
                    )
                ),
                new AccountValidationResult(
                    "emailAddress",
                    account.emailAddress != null && (
                        this.loginService.getCurrentlyLoggedAccount().emailAddress == account.emailAddress ||
                        !this.accountRepository.existsByEmail(account.emailAddress)
                    )
                ),
                new AccountValidationResult(
                    "password",
                    account.password != null && (
                        this.loginService.getCurrentlyLoggedAccount().password == account.password
                    )
                )
            });
    }
}