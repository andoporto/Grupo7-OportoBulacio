$(document).ready(function () {
    $('input[type=datetime]').datepicker({
        dateformat: "dd/md/yy",
        changeMonth: true,
        changeYear: true,
        yearRange: "-60:+0"

    });

});