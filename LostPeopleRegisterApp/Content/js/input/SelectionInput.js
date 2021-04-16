import Input from "/Content/js/input/Input.js";

export default class SelectionInput extends Input {
    constructor(wrapper, data) {
        super(wrapper, data);
        var _self = this;
        
        if (!wrapper.classList.contains("input") && !wrapper.classList.contains("input--selection"))
            throw new Error("Akceptowane są tylko elementy z klasami \"input\" wraz z \"input--selection\".");

        this.input.oninput = function() {
            _self.value = {
                value: parseInt(_self.input.value),
                text: _self.input.options[_self.input.value].text
            };

            _self.onChange(_self.value);
        };
    }
}