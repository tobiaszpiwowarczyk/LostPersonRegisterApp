/*
 * Główny plik skryptowy, który będzie wykorzystany do wykonywania operacji na stronie
 * do zarządzania danymi konta użytkownika
 */

import InputRepository from "/Content/js/input/InputRepository.js";
import Modal from "/Content/js/modal/Modal.js";
import ModalType from "/Content/js/modal/ModalType.js";
import validate from "/Content/js/util/validate.js";
import LoadingOverlay from "/Content/js/util/LoadingOverlay.js";
import Alert from "/Content/js/util/Alert.js";
import AccountAdditionalDetail from "/Content/js/account/AccountAdditionalDetail.js";
import ProfileImage from "/Content/js/profile-image/ProfileImage.js";

var changePasswordModal                 = new Modal("#change-password-modal"),
    changePasswordButton                = document.querySelector(".change-password-button"),
    updateAccountDetailsButton          = document.querySelector(".update-account-details-button"),
    accountSettingsInputRepository      = new InputRepository(document.querySelectorAll(".update-user-data-panel .input")),
    changePasswordInputRepository       = new InputRepository(document.querySelectorAll("#change-password-modal .input")),
    fullPageLoadingOverlay              = new LoadingOverlay("#full-page-loading-overlay"),
    passwordChangeAlert                 = new Alert(".alert"),
    updateAccountOverlay                = new LoadingOverlay("#update-account-overlay"),
    updateAccountDetailsModal           = new Modal("#update-account-details-modal", {type: ModalType.SUCCESS}),
    createNewLostPersonModal            = new Modal("#create-new-lost-person-modal", {width: 1000}),
    createNewLostPersonButon            = document.querySelector(".create-new-lost-person-button"),
    createNewLostPersonInputRepository  = new InputRepository(document.querySelectorAll(".account-create-lost-person-form .input")),
    createAdditionalDetailButton        = document.querySelector(".create-additionl-detail-button"),
    lostPersonAdditionaletails          = [],
    additionalDetailsList               = document.querySelector(".account-additional-details-list"),
    profileImages                       = [...document.querySelectorAll(".lost-person-thumbnail")]
;

var initialAccountSettingsFormValues = accountSettingsInputRepository.parseInputsToObject();

changePasswordInputRepository.forEach(input => input.addValidator("To pole jest wymagane", x => x != null && x != ""));
changePasswordInputRepository.getInputByName("currentPassword").addValidator("Podane hasło jest nieprawidłowe", x => validate("account", "password", x));
changePasswordInputRepository.getInputByName("newPassword")
    .addValidator("Nowe hasło nie może byćtakie same jak aktualne hasło", x => x != changePasswordInputRepository.getInputByName("currentPassword").getValue());
changePasswordInputRepository.getInputByName("confirmedPassword")
    .addValidator("Hasło musi być takie same jak nowe hasło", x => x == changePasswordInputRepository.getInputByName("newPassword").getValue());

changePasswordButton.addEventListener("click", () => changePasswordModal.show(), false);
changePasswordModal.onOpen = () => changePasswordInputRepository.getInputByName("currentPassword").focus();
changePasswordModal.onCloseStart = x => Promise.resolve((async () => {
    if (x.approved) {
        await changePasswordInputRepository.validateAll().then(x => {
            if(!x) changePasswordModal.preventClosing();
        });
    }
})());

changePasswordModal.onClose = x => {
    if (x.approved) {
        fullPageLoadingOverlay.show();
        fetch("/account/updatePassword", {
            method: "POST",
            headers: {
                "Content-Type": "application/json; charset=UTF-8"
            },
            body: JSON.stringify(changePasswordInputRepository.parseInputsToObject())
        })
            .then(res => res.json())
            .then(res => {
                fullPageLoadingOverlay.hide();
                if (res.updated) {
                    passwordChangeAlert.setContent("Hasło zostało zmienione pomyślnie");
                    passwordChangeAlert.show();
                }
            });
    }

    changePasswordInputRepository.forEach(x => {
        x.clear();
        x.setInvalid(false);
    });
}


accountSettingsInputRepository.forEach(input => {
    input.addValidator("To pole jest wymagane", (x) => x != null && x != "");
    input.onChange = function(x) {
        updateAccountDetailsButton.disabled = x == initialAccountSettingsFormValues[this.name]
                                                || accountSettingsInputRepository.inputs.some(x => x.invalid == true);
    }
});

accountSettingsInputRepository.getInputByName("username").addValidator("Podana nazwa użytkownika już istnieje", x => validate("account", "username", x));
accountSettingsInputRepository.getInputByName("emailAddress").addValidator("Podany adres e-mail jest nieprawidłowy", x => /^[a-zA-Z0-9\-\_\.]+\@([a-z]+\.)+[a-z]{2,3}$/g.test(x));
accountSettingsInputRepository.getInputByName("emailAddress").addValidator("Podany adres e-mail już istnieje", x => validate("account", "emailAddress", x));


