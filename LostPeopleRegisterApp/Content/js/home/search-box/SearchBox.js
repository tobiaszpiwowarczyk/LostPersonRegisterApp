import SearchBoxData from "/Content/js/home/search-box/SearchBoxData.js";

/*
 * Klasa jest odpowiedzialna za zarządzanie polem wyszukującym osoby zaginione
 */
export default class SearchBox {
    // Obiekt przechowujący element pola wyszukującego
    #wrapper;

    // Pole wejściowe
    #input;

    // Element wyświetlający wyniki wyszukiwania
    #searchResultWrapper;

    // Przycisk do uruchomienia procesu wyszukiwania
    #searchBoxButton;

    // Przycisk do wyświetlenia zaawansowanych opcji wyszukiwania
    #advancedSettingsButton;


    // Zdarzenie wywołujące się po zmianie wartości wpisanej w pole tekstowe
    #searchChanged;

    // Zdarzenie wywołujące się po uruchomieniu procesu wyszukiwania
    #searchSubmitted;




    /*
     * @selector - selector odwołujący się do elementu pola wyszukującego
     * @data     - dodatkowe dane konfiguracyjne wyszukiwarki
     */
    constructor(selector, data) {
        var _self = this;
        var _data = Object.assign(new SearchBoxData(), data);
        
        this.#wrapper = document.querySelector(selector);
        this.#input = this.#wrapper.querySelector(".search-box__input");
        this.#searchResultWrapper = this.#wrapper.querySelector(".search-box__results");
        this.#searchBoxButton = this.#wrapper.querySelector(".search-box__button");
        this.#advancedSettingsButton = this.#wrapper.querySelector(".search-box__advanced-settings");

        this.#searchChanged = new CustomEvent("searchchanged");
        this.#searchSubmitted = new CustomEvent("searchsubmitted");

        this.requiredCharsCount = _data.requiredCharsCount;
        this.searchResultUrl = _data.searchResultUrl;
        this.value = "";
        this.withContent = false;
        this.searchResults = [];

        this.onSearch = x => {};
        this.onAdvancedSettingsOpen = () => {};

        this.#input.value = "";

        this.#input.addEventListener("input", () => {
            _self.value = _self.#input.value;

            _self.withContent = _self.value.length > 0;

            if (_self.withContent && _self.value.length >= _self.requiredCharsCount) {
                _self.#wrapper.classList.add("search-box--with-content");
                this.#searchBoxButton.href = _self.searchResultUrl + "?q=" + _self.value;
                _self.onSearch(_self.value);
            }
            else {
                _self.#wrapper.classList.remove("search-box--with-content");
                _self.#searchResultWrapper.innerHTML = "";
                _self.searchResults = [];
            }
        }, false);

        this.#input.addEventListener("keypress", e => {
            if (e.key == "Enter" && _self.withContent && _self.value.length >= _self.requiredCharsCount) {
                window.open(_self.#searchBoxButton.href, '_blank');
                _self.#wrapper.dispatchEvent(this.#searchSubmitted);
            }
        }, false);

        this.#wrapper.addEventListener("searchchanged", () => {
            _self.withContent = _self.searchResults.length > 0;
            if (_self.searchResults.length > 0)
                _self.#searchResultWrapper.classList.add("search-box__results--visible");
            else
                _self.#searchResultWrapper.classList.remove("search-box__results--visible");
        }, false);

        this.#wrapper.addEventListener("searchsubmitted", () => {
            this.#input.value = "";
            _self.#wrapper.classList.remove("search-box--with-content");
            _self.#searchResultWrapper.innerHTML = "";
            _self.searchResults = [];
        }, false);

        this.#searchBoxButton.addEventListener("click", () => _self.#wrapper.dispatchEvent(this.#searchSubmitted), false);

        this.#advancedSettingsButton.addEventListener("click", () => _self.onAdvancedSettingsOpen(), false);

        window.addEventListener("click", e => {
            if (e.target != this.#input && e.target != this.#searchBoxButton)
                _self.#searchResultWrapper.classList.remove("search-box__results--visible");
        }, false);
    }





    /*
     * Metoda ma za zadanie umieścić oraz wyświetlić wyniki wyszukiwania
     * pobrane ze źródła zewnętrznego
     */
    setSearchBoxResults(searchBoxResults) {
        this.#searchResultWrapper.innerHTML = "";

        searchBoxResults.forEach(searchResult => {
            this.searchResults.push(searchResult);

            var resElem = searchResult.print();
            resElem.querySelector("span").innerHTML = resElem.querySelector("span").innerText.replace(new RegExp("("+this.value+")", "ig"), "<b>$1</b>");
            resElem.addEventListener("click", () => {
                this.#searchResultWrapper.classList.remove("search-box__results--visible");
                this.#input.value = "";
            }, false);

            this.#searchResultWrapper.appendChild(resElem);
            this.#wrapper.dispatchEvent(this.#searchChanged);
        });
    }
}