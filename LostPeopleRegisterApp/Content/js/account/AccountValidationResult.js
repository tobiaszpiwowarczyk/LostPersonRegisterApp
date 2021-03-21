/*
 * Klasa, która odpowiedzialna jest za przechowywanie informacji o wyniku walidacji
 * pola w formularzu.
 * @fieldName - nazwa pola
 * @result - wynik walidacji
 */
export default class AccountValidationResult {
    constructor(fieldName, result) {
        this.fieldName = fieldName;
        this.result = result;
    }
}