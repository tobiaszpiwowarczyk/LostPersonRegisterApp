using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using Newtonsoft.Json;
using System.Collections.Generic;
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
        public string name { get; set; }

        /// <summary>
        /// Lista osób zaginionych o danym statusie
        /// </summary>
        /// <see cref="LostPerson"/>
        [JsonIgnore]
        public virtual List<LostPerson> lostPeople { get; set; } = new List<LostPerson>();
    }
}