export default function () {
    var datePickers = document.querySelectorAll(".datepicker");
    datePickers.forEach(dp => dp.setAttribute("type", "text"));
    if (datePickers.length) {
        M.Datepicker.init(datePickers, {
            format: "mm-dd-yyyy",
            i18n: {
                cancel: "Cancelar",
                clear: "Limpiar",
                done: "Listo",
                months: [
                    "Enero",
                    "Febrero",
                    "Marzo",
                    "Abril",
                    "Mayo",
                    "Junio",
                    "Julio",
                    "Augosto",
                    "Setiembre",
                    "Octubre",
                    "Noviembre",
                    "Diciembre"
                ],
                monthsShort: [
                    "Ene",
                    "Feb",
                    "Mar",
                    "Abr",
                    "May",
                    "Jun",
                    "Jul",
                    "Ago",
                    "Set",
                    "Oct",
                    "Nov",
                    "Dic"
                ],
                weekdays: [
                    "Domingo",
                    "Lunes",
                    "Martes",
                    "Miércoles",
                    "Jueves",
                    "Viernes",
                    "Sábado"
                ],
                weekdaysShort: [
                    "Dom",
                    "Lun",
                    "Mar",
                    "Mie",
                    "Jue",
                    "Vie",
                    "Sab"
                ],
                weekdaysAbbrev: ["D", "L", "K", "M", "J", "V", "S"]
            }
        });
    }    
}