using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LostPeopleRegisterApp.Src.Util
{
    /// <summary>
    /// Klasa abstrakcyjna, która będzie wykorzystywana do tworzenia nowych repozytoriów do zarządzania danymi.
    /// </summary>
    /// <typeparam name="T">Typ klasy, którą będziemy zarządzać. Ważne, by byłą typu BaseEntity</typeparam>
    /// <see cref="BaseEntity"/>
    public abstract class AbstractRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Pole przechowujące obiekt do zarządzania danymi w bazie
        /// </summary>
        /// <see cref="CustomDatabaseContext"/>
        protected CustomDatabaseContext context { get; private set; }

        /// <summary>
        /// Pole do przechowania aktualnego zestawy danych, którymi będziemy zarządzać
        /// </summary>
        protected abstract DbSet<T> collection { get; }



        public AbstractRepository()
        {
            this.context = new CustomDatabaseContext();
        }



        /// <summary>
        /// Metoda ma za zadanie zwrócić wszystkie elementy zapisane w danej tabeli
        /// </summary>
        /// <returns></returns>
        public List<T> findAll() => this.collection.AsNoTracking().ToList();



        /// <summary>
        /// Metoda ma za zadanie wyszukać rekord według identyfikatora
        /// </summary>
        /// <param name="id">Identyfikator</param>
        /// <returns>
        ///     Zwraca znaleziony obiekt
        /// </returns>
        public virtual T findById(int id) => this.collection.AsNoTracking().FirstOrDefault(x => x.id == id);



        /// <summary>
        /// Metoda ma za zadanie dodać nowy obiekt do bazy danych.
        /// </summary>
        /// <param name="obj">Obiekt, któtu ma być zapisany do bazy</param>
        public virtual void create(T obj)
        {
            this.collection.Add(obj);
            this.context.SaveChanges();
            this.context.Entry(obj).Reload();
        }


        /// <summary>
        /// Metoda ta aktualizuje dany obiekt w bazie i zapisuje go do bazy
        /// </summary>
        /// <param name="obj">Obiekt, który ma być zaktualizowany</param>
        public virtual void update(T obj)
        {
            T existing = this.collection.FirstOrDefault(x => x.id == obj.id);
            context.Entry(existing).CurrentValues.SetValues(obj);
            context.SaveChanges();
        }
    }
}