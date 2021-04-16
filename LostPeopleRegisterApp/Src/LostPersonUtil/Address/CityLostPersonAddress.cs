using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.Address
{
    /// <summary>
    /// Klasa mająca za zadanie przechowywać informacje o adresie zamieszkania
    /// osoby zaginionej w przypadku, gdy osoba mieszkała w mieście.
    /// </summary>
    /// <see cref="LostPersonAddress"/>
    [Table("lost_person_address_city")]
    public class CityLostPersonAddress : LostPersonAddress
    {
        /// <summary>
        /// Nazwa miasta
        /// </summary>
        [Required]
        public string city { get; set; }

        /// <summary>
        /// Nazwa ulicy
        /// </summary>
        [Required]
        public string street { get; set; }

        /// <summary>
        /// Numer mieszkania
        /// </summary>
        [Required]
        [Column("flat_number")]
        public int flatNumber { get; set; }
    }
}