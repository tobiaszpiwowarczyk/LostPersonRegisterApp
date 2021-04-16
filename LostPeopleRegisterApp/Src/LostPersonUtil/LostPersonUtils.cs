namespace LostPeopleRegisterApp.Src.LostPersonUtil
{
    /// <summary>
    /// Klasa zawiera zestaw metód do zarządzania obiektami z
    /// danymi osób zaginionych
    /// </summary>
    public class LostPersonUtils
    {
        /// <summary>
        /// Metoda ma za zadanie zwrócić pełną ścieżkę do folderu osoby zaginionej,
        /// w którym mogą znajdować się zdjęcia
        /// </summary>
        /// <param name="lostPerson">Dane osoby zaginionej</param>
        /// <returns>
        ///     Zwracany jest ciąg znaków zawierający zawierający ścieżkę do folderu ze zdjęciami
        ///     osoby zaginionej
        /// </returns>
        /// <see cref="LostPerson"/>
        public static string getFullFilePath(LostPerson lostPerson)
            => lostPerson.account.username + "\\lost-people\\" + lostPerson.id + "-" + lostPerson.firstName + lostPerson.lastName;
    }
}