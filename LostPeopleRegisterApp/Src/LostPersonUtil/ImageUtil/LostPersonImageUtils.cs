using System;
using System.IO;

namespace LostPeopleRegisterApp.Src.LostPersonUtil.ImageUtil
{
    /// <summary>
    /// Klasa zawiera zestaw metód do zarządzania zdjeciami osób zaginionych
    /// </summary>
    public class LostPersonImageUtils
    {
        /// <summary>
        /// Metoda ma za zadanie skonwertować odczytane zdjecie na
        /// ciąg znaków w postaci BASE64.
        /// </summary>
        /// <param name="imageName">Ścieżka do zdjęcia</param>
        /// <returns>
        ///     Zwracany jest ciąg znaków w postaci BASE64
        /// </returns>
        public static string convertImageToBase64(string imageName) => Convert.ToBase64String(File.ReadAllBytes(imageName));
    }
}