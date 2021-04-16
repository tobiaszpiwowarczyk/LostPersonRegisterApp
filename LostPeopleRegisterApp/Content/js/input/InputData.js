import CSSUtils from "/Content/js/util/CSSUtils.js";

/*
 * Klasa mająca za zadanie przechowywać domyślne konfiguracje
 * pola wejściowego
 */
export default class InputData {
    constructor() {
        // Długość pola wejściowego
        this.width = CSSUtils.getCSSVariableValueAsNumber("--inputWidth");
    }
}