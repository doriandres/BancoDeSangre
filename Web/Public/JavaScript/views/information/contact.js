import ajax from './../../components/ajax.js';
import modal from "./../../components/modal.js";
(() => {
    var sendMessageForm = document.querySelector("form");
    var request = null;
    function sendInfo(event) {
        event.preventDefault();
        if (request && request.readyState < 4) return; // Hay un request en proceso o el formulario es invalido        
        request = ajax({
            data: sendMessageForm,
            onResponse: response => {
                if (response.done) {
                    sendMessageForm.reset();
                    modal("Información", "Su mensaje fue envíado exitosamente");
                    window.location = window.location;
                } else if (response.cause) {
                    modal("Ocurrio un error",response.cause);
                } else {
                    modal("Ocurrio un error","Lo sentimos ocurrió un error, intentelo más tarde");
                }
            }
        });
    }
    if (sendMessageForm) {
        sendMessageForm.addEventListener("submit", sendInfo);
    } else {
        console.warn("Could not find sign in form");
    }
})();