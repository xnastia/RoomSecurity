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

function refreshFloorTableResult() {
    setInterval(function () {
        refreshSelectedFloorStatus();
    }, 5000);
}

function refreshSelectedFloorStatus() {
    if (checkIsScannerEnabled())
        httpGetAsync("api/dashboard/GetMonitorStatus?monitorId=" + dashboard.currentMonitorId, updateStatus);
}

function checkIsScannerEnabled() {
    var checkbox = document.getElementById("scanner-switcher");
    var scannerEnabled = checkbox.checked;
    return scannerEnabled;
}

