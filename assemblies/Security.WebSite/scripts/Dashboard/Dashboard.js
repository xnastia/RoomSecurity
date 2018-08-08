var dashboard = new function() {
    var self = this;

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
                if (cellValue === true) {
                    cellValue = "<img class='bool-icon' src='/assets/images/ok.png'>";
                } else if(cellValue === false) {
                    cellValue = "<img class='bool-icon' src='/assets/images/notOk.png'>";
                }
                if (typeof cellValue === "string") {
                    cellValue = "<a id='myBtn' onclick=alarmReport.showAlarmReport()>" + cellValue + "</a>";
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

    self.buildSecurityDashboard = function (jsonData) {
        buildSecurityDashboardTable(jsonData);
    };

    self.init = function() {
        $('#scanner-switcher').change(function () {
            refreshSelectedFloorStatus();
        });
    };
    return self;
}