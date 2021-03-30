/*
 * Skrypt, który będzie wykorzystany w stronie do rejestrowania użytkownika.
 */

import InputRepository from "/Content/js/input/InputRepository.js";
import Modal from "/Content/js/modal/Modal.js";
import ModalType from "/Content/js/modal/ModalType.js";
import LoadingOverlay from "/Content/js/util/LoadingOverlay.js";
import validate from "/Content/js/util/validate.js";


var registerButton      = document.querySelector(".register-button"),
    inputRepository     = new InputRepository(document.querySelectorAll(".input")),
    modal               = new Modal(".modal-overlay", ModalType.SUCCESS),
    today               = new Date(),
    month               = (today.getMonth() > 10 ? "" : "0") + today.getMonth(),
    day                 = (today.getDate() > 10 ? "" : "0") + today.getDate(),
    overlay             = new LoadingOverlay(".loading-overlay")
;



inputRepository.forEach(input => input.addValidator("To pole jest wymagane", x => x != null && x != ""));

inputRepository.getInputByName("username").addValidator("Podana nazwa użytkownika już istnieje", x => validate("register", "username", x));
inputRepository.getInputByName("emailAddress").addValidator("Adres e-mail jest nieprawidłowy", x => /^[a-zA-Z0-9\-\_\.]+\@([a-z]+\.)+[a-z]{2,3}$/g.test(x));
inputRepository.getInputByName("emailAddress").addValidator("Podany adres e-mail już istnieje", x => validate("register", "emailAddress", x));



inputRepository.getInputByName("birthDate").input.max = `${today.getFullYear()}-${month}-${day}`;





registerButton.addEventListener("click", e => {
    e.preventDefault();
    (async () => {
        if (await inputRepository.validateAll()) {
            overlay.show();
            fetch("/register/DoRegister", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json; charset=utf-8"
                },
                body: JSON.stringify(inputRepository.parseInputsToObject())
            })
                .then(res => res.json())
                .then(res => {
                    overlay.hide();
                    if (res.registered) {
                        modal.setContent("Konto zostało zarejestrowane pomyślnie. Możesz teraz zalogować się do naszego systemu");
                        modal.show();
                    }
                });
        }
    })();
}, false);



modal.onClose = (x) => window.location.pathname = "/login";