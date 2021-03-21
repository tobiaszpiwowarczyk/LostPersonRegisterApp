import Input from "/Content/js/input/Input.js";

/*
 * Klasa ma za zadanie zarządzać listą pól wejściowych
 */
export default class InputRepository {
    /*
     * @elementList - element, który zawiera listę pól wejściowych
     */
    constructor(elementList) {
        this.inputs = [...elementList].map(input => new Input(input));
    }

    /*
     * Metoda ta ma za zadanie zwrócić pole wejściowe według jej nazwy
     *
     * @name - nazwa pola wejściowego
     */
    getInputByName(name) {
        return this.inputs.find(x => x.input.name == name);
    }
}