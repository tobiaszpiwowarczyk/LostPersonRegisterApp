using System.ComponentModel.DataAnnotations;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.Address
{
    public class VillageLostPersonAddress : LostPersonAddress
    {
        [Required]
        public string village { get; set; }
    }
}