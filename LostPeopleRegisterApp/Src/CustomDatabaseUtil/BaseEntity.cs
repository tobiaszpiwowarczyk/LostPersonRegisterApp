using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.CustomDatabaseUtil
{
    /// <summary>
    /// Klasa abstrakcyjna, która posłuży do tworzenia encji, czyli
    /// klas, które będą reprezentowały model rekordu odpowiedniej tabeli w bazie
    /// danych.
    /// Zawiera zestaw pól, które są wspólne na wszystkie tabele w bazie
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
    }
}