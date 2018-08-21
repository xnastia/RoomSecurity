var alarmReport = new function(){
    var self = this;
    
    self.init = function() {
        self.blockPanel = document.getElementById("block-panel");
        self.alarmReport = document.getElementById("alarm-report");
        self.Id = "";
    };

    window.onclick = function(event) {
        if (event.target === self.blockPanel) {
            self.alarmReport.style.display = "none";
            self.blockPanel.style.display = "none";
        }
    }

    self.showAlarmReport = function (roomId) {
        self.alarmReport.style.display = "block";
        self.blockPanel.style.display = "block";
        self.roomId = roomId;
        refreshSelectedRoomAlarmStatus(self.roomId);
    }
    
    self.hideAlarmReportOnCloseBtnClick = function() {
        self.alarmReport.style.display = "none";
        self.blockPanel.style.display = "none";
        event.stopPropagation();
    }

    /*function refreshSelectedRoomAlarmReport(roomId) {
        setInterval(function () {
            refreshSelectedRoomAlarmStatus(roomId);
        }, 7000);
    }*/
    
    function refreshSelectedRoomAlarmStatus(roomId) {
        httpGetAsync("api/dashboard/GetAlarmStatusHistory?roomId=" + roomId, updateStatus);
    }

    function updateStatus(jsonData) {
        buildTable(jsonData, "alarm-report-table");
    }

    return self;
}