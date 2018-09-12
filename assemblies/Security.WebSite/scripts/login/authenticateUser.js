function displayInvalidLogin() {
    document.getElementById("validate error").innerText = "Incorrect email or password";
}

var token;

function onUserAuthenticated(responseToken) {
    token = JSON.parse(responseToken);
    dashboard.init();
    alarmReport.init();
    var header = document.getElementById("header");
    header.style.display = "block";
    var login = document.getElementById("login");
    login.style.display = "none";
    var board = document.getElementById("dashboard");
    board.style.display = "block";
    getScrollMenuButtonsHtml();
}

function authenticateUser() {
    var emailIdElement = document.getElementById("email");
    var email = emailIdElement.value;
    var passwordIdElement = document.getElementById("password");
    var password = passwordIdElement.value;
    var userObject = "email=" + email + "&password=" + password;
    httpPostAsync("api/login", userObject,
        onUserAuthenticated,
        displayInvalidLogin);
}