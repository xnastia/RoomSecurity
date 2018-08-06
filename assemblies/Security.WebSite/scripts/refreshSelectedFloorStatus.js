function updateStatus(jsonData) {
    updateCheckTime(jsonData);
    dashboard.buildSecurityDashboard(jsonData);
}

function updateCheckTime(jsonData) {
    if (jsonData === undefined)
        return;
    var timeString = JSON.parse(jsonData).CheckTime;
    var checkTime = document.getElementById("checkTime");
    checkTime.innerText = timeString;
}

function refreshFloorTableResult() {
    setInterval(function () {
        refreshSelectedFloorStatus();
    }, 5000);
}

function refreshSelectedFloorStatus() {
    var monitorIdElement = document.getElementById("floor");
    var monitorId = monitorIdElement.value;
    if (checkIsScannerEnabled())
        httpGetAsync("api/dashboard/GetMonitorStatus?monitorId=" + monitorId, updateStatus);
}

function checkIsScannerEnabled() {
    var checkbox = document.getElementById("scannerSwitcher");
    var scannerEnabled = checkbox.checked;
    return scannerEnabled;
}

