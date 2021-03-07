using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.Address
{
    [Table("lost_person_address_city")]
    public class CityLostPersonAddress : LostPersonAddress
    {
        [Required]
        public string city { get; set; }

        [Required]
        public string street { get; set; }

        [Required]
        public int flatNumber { get; set; }
    }
}