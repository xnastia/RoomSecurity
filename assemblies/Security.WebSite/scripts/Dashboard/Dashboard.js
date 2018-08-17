var dashboard = new function () {
    var self = this;
    var currentMonitorId;

    function buildSecurityDashboardTable(jsonData) {
        if (jsonData === undefined)
            return;

        var myList = JSON.parse(jsonData).SecurityScannerStatuses;

        var table = document.getElementById("securityDashboardTable");
        while (table.hasChildNodes()) {
            table.removeChild(table.firstChild);
        }

        var columns = addAllColumnHeaders(myList);

        for (var i = 0; i < myList.length; i++) {
            var row$ = $('<tr/>');
            for (var colIndex = 0; colIndex < columns.length; colIndex++) {
                var cellValue = myList[i][columns[colIndex]];

                if (cellValue == null) {
                    cellValue = "";
                }
                
                if (typeof cellValue === "string") {
                    var parsedCellValue = cellValue.split(' ');
                    if (parsedCellValue[1] != null) {
                        parsedCellValue = parsedCellValue[0] +"-"+ parsedCellValue[1];
                    }
                    cellValue = "<a onclick=alarmReport.showAlarmReport(this.id) id=" + parsedCellValue + ">"
                        + cellValue + "</a>";
                }

                if (cellValue === true) {
                    cellValue = "<img class='bool-icon' src='/assets/images/ok.png'>";
                } else if(cellValue === false) {
                    cellValue = "<img class='bool-icon' src='/assets/images/notOk.png'>";
                }

                row$.append($('<td/>').html(cellValue));
                
               }
            $("#securityDashboardTable").append(row$);
        }
    }
    function addAllColumnHeaders(myList) {
        var columnSet = [];
        var headerTr$ = $('<tr/>');

        for (var i = 0; i < myList.length; i++) {
            var rowHash = myList[i];
            for (var key in rowHash) {
                if ($.inArray(key, columnSet) === -1) {
                    columnSet.push(key);
                    headerTr$.append($('<th/>').html(key));
                }
            }
        }
        $("#securityDashboardTable").append(headerTr$);

        return columnSet;
    }

self.buildSecurityDashboard = function(jsonData) {
    buildSecurityDashboardTable(jsonData);
};

self.init = function() {
    $("#scanner-switcher").change(function() {
        refreshSelectedFloorStatus();
    });
};
return self;
}