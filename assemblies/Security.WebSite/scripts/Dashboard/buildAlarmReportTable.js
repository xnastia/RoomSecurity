function refreshSelectedRoomAlarmReport(roomName) {
    setInterval(function () {
        refreshSelectedRoomAlarmStatus(roomName);
    }, 10000);
}

function refreshSelectedRoomAlarmStatus(roomName) {
        httpGetAsync("api/dashboard/GetMonitorStatus?roomName=" + roomName, updateStatus);
}

function updateStatus(jsonData) {
    buildTable(jsonData);
}
