import ajax from './../../components/ajax.js';
(() => {
    var campaignForm = document.querySelector("form");
    var request = null;
    function signIn(event) {
        event.preventDefault();
        if (request && request.readyState < 4) return;
        request = ajax({
            data: campaignForm,
            onResponse: response => {
                if (response.saved) {
                    campaignForm.reset();
                    window.location = "/";
                } else if (response.cause) {
                    alert(response.cause);
                } else {
                    alert("No se pudo crear la campaña intentelo más tarde");
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