function displayInvalidLogin() {
    document.getElementById("validate error").innerText = "Incorrect email or password";
}

function redirectToSecurityDashboard(headers) {
    window.location.replace("dashboard.html?securityId=" + headers.get("Authorization"));
}

function authenticateUser() {
    var emailIdElement = document.getElementById("email");
    var email = emailIdElement.value;
    var passwordIdElement = document.getElementById("password");
    var password = passwordIdElement.value;
    var userObject = "email=" + email + "&password=" + password;
    var headers = new window.Headers();
    headers.append("Authorization", email + password);
    httpPostAsync("api/login", userObject,
        redirectToSecurityDashboard(headers),
        displayInvalidLogin);
}