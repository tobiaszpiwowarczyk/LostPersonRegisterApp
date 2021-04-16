import ProfileImageData from "/Content/js/profile-image/ProfileImageData.js";

/*
 * Klasa jest odpowiedzialna za zarządzanie elementem
 * wyświetlającym zdjęcie profilowe osoby zaginionej
 */
export default class ProfileImage {
    // Dane zdjęcia do wyświetlenia
    #image;

    /*
     * @data - dodatkowe konfiguracje obiektu zdjęcia profilowego
     */
    constructor(data) {
        var _data = Object.assign(new ProfileImageData(), data);

        this.#image = this.updateImage(_data.image || "");
        this.width = _data.width;
        this.cornered = _data.cornered;
        this.shadowed = _data.shadowed;
        this.iconFontSize = _data.iconFontSize;
    }



    /*
     * Metoda ma za zadanie utworzyć oraz zwrócić element,
     * który będzie wyświetlał zdjecie osoby zaginionej
     */
    print() {
        var img = document.createElement("div");
        img.classList.add("profile-image");

        if (this.cornered)
            img.classList.add("profile-image--cornered");

        if (this.shadowed)
            img.classList.add("profile-image--shadowed");

        img.style.width = this.width + ((typeof this.width == "number") ? "px" : "");
        img.style.height = this.width + ((typeof this.width == "number") ? "px" : "");

        if (this.#image != "")
            img.style.backgroundImage = `url(data:image/jpg;base64,${this.#image})`;
        else
            img.innerHTML = `<i class="fas fa-image" style="font-size: ${this.iconFontSize};"></i>`;

        return img;
    }



    /*
     * Metoda ma za zadanie zmienić aktualnie wyświetlane dane
     */
    updateImage = (image) => this.#image = image.replace(/^data:image\/[a-z]+\;base64\,/g, "");
}