updateAccountDetailsButton.addEventListener("click", function(e) {
    updateAccountOverlay.show();
    fetch("/account/updateAccountDetails", {
        method: "POST",
        headers: {
            "Content-Type": "application/json; charset=UTF-8"
        },
        body: JSON.stringify(accountSettingsInputRepository.parseInputsToObject())
    })
        .then(res => res.json())
        .then(res => {
            updateAccountOverlay.hide();
            if (res.updated) {
                updateAccountDetailsModal.setContent("Dane użytkownika zostały zaktualizowane pomyślnie");
                updateAccountDetailsModal.show();
            }
        })
}, false);


updateAccountDetailsModal.onClose = x => window.location.reload();




createNewLostPersonButon.addEventListener("click", () => createNewLostPersonModal.show(), false);

createNewLostPersonInputRepository.inputs.filter(input => !["inVillage", "thumbnail", "additionalDetailAttribute", "additionalDetailValue"].includes(input.name))
    .forEach(input => input.addValidator("To pole jest wymagane", x => x != null && x != ""));

createNewLostPersonInputRepository.getInputByName("lostPersonDate")
    .addValidator(
        "Wprowadzona data nie może być późniejsza niż data dzisiejsza", 
        x => x <= createNewLostPersonInputRepository.getInputByName("lostPersonDate").input.max
    );

createNewLostPersonInputRepository.getInputByName("additionalDetailAttribute")
    .addValidator("Nazwa znaku szczególnego już istnieje", x => !lostPersonAdditionaletails.map(x => x.parseToObject().attribute).includes(x));


["village", "villageApartmentNumber"].forEach(y => {
    createNewLostPersonInputRepository.getInputByName(y).getWrapper().style.display = createNewLostPersonInputRepository.getInputByName("inVillage").getValue() ? "flex" : "none";
});

createNewLostPersonInputRepository.getInputByName("inVillage").onChange = x => {
    ["city", "street", "flatNumber", "apartmentNumber"].forEach(y => {
        createNewLostPersonInputRepository.getInputByName(y).getWrapper().style.display = x ? "none" : "flex";
    });
    ["village", "villageApartmentNumber"].forEach(y => {
        createNewLostPersonInputRepository.getInputByName(y).getWrapper().style.display = !x ? "none" : "flex";
    });
}


createAdditionalDetailButton.addEventListener("click", () => {
    var attribute = createNewLostPersonInputRepository.getInputByName("additionalDetailAttribute");
    var value = createNewLostPersonInputRepository.getInputByName("additionalDetailValue");

    if (!attribute.isEmpty() && !value.isEmpty() && !attribute.invalid && !value.invalid) {
        var newAdditionalDetail = new AccountAdditionalDetail(
            attribute.getValue(),
            value.getValue()
        );

        newAdditionalDetail.onDelete = function(x) {
            lostPersonAdditionaletails = lostPersonAdditionaletails.filter(y => y != x);
        }

        lostPersonAdditionaletails.push(newAdditionalDetail);
        additionalDetailsList.appendChild(newAdditionalDetail.print());

        attribute.clear();
        value.clear();
    }
}, false);


createNewLostPersonModal.onCloseStart = x => Promise.resolve((async () => {
    if (x.approved) {
        await createNewLostPersonInputRepository.validateAll().then(x => {
            if(!x) createNewLostPersonModal.preventClosing();
        });
    }
})());


createNewLostPersonModal.onOpen = () => createNewLostPersonInputRepository.getInputByName("lostPersonFirstName").focus();
createNewLostPersonModal.onClose = x => {
    if (x.approved) {
        var formData = createNewLostPersonInputRepository.parseInputsToObject();
        var formDataToSend = new FormData();

        formDataToSend.append("document", JSON.stringify({
                firstName: formData.lostPersonFirstName,
                lastName: formData.lostPersonLastName,
                lostPersonDate: formData.lostPersonDate,
                lastPlaceName: formData.lastPlaceName,
                height: parseInt(formData.height),
                isVillage: formData.inVillage,
                additionalDetails: lostPersonAdditionaletails.map(x => x.parseToObject()),
                images: formData.thumbnail?.map(x => new Object({imageName: x.name})),
                address: formData.inVillage ? 
                {
                    village: formData.village,
                    apartmentNumber: parseInt(formData.villageApartmentNumber)
                } : 
                {
                    city: formData.city,
                    street: formData.street,
                    flatNumber: parseInt(formData.flatNumber),
                    apartmentNumber: parseInt(formData.apartmentNumber)
                }
            }));

        if (formData.thumbnail != null)
            formDataToSend.append("file", formData.thumbnail[0]);

        fetch("/lostPerson/createLostPerson", {
            method: "POST",
            body: formDataToSend
        })
            .then(res => res.json())
            .then(() => {
                updateAccountDetailsModal.setContent("Zaginiona osoba została dodana pomyślnie");
                updateAccountDetailsModal.show();
            })
            .catch(err => console.log(err));
    }
    createNewLostPersonInputRepository.forEach(input => {
        input.clear();
        input.setInvalid(false);
    });
}


profileImages.forEach(img => {
    img.appendChild(new ProfileImage({
        image: img.dataset.image,
        width: "100px",
        shadowed: true,
        iconFontSize: "32px"
    }).print());
})