import ajax from "./../../components/ajax.js";
import modal from "./../../components/modal.js";
import datepicker from "./../../components/datepicker.js";
import timepicker from "./../../components/timepicker.js";

(() => {
    datepicker();
    timepicker();

    var campaignForm = document.querySelector("form");
    var request = null;
    var submitBtn = document.getElementById("submit-btn");

    function signIn(event) {
        event.preventDefault();
        submitBtn.classList.add("disabled");
        if (request && request.readyState < 4) return;
        request = ajax({
            data: campaignForm,
            onResponse: response => {
                if (response.saved) {
                    campaignForm.reset();
                    window.location = "/campaign/list";
                }  else {
                    modal("Ocurrio un error", response.cause || "No se puede procesar su solicitud en este momento");                    
                    submitBtn.classList.remove("disabled");s
                }
            }
        });
    }
    if (campaignForm) {
        campaignForm.addEventListener("submit", signIn);
    } else {
        console.warn("Could not find campaign form");
    }
})();