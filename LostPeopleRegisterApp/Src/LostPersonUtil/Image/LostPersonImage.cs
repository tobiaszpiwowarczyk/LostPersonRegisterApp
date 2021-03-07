using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.Image
{
    [Table("lost_person_image")]
    public class LostPersonImage : BaseEntity
    {
        [Column("lost_person_id")]
        [Required]
        public int lostPersonId { get; set; }

        public LostPerson lostPerson { get; set; }

        [Column("image_name")]
        [Required]
        public string imageName { get; set; }
    }
}