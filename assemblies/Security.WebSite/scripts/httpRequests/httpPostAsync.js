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
    xmlHttp.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    xmlHttp.setRequestHeader("Authorization", "Authorization: Basic QWxhZGRpbjpvcGVuIHNlc2FtZQ==");
    xmlHttp.send(postObject);
}