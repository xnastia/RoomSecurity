var alarmReport = new function(){
    var self = this;
    self.Id = "";
    self.page = 1;
    self.statusesOnPage = 4;
    
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
        self.buildPaginationMenu(roomId);
        getPagesNumber(roomId);
    }
    
    self.hideAlarmReportOnCloseBtnClick = function() {
        self.alarmReport.style.display = "none";
        self.blockPanel.style.display = "none";
        $(".pagination").empty();
        self.page = 1;
        event.stopPropagation();
    }

    function onPageClick(pageName) {
        switch (pageName) {
            case "first-page":
                self.page = 1;
                break;
            case "previous-page":
                self.page -= 1;
                break;
            case "next-page":
                self.page += 1;
                break;
            case "last-page":
                self.page = self.pagesNumber;
                break;
        }

        document.getElementById("alarm-status-pagination").innerHTML = "";
        self.buildPaginationMenu();
        refreshSelectedRoomAlarmStatus(self.roomId, self.page);
    }

    self.buildPaginationMenu = function () {
        $(".pagination").empty();
        var createLink = (name, id) => {
            return $("<a />", {
                id: id,
                name: "link",
                href: "#",
                text: name,
                click: () => onPageClick(id)
            });
        };

        if (self.page > 1) {
            $("#alarm-status-pagination").append(createLink("<<", "first-page"));
            $("#alarm-status-pagination").append(createLink(self.page - 1, "previous-page"));
        }
           
        $("#alarm-status-pagination").append($("<div/>", {"class" : "active", text : self.page}));
        if (self.pagesNumber > 1 && self.page < self.pagesNumber)
            $("#alarm-status-pagination").append(createLink(self.page + 1, "next-page"));
        if (self.pagesNumber > 2 && self.page < self.pagesNumber)
            $("#alarm-status-pagination").append(createLink(">>", "last-page"));
    }

    
    /*function refreshSelectedRoomAlarmReport(roomId) {
        setInterval(function () {
            refreshSelectedRoomAlarmStatus(roomId);
        }, 7000);
    }*/
    function countPagesNumber(number) {
        self.pagesNumber = Math.ceil(number / self.statusesOnPage);
        self.buildPaginationMenu(self.roomId);
    }

    function getPagesNumber(roomId) {
        httpGetAsync("api/dashboard/GetAlarmStatusesNumber?roomId=" + roomId, countPagesNumber);
    }
    
    function refreshSelectedRoomAlarmStatus(roomId, page) {
        httpGetAsync("api/dashboard/GetAlarmStatusHistory?roomId=" + roomId + "&page=" + page, updateStatus);
    }

    function updateStatus(jsonData) {
        buildTable(jsonData, "alarm-report-table");
    }

    return self;
}