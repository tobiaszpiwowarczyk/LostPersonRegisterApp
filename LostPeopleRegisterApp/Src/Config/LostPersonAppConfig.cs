using System.Configuration;

namespace LostPeopleRegisterApp.Src.Config
{
    /// <summary>
    /// Klasa mająca za zadanie przechowywać podstawową konfiguracje całej aplikacji.
    /// Taką konfigurację należy zawrzeć w pliku Web.config
    /// </summary>
    public sealed class LostPersonAppConfig : ConfigurationSection
    {
        /// <summary>
        /// Pole przechowujące instancję tej klasy
        /// </summary>
        private static LostPersonAppConfig instance;


        private LostPersonAppConfig() {}


        /// <summary>
        /// Pole zwracające obiekt tej klasy
        /// </summary>
        public static LostPersonAppConfig INSTANCE
        {
            get => instance != null ? instance : instance = (LostPersonAppConfig)ConfigurationManager.GetSection("LostPersonApp");
        }


        /// <summary>
        /// Pole przechowujące ogólne konfiguracje naszej aplikacji
        /// </summary>
        /// <see cref="ApplicationConfig"/>
        [ConfigurationProperty("application")]
        public ApplicationConfig application
        {
            get => this["application"] as ApplicationConfig;
        }


        /// <summary>
        /// Pole przechowujące konfigurację folderu, w której będziemy przechowywać dodatkowe dane
        /// użytkownika
        /// </summary>
        /// <see cref="DataFolderConfig"/>
        [ConfigurationProperty("dataFolder")]
        public DataFolderConfig dataFolder
        {
            get => this["dataFolder"] as DataFolderConfig;
        }
    }
}