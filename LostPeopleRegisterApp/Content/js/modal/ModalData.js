import ModalType from "/Content/js/modal/ModalType.js";
import CSSUtils from "/Content/js/util/CSSUtils.js";

/*
 * Klasa jest odpowiedzialna za przechowywanie domyślnych
 * konfiguracji okna doalogowego
 */
export default class ModalData {
    constructor() {
        // Typ okna dialogowego
        this.type = ModalType.INFO;

        // Długość okna dialogowego
        this.width = CSSUtils.getCSSVariableValueAsNumber("--modalWidth");

        // Czas otwarcia okna dialogowego
        this.openTime = CSSUtils.getCSSVariableValueAsNumber("--modalOpenTime");
    }
}