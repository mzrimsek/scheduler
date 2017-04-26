$( document ).ready(function() {
    //dates
    $('#datetimepicker1').datetimepicker({
        useCurrent: false,
        format: 'MM/DD/YYYY',
        daysOfWeekDisabled: [0, 6]
    });

    $('#datetimepicker2').datetimepicker({
        useCurrent: false,
        format: 'MM/DD/YYYY',
        daysOfWeekDisabled: [0, 6]
    });

    $("#datetimepicker1").on("dp.change", function (e) {
        $('#datetimepicker2').data("DateTimePicker").minDate(e.date);
        $('#datetimepicker3').data("DateTimePicker").clear();
        $('#datetimepicker4').data("DateTimePicker").clear()
    });
    
    $("#datetimepicker2").on("dp.change", function (e) {
        $('#datetimepicker1').data("DateTimePicker").maxDate(e.date);
        $('#datetimepicker3').data("DateTimePicker").clear();
        $('#datetimepicker4').data("DateTimePicker").clear()
    });

    //times
    $('#datetimepicker3').datetimepicker({
        format: 'HH:mm',
        useCurrent: false,
        minDate: moment({h:00, m:01}),
        maxDate: moment({h:23, m:45}),
        stepping: 15
    });

    $('#datetimepicker4').datetimepicker({
        format: 'HH:mm',
        useCurrent: false,
        minDate: moment({h:00, m:01}),
        maxDate: moment({h:23, m:45}),
        stepping: 15
    });

   $('#datetimepicker3').on("dp.change", function(e) {
       if($("#startDate").val() == $("#endDate").val())
       {
           $('#datetimepicker4').data("DateTimePicker").minDate(e.date);
       } else {
           $('#datetimepicker4').data("DateTimePicker").minDate(false);
       }
    });

    $('#datetimepicker4').on("dp.change", function(e) {
        if($("#startDate").val() == $("#endDate").val())
        {
            $('#datetimepicker3').data("DateTimePicker").maxDate(e.date);
        } else {
            $('#datetimepicker3').data("DateTimePicker").maxDate(false);
        }
    });

    

});
