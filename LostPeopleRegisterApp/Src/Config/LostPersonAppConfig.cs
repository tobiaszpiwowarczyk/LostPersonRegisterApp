using System.Configuration;

namespace LostPeopleRegisterApp.Src.Config
{
    public sealed class LostPersonAppConfig : ConfigurationSection
    {
        private static LostPersonAppConfig instance;

        private LostPersonAppConfig() {}

        public static LostPersonAppConfig INSTANCE
        {
            get => instance != null ? instance : instance = (LostPersonAppConfig)ConfigurationManager.GetSection("LostPersonApp");
        }

        [ConfigurationProperty("application")]
        public ApplicationConfig application
        {
            get => this["application"] as ApplicationConfig;
        }
    }
}