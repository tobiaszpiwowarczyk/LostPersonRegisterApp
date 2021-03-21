using System.ComponentModel.DataAnnotations;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.Address
{
    /// <summary>
    /// Klasa mająca za zadanie przechowywać informacje o adresie zamieszkania
    /// osoby zaginionej w przypadku, gdy osoba mieszkała we wsi
    /// </summary>
    /// <see cref="LostPersonAddress"/>
    public class VillageLostPersonAddress : LostPersonAddress
    {
        /// <summary>
        /// Nazwa wsi
        /// </summary>
        [Required]
        public string village { get; set; }
    }
}