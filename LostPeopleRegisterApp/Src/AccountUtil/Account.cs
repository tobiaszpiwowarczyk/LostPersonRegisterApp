using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using LostPeopleRegisterApp.Src.LostPersonUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.AccountUtil
{
    [Table("account")]
    public class Account : BaseEntity
    {
        [Required]
        [Index(IsUnique = true)]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string emailAddress { get; set; }

        [Required]
        public DateTime birthDate { get; set; }

        [Required]
        public DateTime createdDate { get; set; } = DateTime.Now;

        public virtual List<LostPerson> lostPersonList { get; set; } = new List<LostPerson>();
    }
}