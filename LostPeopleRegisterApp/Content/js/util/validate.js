import AccountValidationResultParser from "/Content/js/account/AccountValidationResultParser.js";

/*
 * Funkcja ma za zadanie sprawdzić poprawność wprowadzanych danych poprzez dostęp do zasobów
 * serwera
 * 
 * @controllerName  - nazwa kontrolera, do którego będzie wysłane żądanie walidacji
 * @dieldName       - nazwa pola, które ma być walidowane
 * @value           - wartość, która ma być poddana walidacji
 */
export default function validate(controllerName, fieldName, value) {
    return fetch(`/${controllerName}/validate`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json; charset=UTF-8"
        },
        body: `{"${fieldName}": "${value}"}`
    })
        .then(res => res.json())
        .then(res => [...res].map(x => AccountValidationResultParser.parse(x)).find(x => x.fieldName == fieldName).result);
}