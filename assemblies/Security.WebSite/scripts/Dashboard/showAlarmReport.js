var alarmReport = new function(){
    var self = this;
    self.Id = "";
    self.page = 1;
    
    self.init = function() {
        self.blockPanel = document.getElementById("block-panel");
        self.alarmReport = document.getElementById("alarm-report");
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
        refreshSelectedRoomAlarmStatus(self.roomId, self.page);
    }
    
    self.hideAlarmReportOnCloseBtnClick = function() {
        self.alarmReport.style.display = "none";
        self.blockPanel.style.display = "none";
        event.stopPropagation();
    }

    function onPageClick(pageName) {
        if (pageName === "<<")
            self.page = 1;
        else self.page = pageName;
        document.getElementById("alarm-status-pagination").innerHTML = "";
        self.buldPaginationMenu();
        refreshSelectedRoomAlarmStatus(self.roomId, self.page);
    }

    self.buldPaginationMenu = function () {
        var prevPage = parseInt(self.page) - 1;
        var nextPage = parseInt(self.page) + 1;
        var createLink = (name, id) => {
            return $("<a />", {
                id: id,
                name: "link",
                href: "#",
                text: name,
                click: () => onPageClick(name)
            });
        };

        $("#alarm-status-pagination").append(createLink("<<", "first-page"));
        if (self.page > 1)
            $("#alarm-status-pagination").append(createLink(prevPage, "previous-page"));
        $("#alarm-status-pagination").append(createLink(self.page, "current-page"));
        $("#alarm-status-pagination").append(createLink(nextPage, "next-page"));
        $("#alarm-status-pagination").append(createLink(">>", "last-page"));
        document.getElementById("current-page").classList.add("active");
    }

    
    /*function refreshSelectedRoomAlarmReport(roomId) {
        setInterval(function () {
            refreshSelectedRoomAlarmStatus(roomId);
        }, 7000);
    }*/
    
    function refreshSelectedRoomAlarmStatus(roomId, page) {
        httpGetAsync("api/dashboard/GetAlarmStatusHistory?roomId=" + roomId + "&page=" + page, updateStatus);
    }

    function updateStatus(jsonData) {
        buildTable(jsonData, "alarm-report-table");
    }

    return self;
}