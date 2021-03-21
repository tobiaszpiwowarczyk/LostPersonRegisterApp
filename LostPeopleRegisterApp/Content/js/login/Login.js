/*
 * Skrypt wykorzystywany na stronie logowania serwisu
 */

import InputRepository from "/Content/js/input/InputRepository.js";
import LoadingOverlay from "/Content/js/util/LoadingOverlay.js";

var loginButton = document.querySelector(".login-button"),
    loginForm = document.forms[0],
    inputRepository = new InputRepository(document.querySelectorAll(".input")),
    overlay = new LoadingOverlay(".loading-overlay"),
    loginErrorWrapper = document.querySelector(".login-error-wrapper")
;

inputRepository.inputs.forEach(input => input.addValidator("To pole jest wymagane", x => x != null && x != ""));

loginButton.addEventListener("click", e => {
    e.preventDefault();
    var valid = true;

    inputRepository.inputs.forEach(input => {
        if (!input.validate())
            valid = false;
    });

    if (valid) {
        overlay.show();
        fetch("/login/validate", {
            method: "POST",
            headers: {
                "Content-Type": "application/x-www-form-urlencoded"
            },
            body: `username=${loginForm["username"].value}&password=${loginForm["password"].value}`
        })
            .then(res => res.json())
            .then(res => {
                overlay.hide();
                console.log(res.valid);
                if(!res.valid) {
                    loginErrorWrapper.classList.add("login-error-wrapper--shown");
                    loginErrorWrapper.innerHTML = "Nazwa użytkonika bądź hasło jest nieprawidłowe";

                    [...loginForm].forEach(input => input.value = "");
                    loginForm["username"].focus();
                }
                else {
                    loginErrorWrapper.classList.remove("login-error-wrapper--shown");
                    fetch("/login/doLogin", {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/x-www-form-urlencoded"
                        },
                        body: `username=${loginForm["username"].value}&password=${loginForm["password"].value}`
                    })
                        .then(() => window.location.pathname = "/");
                }
            });
    }
}, false);