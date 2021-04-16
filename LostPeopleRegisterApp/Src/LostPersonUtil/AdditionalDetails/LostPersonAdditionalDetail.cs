using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.AdditionalDetails
{
    /// <summary>
    /// Klasa na za zadanie przechować informacje o dodatkowej informacji zaginionej osoby
    /// </summary>
    /// <see cref="BaseEntity"/>
    [Table("lost_person_additional_details")]
    public class LostPersonAdditionalDetail : BaseEntity
    {
        /// <summary>
        /// Identyfikator osoby zagnionej
        /// </summary>
        [Column("lost_person_id")]
        [Required]
        public int lostPersonId { get; set; }

        /// <summary>
        /// Referencja do osoby zaginionej, która ma daną dodatkową cechę
        /// </summary>
        /// <see cref="LostPerson"/>
        public virtual LostPerson lostPerson { get; set; }

        /// <summary>
        /// Nazwa atrybutu
        /// </summary>
        [Required]
        public string attribute { get; set; }

        /// <summary>
        /// Wartość atrybutu
        /// </summary>
        [Required]
        public string value { get; set; }
    }
}