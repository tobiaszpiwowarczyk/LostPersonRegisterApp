/*
 * Skrypt, który posłuży za zarządzanie elementami widocznymi na stronie głównej aplikacji
 */

import SearchBox from "/Content/js/home/search-box/SearchBox.js";
import SearchBoxResult from "/Content/js/home/search-box/SearchBoxResult.js";
import Modal from "/Content/js/modal/Modal.js";
import InputRepository from "/Content/js/input/InputRepository.js";
import ProfileImage from "/Content/js/profile-image/ProfileImage.js";

var searchBox                                       = new SearchBox(".search-box"),
    searchBoxAdvancedSettingsModal                  = new Modal("#search-box-advanced-settings-modal"),
    searchBoxAdvancdDetailsFormInputRepository      = new InputRepository(document.querySelectorAll(".search-box-advanecd-details__form .input")),
    profileImages                                   = document.querySelectorAll(".last-registered-person-card__image__display")
;

profileImages.forEach(x => {
    x.appendChild(new ProfileImage({
        image: x.dataset.image,
        shadowed: false
    }).print());
});

searchBox.onSearch = function(x) {
    fetch("/lostPerson/findByBasicCriteria?q=" + x, {
        headers: {
            "Content-Type": "application/json; charset=UTF-8"
        }
    })
        .then(res => res.json())
        .then(res => {
            searchBox.setSearchBoxResults(res.map(y => new SearchBoxResult(y.id, `${y.firstName} ${y.lastName}`, y.image)));
        });
}

searchBox.onAdvancedSettingsOpen = () => searchBoxAdvancedSettingsModal.show();
searchBoxAdvancedSettingsModal.onOpen = () => searchBoxAdvancdDetailsFormInputRepository.getInputByName("minHeight").focus();

searchBoxAdvancdDetailsFormInputRepository.getInputByName("minHeight")
    .addValidator(
        "Wartość nie może być większa niż maksymalny wzrost",
        x => searchBoxAdvancdDetailsFormInputRepository.getInputByName("maxHeight").isEmpty() || searchBoxAdvancdDetailsFormInputRepository.getInputByName("minHeight").isEmpty() || parseInt(x) <= parseInt(searchBoxAdvancdDetailsFormInputRepository.getInputByName("maxHeight").getValue())
    );

searchBoxAdvancdDetailsFormInputRepository.getInputByName("maxHeight")
    .addValidator(
        "Wartość nie może być mniejsza niż minimalny wzrost",
        x => searchBoxAdvancdDetailsFormInputRepository.getInputByName("maxHeight").isEmpty() || searchBoxAdvancdDetailsFormInputRepository.getInputByName("minHeight").isEmpty() || parseInt(x) >= parseInt(searchBoxAdvancdDetailsFormInputRepository.getInputByName("minHeight").getValue())
    );


searchBoxAdvancdDetailsFormInputRepository.getInputByName("minHeight").onChange = x => {
    searchBoxAdvancdDetailsFormInputRepository.getInputByName("maxHeight").input.min = x != "" ? x : 1;
}

searchBoxAdvancdDetailsFormInputRepository.getInputByName("maxHeight").onChange = x => {
    if (x != "")
        searchBoxAdvancdDetailsFormInputRepository.getInputByName("minHeight").input.max = x;
    else
        searchBoxAdvancdDetailsFormInputRepository.getInputByName("minHeight").input.removeAttribute("max");
}

searchBoxAdvancdDetailsFormInputRepository.getInputByName("minLostPersonDate")
    .addValidator(
        "Data nie może być późniejsza niż data końcowa",
        x => searchBoxAdvancdDetailsFormInputRepository.getInputByName("maxLostPersonDate").isEmpty() || x <= searchBoxAdvancdDetailsFormInputRepository.getInputByName("maxLostPersonDate").getValue()
    );

searchBoxAdvancdDetailsFormInputRepository.getInputByName("maxLostPersonDate")
    .addValidator(
        "Data nie może być wcześniejsza niż data początkowa",
        x => searchBoxAdvancdDetailsFormInputRepository.getInputByName("minLostPersonDate").isEmpty() || x >= searchBoxAdvancdDetailsFormInputRepository.getInputByName("minLostPersonDate").getValue()
    );

searchBoxAdvancdDetailsFormInputRepository.getInputByName("minLostPersonDate").onChange = x => {
    if (x != "")
        searchBoxAdvancdDetailsFormInputRepository.getInputByName("maxLostPersonDate").input.min = x;
    else
        searchBoxAdvancdDetailsFormInputRepository.getInputByName("maxLostPersonDate").input.removeAttribute("min");
}

searchBoxAdvancdDetailsFormInputRepository.getInputByName("maxLostPersonDate").onChange = x => {
    var today = new Date();
    searchBoxAdvancdDetailsFormInputRepository.getInputByName("minLostPersonDate").input.max = x != "" ? x : `${today.getFullYear()}-${today.getMonth() + 1}-${today.getDate()}`;
}

searchBoxAdvancedSettingsModal.onCloseStart = x => Promise.resolve((async () => {
    if (x.approved) {
        await searchBoxAdvancdDetailsFormInputRepository.validateAll().then(x => {
            if(!x || searchBoxAdvancdDetailsFormInputRepository.inputs.filter(x => !x.isEmpty()).length == 0) 
                searchBoxAdvancedSettingsModal.preventClosing();
        });
    }
})());

searchBoxAdvancedSettingsModal.onClose = x => {
    if (x.approved) {

        var searchBoxFormData = searchBoxAdvancdDetailsFormInputRepository.parseInputsToObject();

        if (searchBoxFormData.status) {
            searchBoxFormData.statusId = searchBoxFormData.status.value;
            delete searchBoxFormData.status;
        }

        fetch("/lostPerson/provideAdvancedCriteria", {
            method: "POST",
            headers: {
                "Content-Type": "application/json; charset=UTF-8"
            },
            body: JSON.stringify(searchBoxFormData)
        })
            .then(res => res.json())
            .then(res => {
                if (res.created) {
                    window.open(window.location.origin + "/lostPerson?criteria=true", "_blank");
                }
            });
    }

    searchBoxAdvancdDetailsFormInputRepository.forEach(input => {
        input.clear();
        input.setInvalid(false);
    })
}