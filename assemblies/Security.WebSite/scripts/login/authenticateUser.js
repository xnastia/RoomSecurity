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
    var headers = new window.Headers();
    headers.append("Authorization",email+password);
}