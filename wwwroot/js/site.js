// Write your Javascript code.
$(function () {
    $('#datetimepicker1').datetimepicker({
        format: 'MM/DD/YYYY',
        daysOfWeekDisabled: [0, 6]
    });
    $('#datetimepicker2').datetimepicker({
        useCurrent: false, //Important! See issue #1075
        format: 'MM/DD/YYYY',
        daysOfWeekDisabled: [0, 6]
    });
    $("#datetimepicker1").on("dp.change", function (e) {
        $('#datetimepicker2').data("DateTimePicker").minDate(e.date);
    });
    $("#datetimepicker2").on("dp.change", function (e) {
        $('#datetimepicker1').data("DateTimePicker").maxDate(e.date);
    });
});

$(function () {
    var $startTime1 = $('#datetimepicker3');
    var $endTime1 = $('#datetimepicker4');

    $startTime1.datetimepicker({
        format: 'HH:mm',
        useCurrent: false,
        minDate: moment({h:08, m:01}),
        maxDate: moment({h:18, m:01}),
        stepping: 15
    });

    $endTime1.datetimepicker({
        format: 'HH:mm',
        minDate: moment({h:08, m:01}),
        maxDate: moment({h:18, m:01}),
        stepping: 15
    });

   $startTime1.on("dp.change", function(e) {
        $endTime1.data("DateTimePicker").minDate(e.date);
    });

    $endTime1.on("dp.change", function(e) {
        $startTime1.data("DateTimePicker").maxDate(e.date);
    });

    $endTime1.on("dp.show", function(e) {
        if (!$endTime1.data("DateTimePicker").maxDate(e.date)) {
            var defaultDate = $startTime1.data("DateTimePicker").date().add(15, 'minutes');
        }
    });
});
