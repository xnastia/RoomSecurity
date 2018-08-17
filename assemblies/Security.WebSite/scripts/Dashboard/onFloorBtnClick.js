﻿function selectFloorButtonClick(element, value) {
    dashboard.currentMonitorId = value;
    var buttons = document.getElementById('floor').children;
    for (let i = 0; i < buttons.length; i++) {
        buttons[i].classList.remove('btnActive');
    }
    document.getElementById('floor').value = value.toLowerCase();
    element.classList.add('btnActive');
    refreshSelectedFloorStatus();
}