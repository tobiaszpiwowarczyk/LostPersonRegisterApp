using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.Status
{
    [Table("lost_person_status")]
    public class LostPersonStatus : BaseEntity
    {
        [Required]
        public string name { get; private set; }
    }
}