function displayInvalidLogin() {
    document.getElementById("validate error").innerText = "Incorrect email or password";
}

var token;

function showSecurityDashboard(responseToken) {
    token = responseToken;
    dashboard.init();
    alarmReport.init();
    /*var header = document.getElementById("header");
    header.display = "block";
    var login = document.getElementById("login");
    login.display = "none";
    var board = document.getElementById("dashboard");
    board.display = "block";*/

}

function authenticateUser() {
    var emailIdElement = document.getElementById("email");
    var email = emailIdElement.value;
    var passwordIdElement = document.getElementById("password");
    var password = passwordIdElement.value;
    var userObject = "email=" + email + "&password=" + password;
    httpPostAsync("api/login", userObject,
        showSecurityDashboard,
        displayInvalidLogin);
}