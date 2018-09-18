var currentMonitor = { id: null, turnedOn: false }
var dashboard = new function () {
    var self = this;
    
    function buildSecurityDashboardTable(jsonData) {
        if (jsonData === undefined)
            return;
        
        var scannerStatuses = JSON.parse(jsonData).SecurityScannerStatuses;

        var table = document.getElementById("securityDashboardTable");
        
        while (table.hasChildNodes()) {
            table.removeChild(table.firstChild);
        }

        //header
        $("#securityDashboardTable").append($('<tr/>')
            .append($('<th/>').html("Room Name"))
            .append($('<th/>').html("Status")));

        //body
        for (var i = 0; i < scannerStatuses.length; i++) {
            var currentRoom = scannerStatuses[i];

            var row$ = $('<tr/>');
            row$.append($('<td/>').html("<a onclick=alarmReport.showAlarmReport(this.id) id="
                + currentRoom.RoomInfo.UiId + ">" + currentRoom.RoomInfo.Name + "</a>"));

            if (currentRoom.IsOk) {
                row$.append($('<td/>').html("<img class='bool-icon' src='/assets/images/ok.png'>"));
            }
            else {
                row$.append($('<td/>').html("<img class='bool-icon' src='/assets/images/notOk.png'>"));
            }
            
            $("#securityDashboardTable").append(row$);
        }
    }

    self.buildSecurityDashboard = function (jsonData) {
    buildSecurityDashboardTable(jsonData);
};

self.init = function() {
    $("#scanner-switcher").change(function () {
        if (!currentMonitor.turnedOn) {
            currentMonitor.turnedOn = !currentMonitor.turnedOn;
            refreshFloorTableResult(currentMonitor.turnedOn);
       }      
    });
};

return self;
}