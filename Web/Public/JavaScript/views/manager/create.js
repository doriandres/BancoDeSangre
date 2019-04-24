import ajax from './../../components/ajax.js';
import modal from "./../../components/modal.js";
(() => {
    var createManagerForm = document.querySelector("form");
    var request = null;
    function createManager(event) {
        event.preventDefault();
        if (request && request.readyState < 4) return; // Hay un request en proceso o el formulario es invalido        
        request = ajax({
            data: createManagerForm,
            onResponse: response => {
                if (response.saved) {
                    createManagerForm.reset();
                    modal("Información","Administrador creado existosamente!");
                } else if (response.cause) {
                    modal("Ocurrió un error",response.cause);
                } else {
                    modal("Ocurrió un error","Lo sentimos ocurrió un error, intentelo más tarde");
                }
            }
        });
    }
    if (createManagerForm) {
        createManagerForm.addEventListener("submit", createManager);
    } else {
        console.warn("Could not find sign in form");
    }
})();