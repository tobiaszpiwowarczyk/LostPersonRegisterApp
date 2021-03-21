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
    /// <summary>
    /// Klasa reprezentująca rekord tabeli przechowujące listę osób zaginionych.
    /// </summary>
    /// <see cref="BaseEntity"/>
    [Table("lost_person")]
    public class LostPerson : BaseEntity
    {
        /// <summary>
        /// Identyfikator konta użytkownika, który zarejestrował daną osobę
        /// </summary>
        [Column("created_account_id")]
        [Required]
        public int createdAccountId { get; set; }

        /// <summary>
        /// Konto użytkownika, który zarejestrował osobę zaginioną
        /// </summary>
        /// <see cref="Account"/>
        public Account account { get; set; }

        /// <summary>
        /// Imię osoby zaginionej
        /// </summary>
        [Column("first_name")]
        [Required]
        public string firstName { get; set; }

        /// <summary>
        /// Nazwisko osoby zaginionej
        /// </summary>
        [Column("last_name")]
        [Required]
        public string lastName { get; set; }

        /// <summary>
        /// Data, w której osoba była zaginiona
        /// </summary>
        [Column("lost_person_date")]
        [Required]
        public DateTime lostPersonDate { get; set; }

        /// <summary>
        /// Dane odnośnie ostatniego miejsca, gdzie osoba byłą widziana
        /// </summary>
        [Column("last_place_name")]
        [Required]
        public string lastPlaceName { get; set; }

        /// <summary>
        /// Wzrost osoby
        /// </summary>
        [Required]
        public int height { get; set; }

        /// <summary>
        /// Data utworzenia wpisu
        /// </summary>
        [Column("created_date")]
        [Required]
        public DateTime createdDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Identyfikator statusu osoby zaginionej
        /// </summary>
        [Column("status_id")]
        [Required]
        public int statusId { get; set; }

        /// <summary>
        /// Status osoby zaginionej
        /// </summary>
        /// <see cref="LostPersonStatus"/>
        public LostPersonStatus status { get; set; }

        /// <summary>
        /// Adres osoby zaginionej
        /// </summary>
        /// <see cref="LostPersonAddress"/>
        public LostPersonAddress address { get; set; }

        /// <summary>
        /// Lista zdjęć osoby zaginionej
        /// </summary>
        /// <see cref="LostPersonImage"/>
        public virtual List<LostPersonImage> images { get; set; } = new List<LostPersonImage>();

        /// <summary>
        /// Lista dodatkowych szczegółów osoby zaginionej
        /// </summary>
        /// <see cref="LostPersonAdditionalDetail"/>
        public virtual List<LostPersonAdditionalDetail> additionalDetails { get; set; } = new List<LostPersonAdditionalDetail>();
    }
}