import AccountValidationResult from "/Content/js/account/AccountValidationResult.js";

/*
 * Klasa zawierająca zestaw metód, które będą odpowiedzialne za przetwarzanie pewnych
 * danych wejściowych na obiekt typu AccountValidationResult.
 */
export default class AccountValidationResultParser {
    
    /*
     * Metoda ta służy do przetworzenia wprowadzonego obiektu jako obiekt
     * typu AccountValidationResult.
     * 
     * @obj - wejściowy obiekt
     */
    static parse = (obj) => new AccountValidationResult(obj.fieldName, obj.result);
}