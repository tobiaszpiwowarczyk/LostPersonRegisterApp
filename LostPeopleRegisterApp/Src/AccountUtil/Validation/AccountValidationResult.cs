namespace LostPeopleRegisterApp.Src.AccountUtil.Validation
{
    /// <summary>
    /// Klasa ma za zadanie przechować dane odnośnie wyniku sprawdzania
    /// poprawności wprowadzonych danych
    /// </summary>
    public class AccountValidationResult
    {
        /// <summary>
        /// Nazwa wprowadzonego pola wejściowego
        /// </summary>
        public string fieldName { get; set; }

        /// <summary>
        /// Wynik sprawdzania poprawności danych
        /// </summary>
        public bool result { get; set; }
        


        public AccountValidationResult(string fieldName, bool result)
        {
            this.fieldName = fieldName;
            this.result = result;
        }
    }
}