function createScrollMenuButtonsHtml(jsonData) {
    var monitors = JSON.parse(jsonData);
    var scrollMenuButtonsHtml = "";
    for (var i = 0; i < monitors.length; i++) {
        var monitor = monitors[i];
        var monitorName = monitor["Name"];
        var monitorId = monitor["Id"];
        scrollMenuButtonsHtml += "<a href='#' id=" +
            "'" + monitorId + "'" +
            "onclick=\"onBtnClick(this, " +
            "'" + monitorId + "'" +
            ")\">" +
            monitorName +
            "</a> ";
    }
    var floors = document.getElementById("floor");
    floors.innerHTML = scrollMenuButtonsHtml;;
}

function getScrollMenuButtonsHtml() {
    httpGetAsync("api/dashboard/GetMonitors", createScrollMenuButtonsHtml);
}

function renderScrollMenuButtons() {
    var floors = document.getElementById("floor");
    floors.innerHTML = getScrollMenuButtonsHtml();
}