import Input from "/Content/js/input/Input.js";

/*
 * Klasa dziedzicząca klasę Input, mająca za zadanie zarządzać
 * polem wejściowym jednokrotnego wyboru
 */
export default class ChoiceInput extends Input {
    /*
     * @wrapper   - element reprezentujący pole wejściowe
     * @inputData - dodatkowe dane konfiguracyjne pola wejściowego
     */
    constructor(wrapper, inputData) {
        super(wrapper, inputData);

        var _self = this;

        if (!wrapper.classList.contains("input") && !wrapper.classList.contains("input--choice"))
            throw new Error("Akceptowane są tylko elementy z klasami \"input\" wraz z \"input--choice\".");

        this.value = this.input.checked;

        this.input.oninput = () => _self.validate().then(() => {
            _self.value = _self.input.checked;
            _self.onChange(_self.value);
        });
    }





    /*
     * Metoda ta usuwa wprowadzoną wartość w pole wejściowe
     */
    clear() {
        this.input.checked = false;
        this.value = this.input.checked;
        this.onChange(this.value);
    }
}