import ModalCloseButton from "/Content/js/modal/ModalCloseButton.js";
import ModalType from "/Content/js/modal/ModalType.js";

/*
 * Klasa, która będzie zarządzać okienkiem dialogowym
 */
export default class Modal {
    
    /*
     * @overlaySelector - selector, który reprezentuje nakładkę, w której znajduje się okno dialogowe
     * @modalType       - typ komunikatu, który będzie się wyświetlał.
     */
    constructor(overlaySelector, modalType = ModalType.INFO) {
        var _self = this;

        this.overlay = document.querySelector(overlaySelector);
        this.modalType = modalType;

        this.modal = this.overlay.querySelector(".modal");
        this.content = this.modal.querySelector(".modal__content").innerHTML;
        
        this.shown = false;
        this.modalOpenTime = 200;
        this.showEvent = new CustomEvent("onshown");
        this.closeEvent = new CustomEvent("onclosed", {
            detail: {
                approved: false,
                preventClosing: false
            }
        });
        this.onOpen = () => {};
        this.onClose = x => {};
        this.onCloseStart = x => Promise.resolve(x);

        document.body.style.setProperty("--modalOpenTime", `${this.modalOpenTime}ms`);
        
        if (this.modal.querySelector(".modal__header__title").innerHTML == "")
            this.modal.querySelector(".modal__header__title").innerHTML = this.modalType.title;

        this.modal.querySelector(".modal__header__icon").style.color = this.modalType.color;
        this.modal.querySelector(".modal__header__icon i").classList.add(this.modalType.iconName);

        this.closeButtons = [...this.modal.querySelectorAll(".modal__close-button")].map(x => new ModalCloseButton(x));
        
        this.closeButtons.forEach(closeButton => {
            closeButton.buttonClicked = x => {
                this.closeEvent.detail.approved = x.approved;
                this.modal.dispatchEvent(this.closeEvent);
            }
        });

        this.overlay.addEventListener("click", function(e) {
            if(e.target == this) {
                _self.closeEvent.detail.approved = false;
                _self.modal.dispatchEvent(_self.closeEvent);
            }
        }, false);

        window.addEventListener("keydown", e => {
            if (e.key == "Escape" && _self.shown) {
                _self.closeEvent.detail.approved = false;
                _self.modal.dispatchEvent(_self.closeEvent);
            }
        }, false);

        this.modal.addEventListener("onshown", () => {
            this.overlay.classList.add("modal-overlay--shown");
            this.modal.classList.add("modal--shown");
            this.shown = true;
            document.body.style.overflow = "hidden";
            setTimeout(() => this.onOpen(), this.modalOpenTime);
        }, false);

        this.modal.addEventListener("onclosed", () => {
            this.onCloseStart(this.closeEvent.detail)
                .then(x => {
                    if (!this.closeEvent.detail.preventClosing) {
                        this.modal.classList.remove("modal--shown");
                        this.shown = false;
                        document.body.style.overflow = "auto";
                        setTimeout(() => {
                            this.overlay.classList.remove("modal-overlay--shown");
                            this.onClose(this.closeEvent.detail);
                        }, this.modalOpenTime);
                    }
                })
                .then(() => this.closeEvent.detail.preventClosing = false);
        }, false);
    }

    /*
     * Metoda ma za zadanie pokazać okno dialogowe
     */
    show = () => this.modal.dispatchEvent(this.showEvent);

    /*
     * Metoda ma za zadanie ustawić zawartość, która będzie się wyświetlała
     * w oknie dialogowym
     * 
     * @test - tekst, który ma się wyświetlić
     */
    setContent(text) {
        this.modal.querySelector(".modal__content").innerHTML = text;
        this.content = text;
    }


    /*
     * Metoda ma za zadanie zablokować możliwość zamykania okna dialogowego
     */
    preventClosing = () => this.closeEvent.detail.preventClosing = true;
}