/*
 * Klasa odpowiedzialna za zarządzanie nakładki ładowania.
 * Nakładka ta ma na celu pokazać uużytkownikowi, że nastąpi wykonywanie
 * długotrwałej operacji
 */
export default class LoadingOverlay {

    /*
     * @selector - selektor, który odnosi się do elementu, którym będzie można zarządzać
     */
    constructor(selector) {
        this.wrapper = document.querySelector(selector);
        this.showed = false;
    }


    /*
     * Metoda ma za zadanie pokazać nakładkę
     */
    show() {
        this.wrapper.classList.add("loading-overlay--shown");
        this.showed = true;
    }

    /*
     * Metoda ta ukrywa nakładkę ładowania.
     */
    hide() {
        this.wrapper.classList.remove("loading-overlay--shown");
        this.showed = false;
    }
}