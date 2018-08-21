function refreshSelectedRoomAlarmReport(roomName) {
    setInterval(function () {
        refreshSelectedRoomAlarmStatus(roomName);
    }, 10000);
}

function refreshSelectedRoomAlarmStatus(roomId) {
    httpGetAsync("api/dashboard/GetAlarmStatusHistory?roomId=" + roomId, updateStatus);
}

function updateStatus(jsonData) {
    buildTable(jsonData);
}
