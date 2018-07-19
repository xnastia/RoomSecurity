function httpGetAsync(theUrl, callbackOnOk, callbackOnError) {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState === 4)
            if (xmlHttp.status === 200)
                callbackOnOk(xmlHttp.response);
            else if (callbackOnError !== undefined)
                callbackOnError(xmlHttp);
    }
    xmlHttp.open("GET", theUrl, true); // true for asynchronous
    xmlHttp.send(null);
}

function httpPostAsync(theUrl, postObject, callbackOnOk, callbackOnError) {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState === 4)
            if (xmlHttp.status === 200)
                callbackOnOk(xmlHttp.response);
            else if (callbackOnError !== undefined)
                callbackOnError(xmlHttp);
    }
    xmlHttp.open("POST", theUrl, true); // true for asynchronous
    xmlHttp.send(postObject);
}

function refreshLogin() {
    var emailIdElement = document.getElementById("email");
    var email = emailIdElement.value;
    var passwordIdElement = document.getElementById("password");
    var password = passwordIdElement.value;
    httpPostAsync("http://localhost:59428/AccountControler/Login?email=" + email + "&password=" + password,
        window.location.replace(),
        window.location.replace());
}