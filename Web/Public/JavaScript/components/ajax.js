/**
 * Performs an Ajax request
 * @param {*} options Ajax options
 * @returns {XMLHttpRequest} Request made
 */
export default function({ url, method, data, onResponse }) {
    if (data instanceof HTMLFormElement) {
        url = data.action;
        method = data.method;
    }
    var request = new XMLHttpRequest();

    request.open(method, url, true);

    request.onreadystatechange = function () {
        if (request.readyState === 4) {
            try {
                var res = JSON.parse(request.responseText, request.status);
                onResponse(res);
            } catch (e){
                onResponse(request.responseText, request.status);
            }
        }
    };

    var string;
    if (data instanceof HTMLFormElement) {
        request.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        var formData = new FormData(data);
        string = "";
        for (var pair of formData.entries()) {
            string += `${pair[0]}=${pair[1]}&`;
        }
        string = string.substring(0, string.length - 1);
        string = encodeURI(string);
        request.send(string);
    } else if (method.toLowerCase() === "post") {
        request.setRequestHeader("X-Requested-With", "XMLHttpRequest");
        request.setRequestHeader("Content-Type", "application/json");
        try {
            string = JSON.stringify(data);
            request.send(string);
        } catch (e) {
            request.send(data);
        }
    } else {
        request.send(data);
    }

    return request;
};