function httpGetAsync(theUrl, callback) {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState === 4 && xmlHttp.status === 200)
            callback(xmlHttp.response);
    }
    xmlHttp.open("GET", theUrl, true); // true for asynchronous
    xmlHttp.send(null);
}

function buildHtmlTable(jsonData) {
    if (jsonData === undefined)
        return;

    var myList = JSON.parse(jsonData);

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

function updateCheckTime(currentTime) {
    if (currentTime === undefined)
        return;
    var timeString = JSON.parse(currentTime);
    var checkTime = document.getElementById("checkTime");
    checkTime.innerText = timeString;
}

function refreshTableResult() {
    setInterval(function () {
        httpGetAsync("http://localhost:53823/SecurityDashboard/GetCurrentDashboardStatus", buildHtmlTable);
        httpGetAsync("http://localhost:53823/SecurityDashboard/GetCheckTime", updateCheckTime);
    }, 5000);
}