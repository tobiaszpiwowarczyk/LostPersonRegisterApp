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

var changePasswordModal             = new Modal("#change-password-modal"),
    changePasswordButton            = document.querySelector(".change-password-button"),
    updateAccountDetailsButton      = document.querySelector(".update-account-details-button"),
    accountSettingsInputRepository  = new InputRepository(document.querySelectorAll(".update-user-data-panel .input")),
    changePasswordInputRepository   = new InputRepository(document.querySelectorAll("#change-password-modal .input")),
    fullPageLoadingOverlay          = new LoadingOverlay("#full-page-loading-overlay"),
    accountAlert                    = new Alert(".alert"),
    updateAccountOverlay            = new LoadingOverlay("#update-account-overlay"),
    updatePasswordModal             = new Modal("#update-password-modal", ModalType.SUCCESS)
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
                    accountAlert.setContent("Hasło zostało zmienione pomyślnie");
                    accountAlert.show();
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
                updatePasswordModal.setContent("Dane użytkownika zostały zaktualizowane pomyślnie");
                updatePasswordModal.show();
            }
        })
}, false);


updatePasswordModal.onClose = x => window.location.reload();