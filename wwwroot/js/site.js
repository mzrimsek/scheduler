var handleDateFields = function(id) {
    let dateInput = $("#" + id);
    let dateLabel = $("label[for='" + id + "']");

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

var initializeDateFields = function(startId, endId) {
    let startDate = $("#" + startId);
    let endDate= $("#" + endId);

    let startDateVal = startDate.val();
    if(startDateVal) {
        endDate.attr("min", startDateVal);
    }

    let endDateVal = endDate.val();
    if(endDateVal) {
        startDate.attr("max", endDateVal);
    }
}

var syncDateFields = function(startId, endId) {
    let startDate = $("#" + startId);
    let endDate= $("#" + endId);

    startDate.on("change", () => {
        let startDateVal = startDate.val();
        if(startDateVal) {
            endDate.attr("min", startDateVal);
        } else {
            endDate.attr("min", "");
        }

        if(startDateVal > endDate.val()) {
            endDate.val(startDateVal);
        }
    })

    endDate.on("change", () => {
        let endDateVal = endDate.val();
        if(endDateVal) {
            startDate.attr("max", endDateVal);
        } else {
            startDate.attr("max", "");
        }

        if(endDateVal < startDate.val()) {
            startDate.val(endDateVal);
        }
    });
}

var handleTimeFields = function(id) {
    let timeInput = $("#" + id);
    let timeLabel = $("label[for='" + id + "']");

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
    let startDateId = "startDate";
    let startTimeId = "startTime";
    let endDateId = "endDate";
    let endTimeId = "endTime";

    handleDateFields(startDateId);
    handleDateFields(endDateId);

    initializeDateFields(startDateId, endDateId);
    syncDateFields(startDateId, endDateId);

    handleTimeFields(startTimeId);
    handleTimeFields(endTimeId);
});