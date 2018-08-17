function TriggerCurrentMonitor() {
    var anchor = document.getElementById(dashboard.currentMonitorId.toLowerCase());
    selectFloorButtonClick(anchor, dashboard.currentMonitorId);
}