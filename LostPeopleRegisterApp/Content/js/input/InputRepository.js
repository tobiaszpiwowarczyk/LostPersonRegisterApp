import FileInput from "/Content/js/input/FileInput.js";
import ChoiceInput from "/Content/js/input/ChoiceInput.js";
import Input from "/Content/js/input/Input.js";
import SelectionInput from "/Content/js/input/SelectionInput.js";

/*
 * Klasa ma za zadanie zarządzać listą pól wejściowych
 */
export default class InputRepository {
    /*
     * @elementList - element, który zawiera listę pól wejściowych
     */
    constructor(elementList) {
        this.inputs = [...elementList].map(input => {
            if (input.classList.contains("input--file"))
                return new FileInput(input);
            else if (input.classList.contains("input--choice"))
                return new ChoiceInput(input);
            else if (input.classList.contains("input--selection"))
                return new SelectionInput(input);
            else
                return new Input(input);
        });
    }


    

    /*
     * Metoda ta ma za zadanie zwrócić pole wejściowe według jej nazwy
     *
     * @name - nazwa pola wejściowego
     */
    getInputByName = (name) => this.inputs.find(x => x.input.name == name);


    /*
     * Metoda ma za zadanie wykonać iterację poprzez wszytkie elementy tablicy, która przechowuje
     * zbiów obiektów będących polami weściowymi
     * 
     * @fn - funkcja, która ma się wywoływać podczas iteracji
     */
    forEach = (fn) => this.inputs.forEach(fn);


    /*
     * Metoda ma za zadanie zwrócić dane odnośnie pól tekstowych jako pojedyńczy obiekt.
     * Taki obiekt jest zbudowany z atrybutów, gdzie ich nazwy odpowiadają nazwom pól wejściowych
     * a wartości danych atrybutów - wartościom danych pól wejściowych
     */
    parseInputsToObject = () => Object.fromEntries(this.inputs.filter(x => x.name != "" && x.getWrapper().style.getPropertyValue("display") != "none").map(x => [x.name, x.getValue()]));


    /*
     * Metoda ma za zadanie zweryfikować, czy wszystkie wprowadzone pola wejściowe 
     * posiadają poprawnie wprowadzone wartości
     */
    async validateAll() {
        return await Promise.resolve((async () => {
            var res = true;

            for(var input of this.inputs)
                if (input.name != "" && input.getWrapper().style.getPropertyValue("display") != "none")
                    if (!await input.validate().then(x => !x.invalid)) 
                        res = false;

            return res;
        })());
    }
}