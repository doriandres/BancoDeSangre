import ajax from './../../components/ajax.js';
import modal from './../../components/modal.js';
(() => {
    var signInForm = document.querySelector("form");
    var submitBtn = document.getElementById("submit-btn");
    var request = null;
    function signIn(event) {
        event.preventDefault();
        submitBtn.classList.add("disabled");
        if (request && request.readyState < 4) return; // Hay un request en proceso o el formulario es invalido        
        request = ajax({
            data: signInForm,
            onResponse: response => {                
                if (response.valid) {
                    signInForm.reset();
                    window.location = "/";
                } else {
                    modal("Ocurrió un error", response.cause || "En este momento no podemos procesar su solicitud");
                    submitBtn.classList.remove("disabled");
                }
            }
        });        
    }
    if (signInForm) {
        signInForm.addEventListener("submit", signIn);
    } else {
        console.warn("Could not find sign in form");
    }
})();