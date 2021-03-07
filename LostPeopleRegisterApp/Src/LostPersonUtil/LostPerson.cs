using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using LostPeopleRegisterApp.Src.LostPersonUtil.AdditionalDetails;
using LostPeopleRegisterApp.Src.LostPersonUtil.Address;
using LostPeopleRegisterApp.Src.LostPersonUtil.Image;
using LostPeopleRegisterApp.Src.AccountUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LostPeopleRegisterApp.Src.LostPersonUtil.Status;

namespace LostPeopleRegisterApp.Src.LostPersonUtil
{
    [Table("lost_person")]
    public class LostPerson : BaseEntity
    {
        [Column("created_account_id")]
        [Required]
        public int createdAccountId { get; set; }

        public Account account { get; set; }

        [Column("first_name")]
        [Required]
        public string firstName { get; set; }

        [Column("last_name")]
        [Required]
        public string lastName { get; set; }

        [Column("lost_person_date")]
        [Required]
        public DateTime lostPersonDate { get; set; }

        [Column("last_place_name")]
        [Required]
        public string lastPlaceName { get; set; }

        [Required]
        public int height { get; set; }

        [Column("created_date")]
        [Required]
        public DateTime createdDate { get; set; }

        [Column("status_id")]
        [Required]
        public int statusId { get; set; }

        public LostPersonStatus status { get; set; }

        public LostPersonAddress address { get; set; }

        public virtual List<LostPersonImage> images { get; set; } = new List<LostPersonImage>();

        public virtual List<LostPersonAdditionalDetail> additionalDetails { get; set; } = new List<LostPersonAdditionalDetail>();
    }
}