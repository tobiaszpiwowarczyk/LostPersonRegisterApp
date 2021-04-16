using LostPeopleRegisterApp.Src.Util;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LostPeopleRegisterApp.Src.LostPersonUtil
{
    /// <summary>
    /// Klasa będąca repozytorium, odpowiedzialna za zarządzanie listą osób zaginionych.
    /// </summary>
    /// <see cref="AbstractRepository{T}"/>
    /// <see cref="LostPerson"/>
    public sealed class LostPersonRepository : AbstractRepository<LostPerson>
    {
        /// <summary>
        /// Pole przechowujące instancję tej klasy
        /// </summary>
        private static LostPersonRepository instance;
        protected override DbSet<LostPerson> collection => this.context.lostPeople;


        private LostPersonRepository() { }


        /// <summary>
        /// Pole zwracające instancję tej klasy
        /// </summary>
        public static LostPersonRepository INSTANCE
        {
            get => instance != null ? instance : instance = new LostPersonRepository();
        }





        /// <summary>
        /// Metoda ma za zadanie zwrócić listę ostatnio utworzonych osób zaginionych w
        /// bazie danych. Metoda ogranicza wynik do ilości podanej w parametrze
        /// </summary>
        /// <param name="ammount">Docelowa liczba osób zaginionych do zwrócenia</param>
        /// <returns>
        ///     Zwracana jest lista ostatnio zarejestrowanych osób zaginionych
        /// </returns>
        /// <see cref="LostPerson"/>
        public List<LostPerson> findLastCreatedLostPeople(int ammount)
            => this.collection.AsNoTracking().OrderByDescending(x => x.createdDate).Take(ammount).ToList();



        /// <summary>
        /// Metoda zwraca ostatnio utworzoną osobę zaginioną
        /// </summary>
        /// <returns></returns>
        /// <see cref="LostPerson"/>
        public LostPerson getLastCreatedLostPerson() => this.collection.AsNoTracking().Include(x => x.account).Include(x => x.status).OrderByDescending(x => x.createdDate).FirstOrDefault();



        /// <summary>
        /// Metoda ma za zadanie zwrócić listę osób zaginionych utworzonych przez dane konto
        /// </summary>
        /// <param name="accountId">Identyfikator konta</param>
        /// <returns>
        ///     Zwraca listę osób zaginionyhc, gdzie identyfikator konta, które utworzyło
        ///     daną osobę jest równa przekazanemu parametrowi
        /// </returns>
        /// <see cref="LostPerson"/>
        public List<LostPerson> findByAccountId(int accountId)
            => this.collection.AsNoTracking().Include(x => x.account).Include(x => x.status).Where(x => x.createdAccountId == accountId).ToList();
    }
}