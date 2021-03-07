using System.Configuration;

namespace LostPeopleRegisterApp.Src.Config
{
    public class ApplicationConfig : ConfigurationElement
    {
        [ConfigurationProperty("fullName", IsKey = true, IsRequired = true)]
        public string fullName
        {
            get => this["fullName"].ToString();
            set => base["fullName"] = value;
        }
    }
}