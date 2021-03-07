using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.AdditionalDetails
{
    [Table("lost_person_additional_details")]
    public class LostPersonAdditionalDetail : BaseEntity
    {
        [Column("lost_person_id")]
        [Required]
        public int lostPersonId { get; set; }

        public LostPerson lostPerson { get; set; }

        [Required]
        public string attribute { get; set; }

        [Required]
        public string value { get; set; }
    }
}