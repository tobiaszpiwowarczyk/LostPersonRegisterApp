/*
 * Klasa jest odpowiedzialna na przechowywanie domyślnych konfiguracji
 * zdjęcia profiowego
 */
export default class ProfileImageData {
    constructor() {
        // Szerokość i wysokość zdjęcia
        this.width = "100%";

        // Informacja o tym, czy rogi zdjecia mają być zaokrąglone
        this.cornered = false;

        // Informacja o tym, czy zdjecie powinno zawierać cień
        this.shadowed = true;

        // Obraz, który ma być wyświetlany
        this.image = "";

        // Rozmiar wyświetlanej ikonki obrazka. Ikonka będzie się wyświtlać
        // w przypadku, gdy obraz nie będzie wczytany
        this.iconFontSize = "72px";
    }
}