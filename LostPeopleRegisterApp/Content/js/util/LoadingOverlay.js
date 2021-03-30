/*
 * Klasa odpowiedzialna za zarządzanie nakładką ładowania.
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
        this.isFullScreen = this.wrapper.classList.contains("loading-overlay--full-screen");
    }


    /*
     * Metoda ma za zadanie pokazać nakładkę
     */
    show() {
        this.wrapper.classList.add("loading-overlay--shown");
        this.showed = true;
        if (this.isFullScreen)
            document.body.style.overflow = "hidden";
    }

    /*
     * Metoda ta ukrywa nakładkę ładowania.
     */
    hide() {
        this.wrapper.classList.remove("loading-overlay--shown");
        this.showed = false;
        if (this.isFullScreen)
            document.body.style.overflow = "auto";
    }
}