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
        /// Metoda ta ma za zadanie wyciągnąć listę wszystkich osób zaginionych
        /// </summary>
        /// <returns>
        ///     Zwracana jest lista osób zaginionych.
        /// </returns>
        /// <see cref="LostPerson"/>
        public List<LostPerson> findAll() => this.collection.ToList();
    }
}