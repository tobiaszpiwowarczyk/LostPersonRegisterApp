using System.Configuration;
using System.Web;

namespace LostPeopleRegisterApp.Src.Config
{
    /// <summary>
    /// Klasa mająca za zadanie przechowywać podstawową konfiguracje dotyczących folderu do dancyh użytkowników.
    /// Taką konfigurację należy zawrzeć w pliku Web.config i powinna mieć następującą postać:
    /// 
    /// <configuration>
    ///     ...
    ///     <LostPersonApp>
    ///         ...
    ///         <dataFolder path="..." />
    ///         ...
    ///     </LostPersonApp>
    ///     ...
    /// </configuration>
    /// 
    /// </summary>
    public class DataFolderConfig : ConfigurationElement
    {
        /// <summary>
        /// Pole przechowujące ścieżkę do folderu, w którym będziemy przechowywać dodatkowe dane użytkowników
        /// </summary>
        [ConfigurationProperty("path", IsKey = true, IsRequired = true)]
        public string path
        {
            get => HttpContext.Current.Server.MapPath(base["path"].ToString());
            set => base["path"] = value;
        }
    }
}