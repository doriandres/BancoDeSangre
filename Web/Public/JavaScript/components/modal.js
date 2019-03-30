export default function (modalTitle, modalBody) {
    modalSingleton.close();
    var m = document.getElementById("modal");
    m.querySelector(".modal-title").innerHTML = modalTitle;
    m.querySelector(".modal-body").innerHTML = modalBody;
    modalSingleton.open();
}