using System;

namespace LostPeopleRegisterApp.Src.LostPersonUtil
{
    /// <summary>
    /// Klasa ma za zadanie przechowywać dane kryterów zaawansowanego
    /// wyszukiwania
    /// </summary>
    public class LostPersonSearchCriteria
    {
        /// <summary>
        /// Minimalny wzrost
        /// </summary>
        public int? minHeight { get; set; }

        /// <summary>
        /// Maksymalny wzrost
        /// </summary>
        public int? maxHeight { get; set; }

        /// <summary>
        /// Minimalna data zaginięcia osoby
        /// </summary>
        public DateTime? minLostPersonDate { get; set; }

        /// <summary>
        /// Maksymalna data zaginięcia osoby
        /// </summary>
        public DateTime? maxLostPersonDate { get; set; }

        /// <summary>
        /// Ostatnie miejsce pobytu osoby
        /// </summary>
        public string lastPlaceName { get; set; }

        /// <summary>
        /// Identyfikator statusu zaginionego
        /// </summary>
        public int? statusId { get; set; }
    }
}