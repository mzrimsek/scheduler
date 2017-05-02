var handleDateFields = function(id) {
    var dateInput = $("#" + id);
    var dateLabel = $("label[for='" + id + "']");

    if(dateInput.val()) {
        document.getElementById(id).type = "date";
    }

    dateInput.on("focus", () => {
        document.getElementById(id).type = "date";
        dateLabel.hide();
    });

    dateInput.on("focusout", () => {
        if(!dateInput.val()) {
            document.getElementById(id).type = "text";
            dateLabel.show();
        }
    });
}

var handleTimeFields = function(id) {
    var timeInput = $("#" + id);
    var timeLabel = $("label[for='" + id + "']");

    if(timeInput.val()) {
        document.getElementById(id).type = "time";
    }

    timeInput.on("focus", () => {
        document.getElementById(id).type = "time";
        timeLabel.hide();
    });

    timeInput.on("focusout", () => {
        if(!timeInput.val()) {
            document.getElementById(id).type = "text";
            timeLabel.show();
        }
    });
}

$(document).ready(function() {
    handleDateFields("startDate");
    handleDateFields("endDate");
    handleTimeFields("startTime");
    handleTimeFields("endTime");
});