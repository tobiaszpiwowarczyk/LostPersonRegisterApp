using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.Address
{
    public abstract class LostPersonAddress : BaseEntity
    {
        [Column("lost_person_id")]
        [Required]
        [Index(IsUnique = true)]
        public int lostPersonId { get; set; }

        public LostPerson lostPerson { get; set; }

        [Column("apartment_number")]
        [Required]
        public int apartment_number { get; set; }
    }
}