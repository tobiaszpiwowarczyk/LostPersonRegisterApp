using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LostPeopleRegisterApp.Src.AccountUtil.RoleUtil
{
    [Table("account_role")]
    public class AccountRole : BaseEntity
    {
        [Index(IsUnique = true)]
        public string name { get; set; }

        [JsonIgnore]
        public virtual List<Account> accounts { get; set; } = new List<Account>();
    }
}