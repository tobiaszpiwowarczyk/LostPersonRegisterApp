using System.Data.Entity;

namespace LostPeopleRegisterApp.Src.CustomDatabaseUtil
{
    /// <summary>
    /// Klasa posiadająca zestaw metód, które rozbudowują możliwości konfiguracji encji.
    /// </summary>
    internal class ModelBuilderUtils
    {
        /// <summary>
        /// Pole przechowujące instancję obiektu, który konfiguruje modele danych
        /// </summary>
        private DbModelBuilder modelBuilder { get; set; }


        public ModelBuilderUtils(DbModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }


        /// <summary>
        /// Metoda ta ma za zadanie skonfigurować klasę typu przekazanego jako generyk do tego,
        /// by dane były zapisywane także z klasy bazowej.
        /// </summary>
        /// <typeparam name="T">Klasa, która ma być skonfigurowana</typeparam>
        /// <param name="toTableName">Nazwa tabeli, w której będą zapisane dane</param>
        internal void createInheritanceMapping<T>(string toTableName) where T : class
        {
            this.modelBuilder.Entity<T>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable(toTableName);
            });
        }
    }
}