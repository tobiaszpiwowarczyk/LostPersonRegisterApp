import InputValidator from "/Content/js/input/InputValidator.js";

/*
 * Klasa, która ma za zadanie zarządzać odpowiednim polem, w którym będą
 * wprowadzane dane
 */
export default class Input {

    // @wrapper - element, który zawiera pole wejściowe
    constructor(wrapper) {
        var _self = this;

        if (!wrapper.classList.contains("input")) {
            throw new Error("Akceptowane są tylko elementy z klasą \"input\".");
        }
        this.wrapper = wrapper;
        this.input = this.wrapper.querySelector("input,textarea");
        
        this.name = this.input.name;
        this.centered = this.wrapper.classList.contains("input--centered");
        this.invalid = this.wrapper.classList.contains("input--invalid");
        this.validatorElement = null;
        this.validators = [];

        this.onChange = (x) => {};

        this.input.addEventListener("input", () => _self.validate().then(() => _self.onChange(_self.input.value)), false);
    }

    /*
     * Metoda ta ma za zadanie ustawić stan wprowadzanego pola wejściowego w zależności od
     * wprowadzanego parametru
     * 
     * @invalid - parametr określający, czy kontrolka ma wyświetlać się jako niepoprawnie
     *            wprowadzona
     */
    setInvalid(invalid) {
        this.invalid = invalid;
        if(invalid)
            this.wrapper.classList.add("input--invalid");
        else {
            this.wrapper.classList.remove("input--invalid");
            this.validatorElement.innerHTML = "";
        }
    }


    /*
     * Metoda ta ma za zadanie dodać nową funkcję walidacyjną, która ustali
     * poprawność wprowadzanych danych do kontrolki
     * 
     * @message     - wiadomość, która będzie się wyświetlała, gdy kontrolka będzie miałą wprowadzoną
     *                niepoprawną wartość.
     * @validatorFn - funkcja, która będzie sprawdzałą poprawność wprowadzanej wartości
     */
    addValidator(message, validatorFn) {
        this.validators.push(new InputValidator(message, validatorFn));

        if (this.validatorElement == null) {
            this.validatorElement = document.createElement("div");
            this.validatorElement.classList.add("input__validator");
            this.wrapper.appendChild(this.validatorElement);
        }
    }


    /*
     * Metoda ma za zadanie sprawdzić poprawność wprowadzonej wartości w poleu wejściowym
     */
    validate() {
        return Promise.resolve((async () => {
            var hasError = false;
            for (var validator of this.validators) {

                const isInvalid = await validator.validate(this.input.value).then(res => {
                    if (!res) {
                        this.setInvalid(true);
                        this.validatorElement.innerHTML = validator.message;
                        return true;
                    }
                    return false;
                });

                if (isInvalid) {
                    hasError = true;
                    break;
                }
            }

            if (!hasError) this.setInvalid(false);
            return this;
        })());
    }


    /*
     * Metoda ma za zadanie uaktywnić aktualną kontrolkę
     */
    focus = () => this.input.focus();

    
    /*
     * Metoda usuwa wartość, która została wprowadzona w dane pole wejściowe
     */
    clear = () => this.input.value = "";


    /*
     * Metoda pobiera i zwraca wartość pola wejściowego
     */
    getValue = () => this.input.value;
}