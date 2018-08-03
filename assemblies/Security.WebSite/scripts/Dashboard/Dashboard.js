﻿var dashboard = new function() {
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
                    cellValue = "<img class='boolIcon' src='/assets/images/okIcon.jpg'>";
                } else if(cellValue === false) {
                    cellValue = "<img class='boolIcon' src='/assets/images/notOk.jpg'>";
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
        $('#checkScanner').change(function () {
            refreshSelectedFloorStatus();
        });
    };

    return self;
}