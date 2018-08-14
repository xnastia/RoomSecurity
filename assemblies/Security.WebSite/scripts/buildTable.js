function buildTable(jsonData, elementId) {
    if (jsonData === undefined)
        return;

    var list = JSON.parse(jsonData);
    var table = document.getElementById(elementId);
    while (table.hasChildNodes()) {
        table.removeChild(table.firstChild);
    }

    var columns = addAllColumnHeaders(list, elementId);

    for (var i = 0; i < list.length; i++) {
        var row$ = $("<tr/>");
        for (var colIndex = 0; colIndex < columns.length; colIndex++) {
            var cellValue = list[i][columns[colIndex]];

            if (cellValue == null) {
                cellValue = "";
            }
            row$.append($("<td/>").html(cellValue));
        }
        $("table#" + elementId).append(row$);
    }
}

function addAllColumnHeaders(list, elementId) {
    var columnSet = [];
    var headerTr$ = $("<tr/>");

    for (var i = 0; i < list.length; i++) {
        var rowHash = list[i];
        for (var key in rowHash) {
            if ($.inArray(key, columnSet) === -1) {
                columnSet.push(key);
                headerTr$.append($("<th/>").html(key));
            }
        }
    }
    $("table#" + elementId).append(headerTr$);

    return columnSet;
}