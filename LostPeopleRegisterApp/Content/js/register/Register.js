/*
 * Skrypt, który będzie wykorzystany w stronie do rejestrowania użytkownika.
 */

import InputRepository from "/Content/js/input/InputRepository.js";
import AccountValidationResultParser from "/Content/js/account/AccountValidationResultParser.js";
import Modal from "/Content/js/modal/Modal.js";
import LoadingOverlay from "/Content/js/util/LoadingOverlay.js";


var registerButton =    document.querySelector(".register-button"),
    inputRepository =   new InputRepository(document.querySelectorAll(".input")),
    registerForm =      document.forms[0],
    modal =             new Modal(".modal-overlay"),
    today =             new Date(),
    month =             (today.getMonth() > 10 ? "" : "0") + today.getMonth(),
    day =               (today.getDate() > 10 ? "" : "0") + today.getDate(),
    overlay =           new LoadingOverlay(".loading-overlay")
;



inputRepository.inputs.forEach(input => input.addValidator("To pole jest wymagane", x => x != null && x != ""));

inputRepository.getInputByName("username").addValidator("Podana nazwa użytkownika już istnieje", async x => await validate("username", x));
inputRepository.getInputByName("emailAddress").addValidator("Adres e-mail jest nieprawidłowy", x => /^[a-zA-Z0-9\-\_\.]+\@([a-z]+\.)+[a-z]{2,3}$/g.test(x));
inputRepository.getInputByName("emailAddress").addValidator("Podany adres e-mail już istnieje", async x => await validate("emailAddress", x));



registerForm["birthDate"].max = `${today.getFullYear()}-${month}-${day}`;





registerButton.addEventListener("click", e => {
    e.preventDefault();
    var valid = true;

    inputRepository.inputs.forEach(input => {
        if (!input.validate()) 
            valid = false;
    });

    if (valid) {
        overlay.show();
        fetch("/register/DoRegister", {
            method: "POST",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            body: JSON.stringify([...registerForm].filter(x => x.name != "").reduce((map, x) => {
                map[x.name] = x.value;
                return map;
            }, {}))
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
}, false);



modal.onClose = function(x) {
    window.location.pathname = "/login";
}



function validate(fieldName, x) {
    return fetch("/register/validate", {
        method: "POST",
        headers: {
            "Content-Type": "application/x-www-form-urlencoded"
        },
        body: `${fieldName}=${x}`
    })
        .then(res => res.json())
        .then(res => [...res].map(x => AccountValidationResultParser.parse(x)).find(x => x.fieldName == fieldName).result);
}