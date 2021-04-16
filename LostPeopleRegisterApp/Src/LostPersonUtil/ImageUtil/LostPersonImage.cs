using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.ImageUtil
{
    /// <summary>
    /// Klasa przechowująca informacje o zdjęciu osoby zaginionej
    /// </summary>
    /// <see cref="BaseEntity"/>
    [Table("lost_person_image")]
    public class LostPersonImage : BaseEntity
    {
        /// <summary>
        /// Identyfikator osoby zaginionej
        /// </summary>
        [Column("lost_person_id")]
        [Required]
        [JsonIgnore]
        public int lostPersonId { get; set; }

        /// <summary>
        /// Osoba zaginiona
        /// </summary>
        /// <see cref="LostPerson"/>
        [JsonIgnore]
        public virtual LostPerson lostPerson { get; set; }

        /// <summary>
        /// Nazwa zdjęcia
        /// </summary>
        [Column("image_name")]
        [Required]
        public string imageName { get; set; }
    }
}