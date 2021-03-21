using LostPeopleRegisterApp.Src.Util;
using System.Data.Entity;
using System.Linq;

namespace LostPeopleRegisterApp.Src.AccountUtil
{
    /// <summary>
    /// Klasa będąca repozytorium, który będzie zarządzać kontami
    /// użytkownika
    /// </summary>
    /// <see cref="AbstractRepository{T}"/>
    /// <see cref="Account"/>
    public class AccountRepository : AbstractRepository<Account>
    {
        /// <summary>
        /// Pole przechowujace instancję obiektu tej klasy
        /// </summary>
        private static AccountRepository instance;
        protected override DbSet<Account> collection => this.context.accounts;

        /// <summary>
        /// Pole, mające za zadanie zwracać instancję obiektu tej klasy
        /// </summary>
        public static AccountRepository INSTANCE
        {
            get => instance != null ? instance : instance = new AccountRepository();
        }


        /// <summary>
        /// Metoda ta ma zadanie zwrócić konto na podstawie wprowadzonego nazwy użytkownia i hasła.
        /// </summary>
        /// <param name="username">Nazwa użytkownika</param>
        /// <param name="password">Hasło</param>
        /// <returns>
        ///     Zwraca istniejące konto użytkownika.
        /// </returns>
        /// <see cref="Account" />
        public Account findByUsernameAndPassword(string username, string password) 
            => this.collection.FirstOrDefault(x => x.username == username && x.password == password);



        /// <summary>
        /// Metoda sprawdzająca, czy istnieje użytkownik na podstawie jego nazwy użytkownika
        /// </summary>
        /// <param name="username">Nazwa użytkownika</param>
        /// <returns>
        ///     Zwraca true, jeżeli istnieje użytkownik o podanej nazwie użtkownika.
        ///     W przeciwnym przypadku zwraca false.
        /// </returns>
        public bool existsByUsername(string username) => this.collection.ToList().Exists(x => x.username == username);



        /// <summary>
        /// Metoda ta sprawdza, czy istnieje użytkownik według jego nazwy użytkownika oraz hasła.
        /// </summary>
        /// <param name="username">Nazwa użytkownika</param>
        /// <param name="password">Hasło</param>
        /// <returns>
        ///     Zaraca true, jeżeli takowe konto istnieje.
        ///     Zwraca false w przeciwnym przypadku
        /// </returns>
        public bool existsByUsernameAndPassword(string username, string password) => this.collection.ToList().Exists(x => x.username == username && x.password == password);



        /// <summary>
        /// Metoda ta sprawdza, czy istnieje użytkownik o wprowadzonym adresie e-mail.
        /// </summary>
        /// <param name="emailAddress">Adres e-mail</param>
        /// <returns>
        ///     Zwraca true, jeżeli takowe konto istnieje.
        ///     Zwraca false, w przeciwnym przypadku.
        /// </returns>
        public bool existsByEmail(string emailAddress) => this.collection.ToList().Exists(x => x.emailAddress == emailAddress);
    }
}