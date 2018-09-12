function createScrollMenuButtonsHtml(jsonData) {
    var monitors = JSON.parse(jsonData);
    if (monitors === undefined || monitors === null || monitors.length === 0)
        return;
    
    var scrollMenuButtonsHtml = "";
    for (var i = 0; i < monitors.length; i++) {
        var monitor = monitors[i];
        var monitorName = monitor["Name"];
        var monitorId = monitor["Id"];
        var btnClass = "btnDefault";
        if (i === 0) {
            btnClass = "btnActive";
            dashboard.currentMonitorId = monitors[0]["Id"];
        }
        scrollMenuButtonsHtml += "<a href='#' id=" +
            "'" + monitorId + "' class='" + btnClass + "' " +
            "onclick=\"selectFloorButtonClick(this, " +
            "'" + monitorId + "'" +
            ")\">" +
            monitorName +
            "</a> ";
    }
    var floors = document.getElementById("floor");
    floors.innerHTML = scrollMenuButtonsHtml;
}

function getScrollMenuButtonsHtml() {
    httpGetAsync("api/dashboard/GetMonitors",  createScrollMenuButtonsHtml);
}

