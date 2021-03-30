namespace LostPeopleRegisterApp.Src.AccountUtil
{
    /// <summary>
    /// Klasa ma za zadanie przechowywać wprowadzone przez użytkownika hasła
    /// podczas próby jego zaktualizowania
    /// </summary>
    public class AccountUpdatePasswordEntity
    {
        /// <summary>
        /// Aktualnie posiadane przez użytownika hasło
        /// </summary>
        public string currentPassword { get; set; }

        /// <summary>
        /// Nowe hasło, które ma być ustawione
        /// </summary>
        public string newPassword { get; set; }

        /// <summary>
        /// Pole przechowujące ponownie wpisane nowe hasło w celu zatwierdzenia
        /// </summary>
        public string confirmedPassword { get; set; }
    }
}