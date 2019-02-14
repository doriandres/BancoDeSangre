// Ajax coming soon

function ajax({ url, type, data, success }) {
    var ajax = new XMLHttpRequest();
    ajax.open(type, url, true);
    ajax.onreadystatechange = function () {
        if (ajax.readyState === 4) {
            success(JSON.parse(ajax.responseText));
        }
    };
    ajax.setRequestHeader("Content-type", "application/json");
    ajax.setRequestHeader("X-Requested-With", "XMLHttpRequest");
    ajax.send(JSON.stringify(data));
}