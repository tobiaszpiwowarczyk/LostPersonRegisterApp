/*
 * Skrypt, który ma za zadanie zarządzać funkcjami dostępnymi w nagłówku strony
 */

var headerMenuItems = [...document.querySelectorAll(".header__menu__item")].filter(x => x.href != window.location.origin + "/"),
    currentPath = window.location.pathname
;

headerMenuItems.forEach(x => {
    if (x.href == window.location.href) {
        x.classList.add("header__menu__item--active");
    }
})