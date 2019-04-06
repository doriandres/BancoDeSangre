import ajax from "./../../components/ajax.js";
import modal from "./../../components/modal.js";
import datepicker from "./../../components/datepicker.js";
import timepicker from "./../../components/timepicker.js";

(() => {
    datepicker();
    timepicker();

    var medicalcenterForm = document.querySelector("form");
    var request = null;
    var submitBtn = document.getElementById("submit-btn");

    function signIn(event) {
        event.preventDefault();
        submitBtn.classList.add("disabled");
        if (request && request.readyState < 4) return;
        request = ajax({
            data: medicalcenterForm,
            onResponse: response => {
                if (response.saved) {
                    medicalcenterForm.reset();
                    window.location = "/medicalcenter/list";
                } else {
                    modal("Ocurrio un error", !response.cause ? "No se puede procesar su solicitud en este momento" : response.cause);
                    submitBtn.classList.remove("disabled");
                }
            }
        });
    }
    if (donorForm) {
        medicalcenterForm.addEventListener("submit", signIn);
    } else {
        console.warn("Could not find medical center form");
    }
})();