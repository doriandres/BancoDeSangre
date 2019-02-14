var sendBtn = document.getElementById("sendBtn");

function signIn() {
    ajax({
        url: "/account/CheckSignIn",
        type: "POST",
        data: {
            email: document.getElementById("emailField").value,
            password: document.getElementById("passwordField").value
        },
        success: response => {
            alert(response.result ? ":D" : ":(");          
        }
    });
}
if (sendBtn) {
    sendBtn.addEventListener("click", signIn);
}