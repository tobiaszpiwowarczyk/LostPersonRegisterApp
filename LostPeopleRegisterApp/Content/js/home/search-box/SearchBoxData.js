/*
 * Klasa jest odpowiedzialna za przechowywanie podstawowych
 * danych konfiguracyjnych pola wyszukującego
 */
export default class SearchBoxData {
    constructor() {
        // Wymagana liczba znaków do wpisania w wyszukiwarkę
        this.requiredCharsCount = 3;

        // Adres do punktu wyszukiwania danych
        this.searchResultUrl = "/lostPerson";
    }
}