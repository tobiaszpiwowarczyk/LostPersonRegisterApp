import ProfileImage from "/Content/js/profile-image/ProfileImage.js";

/*
 * Klasa jest odpowiedzialna za zarządzanie elementem wyświetlającym
 * wynik wyszukiwania osoby zaginionych
 */
export default class SearchBoxResult {

    /*
     * @id - identyfikator osoby zaginionych
     * @value - wartość w postaci imienia i nazwiska osoby zaginionej
     * @image - zdjęcie profilowe osoby zaginionej
     */
    constructor(id, value, image) {
        this.id = id;
        this.value = value;
        this.image = image;
    }





    /*
     * Metoda ma za zadanie utworzyć oraz zwrócić nowy element
     * do wyświetlenia wyniku wyszukiwania osob zaginionej
     * jako odnośnik
     */
    print() {
        var a = document.createElement("a");
        a.target = "_blank";
        a.href = "/lostPerson/details?lostPersonId=" + this.id;
        a.classList.add("search-box__result");


        var span = document.createElement("span");
        span.classList.add("search-box__result__text");
        span.innerText = this.value;

        var profileImage = new ProfileImage({
            image: this.image,
            width: "50px",
            iconFontSize: "21px"
        });


        console.log(profileImage);
        a.appendChild(profileImage.print());
        a.appendChild(span);

        return a;
    }
}