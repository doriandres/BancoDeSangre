export default function () {
    var timePickers = document.querySelectorAll(".timepicker");
    timePickers.forEach(tp => tp.setAttribute("type", "text"));
    if (timePickers.length) {
        M.Timepicker.init(timePickers, {
            i18n: {
                cancel: "Cancelar",
                clear: "Limpiar",
                done: "Listo"
            }
        });
    }    
}