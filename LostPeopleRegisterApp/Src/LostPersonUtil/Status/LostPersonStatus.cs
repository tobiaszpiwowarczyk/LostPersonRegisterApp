﻿using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.Status
{
    /// <summary>
    /// Klasa przechowująca aktualny stan osoby zaginionej
    /// </summary>
    /// <see cref="BaseEntity"/>
    [Table("lost_person_status")]
    public class LostPersonStatus : BaseEntity
    {
        /// <summary>
        /// Nazwa stanu osoby zaginionej
        /// </summary>
        [Required]
        public string name { get; private set; }
    }
}