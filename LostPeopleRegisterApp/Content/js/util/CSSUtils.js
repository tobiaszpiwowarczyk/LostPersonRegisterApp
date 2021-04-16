/*
 * Klasa zawierająca zestaw metód do zarządzania aspektem związanym
 * z arkuszem styli
 */
export default class CSSUtils {

    /*
     * Metoda ma za zadanie zwrócić wartość zmiennej CSS jako liczbę
     */
    static getCSSVariableValueAsNumber = (variableName) => parseFloat(getComputedStyle(document.body).getPropertyValue(variableName).match(/[0-9]+(\.[0-9]+)?/g)[0]);
}