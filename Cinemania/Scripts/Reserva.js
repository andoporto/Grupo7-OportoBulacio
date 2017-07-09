$(document).ready(function () {
    $("IdVersion").each(function () {
        $(this).val("");
    });

    $("#IdVersion").change(function () {

        $.get("/Peliculas/TraerListaSedes", { IdVersion: $("#IdVersion").val(), IdPelicula: $("#IdPelicula").val() }, function (data) {
            $("#IdSede").empty();
            var flag = 1;
            $.each(data, function (index, row) {
                if (flag == 1) {
                    $("#IdSede").append("<option value='" + 0 + "'>" + "Seleccione sede " + "</option>")
                    flag = 2;
                }
                $("#IdSede").append("<option value='" + row.IdSede + "'>" + row.Nombre + "</option>")

            });
        });
    });

    $("#IdSede").change(function () {

        $.get("/Peliculas/TraerListaDias", { IdVersion: $("#IdVersion").val(), IdPelicula: $("#IdPelicula").val(), IdSede: $("#IdSede").val() }, function (data) {
            var flag = 1;
            $("#DiasReservas").empty();
            $.each(data, function (index, row) {
                if (flag == 1) {
                    $("#DiasReservas").append("<option value='" + 0 + "'>" + "Seleccione día " + "</option>")
                    flag = 2;
                }
                $("#DiasReservas").append("<option value='" + row.value + "'>" + row.dias + "</option>")
            });
        });
    });

    $("#DiasReservas").change(function () {

        $.get("/Peliculas/TraerListaDias", { IdVersion: $("#IdVersion").val(), IdPelicula: $("#IdPelicula").val(), IdSede: $("#IdSede").val() }, function (data) {
            var flag = 1;
            $("#HorasReservas").empty();
            $.each(data, function (index, row) {
                if (flag == 1) {
                    $("#HorasReservas").append("<option value='" + 0 + "'>" + "Seleccione Hora " + "</option>")
                    flag = 2;
                }
                $("#HorasReservas").append("<option value='" + row.IdHora + "'>" + row.Hora + "</option>")
            });
        });
    });
});