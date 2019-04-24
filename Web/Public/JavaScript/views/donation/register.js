import ajax from "./../../components/ajax.js";
import modal from "./../../components/modal.js";
import datepicker from "./../../components/datepicker.js";

(() => {
    datepicker();

    var donationForm = document.querySelector("form");
    var request = null;
    var submitBtn = document.getElementById("submit-btn");

    function register(event) {
        event.preventDefault();
        submitBtn.classList.add("disabled");
        if (request && request.readyState < 4) return;
        request = ajax({
            data: donationForm,
            onResponse: response => {
                if (response.saved) {
                    donationForm.reset();
                    window.location = "/donation/list";
                }  else {
                    modal("Ocurrio un error", !response.cause ? "No se puede procesar su solicitud en este momento" : response.cause);
                    submitBtn.classList.remove("disabled");
                }
            }
        });
    }
    if (donationForm) {
        donationForm.addEventListener("submit", register);
    } else {
        console.warn("Could not find donation form");
    }
})();