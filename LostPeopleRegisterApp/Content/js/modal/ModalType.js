import ModalTypeData from "/Content/js/modal/ModalTypeData.js";

/*
 * Klasa jako wyliczenie, które określi, jakiego typu ma być okienko dialogowe.
 */
export default class ModalType {
    static SUCCESS = new ModalTypeData("fa-check-circle", "var(--green)", "Sukces");
    static WARNING = new ModalTypeData("fa-exclamation-triangle", "var(--yellow)", "Ostrzeżenie");
    static ERROR = new ModalTypeData("fa-times-circle", "var(--red)", "Błąd");
}