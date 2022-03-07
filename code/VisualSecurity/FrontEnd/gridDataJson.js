$.getJSON('https://localhost:5001/api/GetGridData', function (data) {

    var column3 = "";
    var column5 = "";
    var column15 = "";
    var columnOther = "";

    $.each(data.result, function (key, value) {

        var rowData = "<tr><td>" + value.securityCamera.id + "</td><td>" + value.securityCamera.camera + "</td><td>" + value.securityCamera.latitude + "</td><td>" + value.securityCamera.longitude + "</td></tr>";

        if (value.gridNumber === 1)
            column3 += rowData;

        if (value.gridNumber === 2)
            column5 += rowData;

        if (value.gridNumber === 3)
            column15 += rowData;

        if (value.gridNumber === 4)
            columnOther += rowData;

    })

    $("#column3").append(column3);
    $("#column5").append(column5);
    $("#column15").append(column15);
    $("#columnOther").append(columnOther);
});
