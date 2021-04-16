using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using LostPeopleRegisterApp.Src.LostPersonUtil.Address.ConverterUtil;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.Address
{
    /// <summary>
    /// Klasa mająca za zadanie przechowywać informacje o adresie zamieszkania
    /// osoby zaginionej
    /// </summary>
    /// <see cref="BaseEntity"/>
    [JsonConverter(typeof(LostPersonAddressJsonConverter))]
    public abstract class LostPersonAddress : BaseEntity
    {
        /// <summary>
        /// Identyfikator osoby zaginionej
        /// </summary>
        [Column("lost_person_id")]
        [Required]
        [Index(IsUnique = true)]
        [JsonIgnore]
        public int lostPersonId { get; set; }

        /// <summary>
        /// Osoba zaginiona
        /// </summary>
        /// <see cref="LostPerson"/>
        [JsonIgnore]
        public virtual LostPerson lostPerson { get; set; }

        /// <summary>
        /// Numer mieszkania
        /// </summary>
        [Column("apartment_number")]
        [Required]
        public int apartmentNumber { get; set; }
    }
}