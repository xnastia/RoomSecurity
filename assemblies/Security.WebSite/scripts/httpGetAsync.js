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
    xmlHttp.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    xmlHttp.send(postObject);
}

function displayInvalidLogin() {
    document.getElementById("validate error").innerText = "Incorrect email or password";
}

function redirectToSecurityDashboard() {
    window.location.replace("dashboard.html");
}

function authenticateUser() {
    var emailIdElement = document.getElementById("email");
    var email = emailIdElement.value;
    var passwordIdElement = document.getElementById("password");
    var password = passwordIdElement.value;
    var userObject = "email=" + email + "&password=" + password;
        httpPostAsync("api/login", userObject,
            redirectToSecurityDashboard,
            displayInvalidLogin);
}

