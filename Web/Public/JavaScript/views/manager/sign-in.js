import ajax from './../../components/ajax.js';
(() => {
    var signInForm = document.querySelector("form");
    var request = null;
    function signIn(event) {
        event.preventDefault();
        if (request && request.readyState < 4) return; // Hay un request en proceso o el formulario es invalido        
        request = ajax({
            data: signInForm,
            onResponse: response => {
                if (response.valid) {
                    signInForm.reset();
                    window.location = "/";
                } else {
                    alert(response.cause);
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