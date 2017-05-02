var handleDateTimeField = function(id, inputType) {
    let input = $("#" + id);
    let label = $("label[for='" + id + "']");

    if(input.val()) {
        document.getElementById(id).type = inputType;
    }

    input.on("focus", () => {
        document.getElementById(id).type = inputType;
        label.hide();
    });

    input.on("focusout", () => {
        if(!input.val()) {
            document.getElementById(id).type = "text";
            label.show();
        }
    });
}

var initializeDateFields = function(startId, endId) {
    let startDate = $("#" + startId);
    let endDate = $("#" + endId);

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
    let endDate = $("#" + endId);

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

var syncTimeFields = function(startId, endId) {
    let startTime = $("#" + startId);
    let endTime = $("#" + endId);

    startTime.on("change", () => {
        let startTimeVal = startTime.val();
        if(startTimeVal > endTime.val()) {
            endTime.val(startTimeVal);
        }
    })

    endTime.on("change", () => {
        let endTimeVal = endTime.val();
        if(endTimeVal < startTime.val()) {
            startTime.val(endTimeVal);
        }
    });
}

$(document).ready(function() {
    let startDateId = "startDate";
    let startTimeId = "startTime";
    let endDateId = "endDate";
    let endTimeId = "endTime";

    handleDateTimeField(startDateId, "date");
    handleDateTimeField(endDateId, "date");
    initializeDateFields(startDateId, endDateId);
    syncDateFields(startDateId, endDateId);

    handleDateTimeField(startTimeId, "time");
    handleDateTimeField(endTimeId, "time");

    let shouldRestrictTimes = $("#" + startDateId).val() == $("#" + endDateId).val();
    if(shouldRestrictTimes) {
        syncTimeFields(startTimeId, endTimeId);
    }
});