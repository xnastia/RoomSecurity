//function buildSecurityDashboardTable(jsonData) {
//    if (jsonData === undefined)
//        return;

//    var myList = JSON.parse(jsonData).SecurityScannerStatuses;

//    var table = document.getElementById("securityDashboardTable");
//    while (table.hasChildNodes()) {
//        table.removeChild(table.firstChild);
//    }

//    var columns = addAllColumnHeaders(myList);

//    for (var i = 0; i < myList.length; i++) {
//        var row$ = $('<tr/>');
//        for (var colIndex = 0; colIndex < columns.length; colIndex++) {
//            var cellValue = myList[i][columns[colIndex]];

//            if (cellValue == null) {
//                cellValue = "";
//            }

//            row$.append($('<td/>').html(cellValue));
//        }
//        $("#securityDashboardTable").append(row$);
//    }
//}

//function addAllColumnHeaders(myList) {
//    var columnSet = [];
//    var headerTr$ = $('<tr/>');

//    for (var i = 0; i < myList.length; i++) {
//        var rowHash = myList[i];
//        for (var key in rowHash) {
//            if ($.inArray(key, columnSet) === -1) {
//                columnSet.push(key);
//                headerTr$.append($('<th/>').html(key));
//            }
//        }
//    }
//    $("#securityDashboardTable").append(headerTr$);

//    return columnSet;
//}