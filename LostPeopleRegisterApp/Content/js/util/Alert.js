/*
 * Klasa jest odpowiedzialna za zarządzanie kontrolką wyświetlającą różne komunikaty
 */
export default class Alert {
    /*
     * @selector - selektor elementu, który będzie kontrolką do zarządzania
     */
    constructor(selector) {
        this.wrapper = document.querySelector(selector);
        
        this.opened = false;
        this.progressTime = 3000;
        this.showTime = 200;


        this.wrapper.querySelector(".alert__close-button").addEventListener("click", () => {
            this.opened = false;
            this.wrapper.classList.remove("alert--shown");
        }, false);
    }


    /*
     * Metoda ma za zadanie pokazać powiadomienie na ekranie.
     * Metoda ta ma również za zadanie ukrywać kontrolkę po upływie odpowiedniego czasu
     */
    show() {
        this.opened = true;
        this.wrapper.classList.add("alert--shown");
        setTimeout(() => {
            if (this.opened) {
                this.opened = false;
                this.wrapper.classList.remove("alert--shown");
            }
        }, this.progressTime + this.showTime);
    }


    /*
     * Metoda ma za zadanie ustawić wartość tekstową, która będzie się wyświetlała
     * w powiadomieniu
     * 
     * @content - zawartość, która ma być wstawiona
     */
    setContent = (content) => this.wrapper.querySelector(".alert__content").innerHTML = content;
}