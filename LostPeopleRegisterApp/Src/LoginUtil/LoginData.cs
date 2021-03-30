namespace LostPeopleRegisterApp.Src.LoginUtil
{
    /// <summary>
    /// Klasa ma za zadanie przecowywać dane podczas próby logowania użytkownika
    /// </summary>
    public class LoginData
    {
        /// <summary>
        /// Nazwa użytkownika
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Hasło
        /// </summary>
        public string password { get; set; }
    }
}