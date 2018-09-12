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
    xmlHttp.setRequestHeader("AuthToken", token);
    xmlHttp.send(null);
}

