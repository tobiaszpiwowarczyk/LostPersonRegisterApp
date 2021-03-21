using System.Configuration;

namespace LostPeopleRegisterApp.Src.Config
{
    /// <summary>
    /// Klasa mająca za zadanie przechowywać podstawową konfiguracje dotyczących aplikacji.
    /// Taką konfigurację należy zawrzeć w pliku Web.config i powinna mieć następującą postać:
    /// 
    /// <configuration>
    ///     ...
    ///     <LostPersonApp>
    ///         ...
    ///         <application fullName="..." />
    ///         ...
    ///     </LostPersonApp>
    ///     ...
    /// </configuration>
    /// 
    /// </summary>
    public class ApplicationConfig : ConfigurationElement
    {
        /// <summary>
        /// Pole, które będzie przechowywać pełną nazwę aplikacji, która będzie się
        /// wyświetlać na stronie.
        /// </summary>
        [ConfigurationProperty("fullName", IsKey = true, IsRequired = true)]
        public string fullName
        {
            get => this["fullName"].ToString();
            set => base["fullName"] = value;
        }
    }
}