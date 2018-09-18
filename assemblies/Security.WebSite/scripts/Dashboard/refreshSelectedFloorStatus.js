function updateStatus(jsonData) {
    updateCheckTime(jsonData);
    dashboard.buildSecurityDashboard(jsonData);
}

function updateCheckTime(jsonData) {
    if (jsonData === undefined)
        return;
    var timeString = JSON.parse(jsonData).CheckTime;
    var checkTime = document.getElementById("check-time");
    checkTime.innerText = timeString;
}

function refreshFloorTableResult(turnedOn) {
    setInterval(function () {
        refreshSelectedFloorStatus(turnedOn);
    }, 5000);
}

function refreshSelectedFloorStatus(turnedOn) {
    if (turnedOn)
        httpGetAsync("api/dashboard/GetMonitorStatus?monitorId=" + dashboard.currentMonitorId, updateStatus, showError);
}

/*function checkIsScannerEnabled() {
    var checkbox = document.getElementById("scanner-switcher");
    var scannerEnabled = checkbox.checked;
    return scannerEnabled;
}*/

function showError(obj) {
    alert("some error");
}