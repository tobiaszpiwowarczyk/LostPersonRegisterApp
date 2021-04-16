/*
 * Skrypt do zarządzania danymi wyświetlanymi na stronie do zarządzania
 * użytkownikami
 */
import Modal from "/Content/js/modal/Modal.js";
import SelectionInput from "/Content/js/input/SelectionInput.js";

var changeAccountRoleLinks  = [...document.querySelectorAll(".change-account-role-link")],
    changeUserRoleModal     = new Modal("#change-user-role-modal"),
    table                   = document.querySelector(".table"),
    userData                = document.querySelector(".user-data"),
    roleInput               = new SelectionInput(document.querySelector(".input.input--selection"))
;

var obj = {};

changeAccountRoleLinks.forEach((link, i) => {
    link.addEventListener("click", e => {
        e.preventDefault();

        var row = table.querySelector(`tbody tr:nth-child(${[...table.querySelectorAll("tbody tr")].indexOf(link.parentElement.parentElement)+1})`);
        var firstName = row.querySelector(`td:nth-child(3)`).innerHTML;
        var lastName = row.querySelector(`td:nth-child(4)`).innerHTML;
        userData.innerHTML = `${firstName} ${lastName}`;

        roleInput.setValue(link.dataset.roleid);

        obj.accountId = parseInt(link.dataset.accountid);

        changeUserRoleModal.show();
    }, false);
});



roleInput.onChange = x => obj.roleId = x.value;


changeUserRoleModal.onClose = x => {
    console.log(obj);
    if (x.approved) {
        fetch(`/account/updateAccountRole?accountId=${obj.accountId}&roleId=${obj.roleId}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json; charset=UTF-8"
            }
        })
            .then(res => res.json())
            .then(res => {
                if (res.updated) {
                    window.location.reload();
                }
            });
    }
}