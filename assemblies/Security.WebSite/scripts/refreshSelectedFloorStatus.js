function updateStatus(jsonData) {
    updateCheckTime(jsonData);
    buildSecurityDashboardTable(jsonData);
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
    httpGetAsync("http://localhost:59428/SecurityDashboard/GetMonitorStatus?monitorId=" + monitorId, updateStatus);
}

