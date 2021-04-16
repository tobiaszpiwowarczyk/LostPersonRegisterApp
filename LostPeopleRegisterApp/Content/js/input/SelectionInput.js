import Input from "/Content/js/input/Input.js";

export default class SelectionInput extends Input {
    constructor(wrapper, data) {
        super(wrapper, data);
        var _self = this;
        
        if (!wrapper.classList.contains("input") && !wrapper.classList.contains("input--selection"))
            throw new Error("Akceptowane są tylko elementy z klasami \"input\" wraz z \"input--selection\".");

        this.input.oninput = () => _self.setValue(_self.input.value, true);
    }


    /*
     * Metoda ustawia wartość pola wejściowego na aktualną
     */
    setValue(value, typed = false) {
        this.value = {
            value: parseInt(value),
            text: this.input.options[value].text
        };

        if (!typed)
            this.input.value = this.value.value;

        this.onChange(this.value);
    }
}