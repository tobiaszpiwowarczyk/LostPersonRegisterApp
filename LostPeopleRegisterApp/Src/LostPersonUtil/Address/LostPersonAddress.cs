using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.Address
{
    /// <summary>
    /// Klasa mająca za zadanie przechowywać informacje o adresie zamieszkania
    /// osoby zaginionej
    /// </summary>
    /// <see cref="BaseEntity"/>
    public abstract class LostPersonAddress : BaseEntity
    {
        /// <summary>
        /// Identyfikator osoby zaginionej
        /// </summary>
        [Column("lost_person_id")]
        [Required]
        [Index(IsUnique = true)]
        public int lostPersonId { get; set; }

        /// <summary>
        /// Osoba zaginiona
        /// </summary>
        /// <see cref="LostPerson"/>
        public LostPerson lostPerson { get; set; }

        /// <summary>
        /// Numer mieszkania
        /// </summary>
        [Column("apartment_number")]
        [Required]
        public int apartment_number { get; set; }
    }
}