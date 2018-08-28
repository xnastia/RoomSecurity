function refreshSelectedRoomAlarmReport(roomName) {
    setInterval(function () {
        refreshSelectedRoomAlarmStatus(roomName);
    }, 10000);
}

function refreshSelectedRoomAlarmStatus(roomId, page) {
    httpGetAsync("api/dashboard/GetAlarmStatusHistory?roomId=" + roomId +"&page="+page, updateStatus);
}

function updateStatus(jsonData) {
    buildTable(jsonData);
}
