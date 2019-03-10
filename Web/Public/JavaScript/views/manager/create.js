import ajax from './../../components/ajax.js';
(() => {
    var createManagerForm = document.querySelector("form");
    var request = null;
    function signIn(event) {
        event.preventDefault();
        if (request && request.readyState < 4) return; // Hay un request en proceso o el formulario es invalido        
        request = ajax({
            data: createManagerForm,
            onResponse: response => {
                if (response.saved) {
                    createManagerForm.reset();
                    alert("Administrador creado existosamente!");
                    window.location = window.location;
                } else if (response.cause) {
                    alert(response.cause);
                } else {
                    alert("Lo sentimos ocurrió un error, intentelo más tarde");
                }
            }
        });
    }
    if (createManagerForm) {
        createManagerForm.addEventListener("submit", signIn);
    } else {
        console.warn("Could not find sign in form");
    }
})();