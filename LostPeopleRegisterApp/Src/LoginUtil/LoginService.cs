using LostPeopleRegisterApp.Src.AccountUtil;
using System.Web;

namespace LostPeopleRegisterApp.Src.LoginUtil
{
    /// <summary>
    /// Klasa ma za zadanie zarządzać sesją zalogowanego użytkownika
    /// </summary>
    public sealed class LoginService
    {
        /// <summary>
        /// Pole statyczne przechowujące nazwę pola, w którym sesja będzie przechowywać informacje
        /// o koncie użytkownika
        /// </summary>
        private static readonly string SESSION_ACCOUNT = "account";

        /// <summary>
        /// Repozytorium do zarządzania kontami użytkowników
        /// </summary>
        /// <see cref="AccountRepository"/>
        private AccountRepository accountRepository;

        /// <summary>
        /// Pole przechowujące informacje o sesji
        /// </summary>
        private HttpSessionStateBase session;


        
        public LoginService(HttpSessionStateBase session)
        {
            this.accountRepository = AccountRepository.INSTANCE;
            this.session = session;
        }



        /// <summary>
        /// Metoda ma za zdanie zalogowac użytkownika do serwisu
        /// </summary>
        /// <param name="loginData">Dane logowania użytkownika</param>
        /// <see cref="LoginData"/>
        public void login(LoginData loginData) => session[SESSION_ACCOUNT] = this.accountRepository.findByUsernameAndPassword(loginData.username, loginData.password);



        /// <summary>
        /// Metoda ma za zadanie wylogować użytkownika
        /// </summary>
        public void logout() => session[SESSION_ACCOUNT] = null;



        /// <summary>
        /// Metoda ma za zadanie zwrócić zalogowanego uzytkownika
        /// </summary>
        /// <returns></returns>
        /// <see cref="Account"/>
        public Account getCurrentlyLoggedAccount() => (Account) session[SESSION_ACCOUNT];



        /// <summary>
        /// Metoda sprawdza, czy użytkownik jest zalogowany
        /// </summary>
        /// <returns>
        ///     Zwraca 'true' jeżeli użytkownik jest aktualnie zalogowany do serwisu.
        ///     Zawraca 'false' w przeciwnym przypadku
        /// </returns>
        public bool isAccountLogged() => this.getCurrentlyLoggedAccount() != null;



        /// <summary>
        /// Metoda ma za zadanie zaktualizować dane zalogowanego użytkownika
        /// </summary>
        /// <param name="account">Zaktualizowane konto</param>
        /// <see cref="Account"/>
        public void update(Account account) => session[SESSION_ACCOUNT] = account;
    }
}