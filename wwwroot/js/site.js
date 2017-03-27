// Write your Javascript code.
$(function()
{
    $(document).on('click', '.btn-add', function(e)
    {
        e.preventDefault();

        var controlForm = $('.controls form:first'),
            currentEntry = $(this).parents('.entry:first'),
            newEntry = $(currentEntry.clone()).appendTo(controlForm);

        newEntry.find('input').val('');
        controlForm.find('.entry:not(:last) .btn-add')
            .removeClass('btn-add').addClass('btn-remove')
            .removeClass('btn-success').addClass('btn-danger')
            .html('<span class="glyphicon glyphicon-minus"></span>');
    }).on('click', '.btn-remove', function(e)
    {
		$(this).parents('.entry:first').remove();

		e.preventDefault();
		return false;
	});
});

$(function () {
    $('#datetimepicker1').datetimepicker({
        format: 'DD/MM/YYYY'
    });
    $('#datetimepicker2').datetimepicker({
        useCurrent: false, //Important! See issue #1075
        format: 'DD/MM/YYYY'
    });
    $("#datetimepicker1").on("dp.change", function (e) {
        $('#datetimepicker2').data("DateTimePicker").minDate(e.date);
    });
    $("#datetimepicker2").on("dp.change", function (e) {
        $('#datetimepicker1').data("DateTimePicker").maxDate(e.date);
    });
});

$(function () {
    $('#datetimepicker3').datetimepicker({
        format: 'LT'
    });
    $('#datetimepicker4').datetimepicker({
        useCurrent: false,
        format: 'LT'
    });
    $('#datetimepicker3').on("dp.change", function(e) {
        $('datetimepicker4').data("DateTimePicker").minDate(e.date);
    });
    $('#datetimepicker4').on("dp.change", function(e) {
        $('datetimepicker3').data("DateTimePicker").maxDate(e.date);
    });
});
