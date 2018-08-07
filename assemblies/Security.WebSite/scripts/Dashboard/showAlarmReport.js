function switchAlarmReport() {
    var alarmerReport = document.getElementById("alarmerReport");
    var alarmerReportClassList = alarmerReport.classList;
    if (alarmerReportClassList.contains("alarmReportHide")) {
        alarmerReportClassList.remove("alarmReportHide");
        alarmerReportClassList.add("alarmReport");
        
 } else {
        alarmerReportClassList.remove("alarmReport");
        alarmerReportClassList.remove("alarmReportBackground");
        alarmerReportClassList.add("alarmReportHide");
    }
}
