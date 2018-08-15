var alarmReport = new function(){
    var self = this;
    
    self.init = function() {
        self.blockPanel = document.getElementById("block-panel");
        self.alarmReport = document.getElementById("alarm-report");
        self.roomName = "";
    };

    window.onclick = function(event) {
        if (event.target === self.blockPanel) {
            self.alarmReport.style.display = "none";
            self.blockPanel.style.display = "none";
        }
    }
    self.showAlarmReport = function (roomName) {
        self.alarmReport.style.display = "block";
        self.blockPanel.style.display = "block";
        roomName = roomName.replace("-"," ");
        self.roomName = roomName;
        refreshSelectedRoomAlarmStatus(self.roomName);
    }
    
    self.hideAlarmReportOnCloseBtnClick = function() {
        self.alarmReport.style.display = "none";
        self.blockPanel.style.display = "none";
        event.stopPropagation();
    }

    /*function refreshSelectedRoomAlarmReport(roomName) {
        setInterval(function () {
            refreshSelectedRoomAlarmStatus(roomName);
        }, 7000);
    }*/
    
    function refreshSelectedRoomAlarmStatus(roomName) {
        httpGetAsync("api/dashboard/GetAlarmStatusHistory?roomName=" + roomName, updateStatus);
    }

    function updateStatus(jsonData) {
        buildTable(jsonData, "alarm-report-table");
    }

    return self;
}