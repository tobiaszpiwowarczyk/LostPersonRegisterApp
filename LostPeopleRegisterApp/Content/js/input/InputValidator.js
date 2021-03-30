/*
 * Klasa zawiera zestaw pól i metód służących do sprawdzenia poprawności
 * wprowadzanej wartości
 */
export default class InputValidator {

    /*
     * @message     - wiadomość, która będzie się wyświetlać, gdy walidacja zakończy się niepowodzeniem
     * @validatorFn - funkcja, która będzie sprawdzać poprawność wprowadzanej wartości
     */
    constructor(message, validatorFn) {
        this.message = message;
        this.validatorFn = validatorFn;
    }

    /*
     * Metoda ma za zadanie uruchomić funkcję, która sprawdza poprawność wprowadzonego parametru.
     *
     * @input - wprowadzona wartość do sprawdzenia
     */
    validate = (input) => this.validatorFn instanceof Promise ? this.validatorFn(input) : Promise.resolve(this.validatorFn(input));
}