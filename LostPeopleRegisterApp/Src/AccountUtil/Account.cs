using LostPeopleRegisterApp.Src.AccountUtil.RoleUtil;
using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using LostPeopleRegisterApp.Src.LostPersonUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.AccountUtil
{
    /// <summary>
    /// Klasa ma za zadanie odzwierciedlić model rekordu tabeli przechowującą 
    /// listę kont użytkówników
    /// </summary>
    /// <see cref="BaseEntity"/>
    [Table("account")]
    public class Account : BaseEntity
    {
        /// <summary>
        /// Nazwa użytkownika
        /// </summary>
        [Required]
        [Index(IsUnique = true)]
        public string username { get; set; }

        /// <summary>
        /// Hasło
        /// </summary>
        [Required]
        public string password { get; set; }

        /// <summary>
        /// Imię użytkownika
        /// </summary>
        [Required]
        [Column("first_name")]
        public string firstName { get; set; }

        /// <summary>
        /// Nazwisko użytkownika
        /// </summary>
        [Required]
        [Column("last_name")]
        public string lastName { get; set; }

        /// <summary>
        /// Adres e-mail
        /// </summary>
        [Required]
        [Column("email_address")]
        [Index(IsUnique = true)]
        public string emailAddress { get; set; }

        /// <summary>
        /// Data urodzenia użytkownika
        /// </summary>
        [Required]
        [Column("birth_date")]
        public DateTime birthDate { get; set; }

        /// <summary>
        /// Data utworzenia użytkownika
        /// </summary>
        [Required]
        [Column("created_date")]
        public DateTime createdDate { get; set; } = DateTime.Now;


        /// <summary>
        /// Identyfikator uprawnienia użytkownika
        /// </summary>
        [Required]
        [Column("account_role_id")]
        public int accountRoleId { get; set; }


        /// <summary>
        /// Lista osób zaginionych, które zostały utworzone przez to konto
        /// </summary>
        /// <see cref="LostPerson"/>
        public virtual List<LostPerson> lostPersonList { get; set; } = new List<LostPerson>();


        /// <summary>
        /// Obiekt zawierający dane uprawnień użytkownika
        /// </summary>
        /// <see cref="AccountRole"/>
        public virtual AccountRole accountRole { get; set; }
    }
}