var alarmReport = new function(){
    var self = this;

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
    self.showAlarmReport = function () {
        self.alarmReport.style.display = "block";
        self.blockPanel.style.display = "block";
    }

    self.hideAlarmReportOnCloseBtnClick = function() {
        self.alarmReport.style.display = "none";
        self.blockPanel.style.display = "none";
        event.stopPropagation();
    }
    return self;
}