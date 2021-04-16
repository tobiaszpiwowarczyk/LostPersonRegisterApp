/*
 * Skrypt do zarządzania zachowaniami elementów wyświetlanych na stronie
 * do wyświetlenia szczegółowych danych osoby zaginionej
 */
import ProfileImage from "/Content/js/profile-image/ProfileImage.js";
import Modal from "/Content/js/modal/Modal.js";

var profileImage        = document.querySelector(".lost-person-details__avatar"),
    markAsFoundButton   = document.querySelector("#mark-as-found-button")
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