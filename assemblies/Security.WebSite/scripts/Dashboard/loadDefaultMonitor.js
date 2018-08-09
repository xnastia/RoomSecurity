﻿function loadDefaultMonitor(defaultMonitorBtnId, value) {
    var scannerEnabled = checkIsScannerEnabled();
    var buttons = document.getElementById('floor').children;
    for (let i = 0; i < buttons.length; i++) {
        if (buttons[i].classList.contains('btnActive')) {
            return;
        }
    }
    if (!scannerEnabled) {
        var anchor = document.getElementById(defaultMonitorBtnId);
        onBtnClick(anchor, value);
    }
}