import Input from "/Content/js/input/Input.js";
import ProfileImage from "/Content/js/profile-image/ProfileImage.js";

/*
 * Klasa dziedzicząca klasę Input mająca za zadanie zarządzać
 * polem wejściowym do przesyłania plików
 */
export default class FileInput extends Input {
    // Wartość tekstu wyświetlającego się jako etykieta
    #labelText;

    // Element przechowujący podgląd przesłanego zdjęcia
    #imagePreview;

    // Obiekt, który będzie wyświetlać zdjęcie o odpowiednim wyglądzie
    #profileImage;





    /*
     * @wrapper - element reprezentujący pole wejściowe pliku
     * @inputData - dodatkowe dane konfiguracyjne pola wejściowego
     */
    constructor(wrapper, inputData) {
        super(wrapper, inputData);

        var _self = this;
        
        if (!wrapper.classList.contains("input") && !wrapper.classList.contains("input--file"))
            throw new Error("Akceptowane są tylko elementy z klasami \"input\" wraz z \"input--file\".");

        this.#labelText = this.getWrapper().querySelector(".input__label").innerHTML.trim();
        this.#imagePreview = this.getWrapper().querySelector(".input__image-preview");
        this.#profileImage = new ProfileImage({
            shadowed: false,
            iconFontSize: "140px"
        });

        this.#imagePreview.appendChild(this.#profileImage.print());

        this.input.oninput = () => _self.validate().then(() => {
            _self.value = [..._self.input.files];
            _self.onChange(_self.value);

            if (_self.value && _self.value[0]) {
                var reader = new FileReader();

                reader.onload = function(e) {
                    _self.#profileImage.updateImage(e.target.result);
                    _self.#imagePreview.innerHTML = "";
                    _self.#imagePreview.appendChild(_self.#profileImage.print());

                    _self.#imagePreview.classList.add("input__image-preview--displayed");
                    _self.getWrapper().querySelector(".input__label").innerText = _self.value[0].name;
                };
                
                reader.readAsDataURL(_self.value[0]);
            }
        });
    }



    /*
     * Metoda ta usuwa wprowadzoną wartość w pole wejściowe
     */
    clear = () => {
        this.#profileImage.updateImage("");
        this.#imagePreview.innerHTML = "";
        this.#imagePreview.appendChild(this.#profileImage.print());
        this.getWrapper().querySelector(".input__label").innerText = this.#labelText;
        this.input.value = "";
        this.value = [];
        this.onChange(this.value);
    }
}