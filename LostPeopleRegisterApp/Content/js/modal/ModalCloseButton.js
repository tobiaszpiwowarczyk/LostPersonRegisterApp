/*
 * Klasa, która będzie odpowiedzialna za zarzązdanie przyciskami w okienku dialogowym.
 * Przyciski te będą zamykać okno dialogowe i wysyłać odpowiednie parametry.
 */
export default class ModalCloseButton {
    constructor(element) {
        this.element = element;
        this.approve = this.element.classList.contains("modal__close-button--approve");
        this.buttonClickEvent = new CustomEvent("onbuttonclicked", {
            detail: {
                approved: this.approve
            }
        });

        this.buttonClicked = x => { };

        this.element.addEventListener("onbuttonclicked", x => this.buttonClicked({approved: x.detail.approved}), false);

        this.element.addEventListener("click", () => this.element.dispatchEvent(this.buttonClickEvent), false);
    }
}