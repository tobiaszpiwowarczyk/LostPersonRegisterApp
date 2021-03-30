/*
 * Skrypt wykorzystywany na stronie logowania serwisu
 */

import InputRepository from "/Content/js/input/InputRepository.js";
import LoadingOverlay from "/Content/js/util/LoadingOverlay.js";

var loginButton         = document.querySelector(".login-button"),
    inputRepository     = new InputRepository(document.querySelectorAll(".input")),
    overlay             = new LoadingOverlay(".loading-overlay"),
    loginErrorWrapper   = document.querySelector(".login-error-wrapper")
;

inputRepository.forEach(input => input.addValidator("To pole jest wymagane", x => x != null && x != ""));

loginButton.addEventListener("click", e => {
    e.preventDefault();
    (async () => {
        if (await inputRepository.validateAll()) {
            overlay.show();
            fetch("/login/validate", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json; charset=UTF-8"
                },
                body: JSON.stringify(inputRepository.parseInputsToObject())
            })
                .then(res => res.json())
                .then(res => {
                    overlay.hide();
                    if(!res.valid) {
                        loginErrorWrapper.classList.add("login-error-wrapper--shown");
                        loginErrorWrapper.innerHTML = "Nazwa użytkonika bądź hasło jest nieprawidłowe";

                        inputRepository.forEach(input => {
                            input.clear();
                            input.setInvalid(false);
                        });

                        inputRepository.getInputByName("username").focus();
                    }
                    else {
                        loginErrorWrapper.classList.remove("login-error-wrapper--shown");
                        fetch("/login/doLogin", {
                            method: "POST",
                            headers: {
                                "Content-Type": "application/json; charset=UTF-8"
                            },
                            body: JSON.stringify(inputRepository.parseInputsToObject())
                        })
                            .then(() => window.location.pathname = "/");
                    }
                });
        }
    })();
}, false);