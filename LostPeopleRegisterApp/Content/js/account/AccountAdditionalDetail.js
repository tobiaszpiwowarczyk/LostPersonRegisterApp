/*
 * Skrypt, który ma za zadanie zarządzać elementem
 * wyświetlającym znaki szczególne osoby zaginionej
 */
export default class AccountAdditionalDetail {
    // Nazwa atrybutu
    #attribute;

    // Wartość atrybutu
    #value;

    // Przycisk usuwający obiekt
    #closingButton;

    // Element przechowujący element
    #wrapper;


    /*
     * @attribute   - Nazwa atrybutu
     * @value       - wartość atrybutu
     */
    constructor(attribute, value) {
        var _self = this;

        this.#attribute = attribute;
        this.#value = value;

        this.onDelete = x => {};

        this.#closingButton = document.createElement("button");
        this.#closingButton.classList.add("button", "button--negative");
        this.#closingButton.style.fontFamily = "\"Font Awesome 5 Free\"";
        this.#closingButton.innerHTML = "&#xf00d;";

        this.#closingButton.addEventListener("click", () => {
            this.#wrapper.remove();
            _self.onDelete(_self);
        }, false);
    }




    /*
     * Metoda ma za zadanie skonstruować i zwrócić
     * nowy element, który będzie wyświetlał znak szczególny osoby zaginionej
     */
    print() {
        this.#wrapper = document.createElement("div");
        this.#wrapper.classList.add("account-additional-detail");
        
        var elemAttribute = document.createElement("div");
        elemAttribute.classList.add("account-additional-detail__attribute");
        elemAttribute.innerText = this.#attribute;

        var elemValue = document.createElement("div");
        elemValue.classList.add("account-additional-detail__value");
        elemValue.innerText = this.#value;

        var elemActions = document.createElement("div");
        elemActions.classList.add("account-additional-detail__actions");

        elemActions.appendChild(this.#closingButton);

        this.#wrapper.appendChild(elemAttribute);
        this.#wrapper.append(elemValue);
        this.#wrapper.append(elemActions);

        return this.#wrapper;
    }



    /*
     * Metoda ma za zadanie zwrócić dane znaku szczególnego w postaci obiektu
     */
    parseToObject = () => new Object({attribute: this.#attribute, value: this.#value});
}