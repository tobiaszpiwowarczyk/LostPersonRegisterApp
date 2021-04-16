/*
 * Skrypt do zarządzania zachowaniami elementów wyświetlanych na stronie
 * do wyświetlenia szczegółowych danych osoby zaginionej
 */
import ProfileImage from "/Content/js/profile-image/ProfileImage.js";
import Modal from "/Content/js/modal/Modal.js";
import ModalType from "/Content/js/modal/ModalType.js";
import InputRepository from "/Content/js/input/InputRepository.js";

var profileImage              = document.querySelector(".lost-person-details__avatar"),
    markAsFoundButton         = document.querySelector("#mark-as-found-button"),
    modifyLostPersonDatButton = document.querySelector("#modify-lost-person-data-button")
;

profileImage.appendChild(new ProfileImage({
    image: profileImage.dataset.image,
    cornered: true,
    width: "300px"
}).print());


if (markAsFoundButton != null) {
    var markAsFoundModal = new Modal("#mark-as-found-modal");

    markAsFoundButton.addEventListener("click", e => {
        e.preventDefault();
        markAsFoundModal.show();
    }, false);

    markAsFoundModal.onClose = x => {
        if (x.approved) {
            fetch(document.forms[0].action, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json; charset=UTF-8"
                }
            })
                .then(res => res.json())
                .then(res => {
                    if (res.updated)
                        window.location.reload();
                });
        }
    }
}


if (modifyLostPersonDatButton != null) {
    var modifyLostPersonDataModal           = new Modal("#modify-lost-person-data-modal"),
        modifyLostPersonDataConfirmModal    = new Modal("#modify-lost-person-data-confirm-modal", {type: ModalType.SUCCESS}),
        modifyLostPersonDataForm            = new InputRepository(document.querySelectorAll(".modify-lost-person-data-form .input"))
    ;

    var initialData = modifyLostPersonDataForm.parseInputsToObject();

    modifyLostPersonDatButton.addEventListener("click", () => modifyLostPersonDataModal.show(), false);
    modifyLostPersonDataModal.onOpen = () => modifyLostPersonDataForm.getInputByName("firstName").focus();

    modifyLostPersonDataModal.onClose = x => {

        if (x.approved) {

            var modifyFormValues = modifyLostPersonDataForm.parseInputsToObject();
            modifyFormValues.address = modifyFormValues.village != null ? {
                village: modifyFormValues.village,
                apartmentNumber: modifyFormValues.apartmentNumber
            } : {
                city: modifyFormValues.city,
                street: modifyFormValues.street,
                flatNumber: modifyFormValues.flatNumber,
                apartmentNumber: modifyFormValues.cityApartmentNumber
            };

            modifyFormValues.address.id = modifyFormValues.lostPersonAddressId;

            if (modifyFormValues.village != null) delete modifyFormValues.village;
            if (modifyFormValues.apartmentNumber != null) delete modifyFormValues.apartmentNumber;
            if (modifyFormValues.city != null) delete modifyFormValues.city;
            if (modifyFormValues.street != null) delete modifyFormValues.street;
            if (modifyFormValues.flatNumber != null) delete modifyFormValues.flatNumber;
            if (modifyFormValues.cityApartmentNumber != null) delete modifyFormValues.cityApartmentNumber;
            if (modifyFormValues.lostPersonAddressId != null) delete modifyFormValues.lostPersonAddressId;

            var formData = new FormData();
            formData.append("document", JSON.stringify(modifyFormValues));

            console.log(modifyFormValues);

            fetch("/lostPerson/updateLostPerson", {
                method: "POST",
                body: formData
            })
                .then(res => res.json())
                .then(res => {
                    if (res.updated) {
                        modifyLostPersonDataConfirmModal.setContent("Dane osoby zaginionej zostały zaktualizowane pomyślnie");
                        modifyLostPersonDataConfirmModal.show();
                    }
                });
        }

        modifyLostPersonDataForm.forEach(input => {
            if (input.getValue() != initialData[input.name]) {
                input.setValue(initialData[input.name]);
                input.setInvalid(false);
            }
        });
    }


    modifyLostPersonDataConfirmModal.onClose = x => window.location.reload();
}