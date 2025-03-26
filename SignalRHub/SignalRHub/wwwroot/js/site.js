$(() => {
    LoadProdData();

    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();

    connection.on("LoadProducts", function () {
        LoadProdData();
    });

    LoadProdData();

    function LoadProdData() {
        var tr = '';
        $.ajax({
            url: '/Products',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr += '<tr>' +
                        '<td>' + v.productName + '</td>' +
                        '<td>' + v.category + '</td>' +
                        '<td>' + v.unitPrice + '</td>' +
                        '<td>' + v.stockQuantity + '</td>' +
                        '<td>' +
                        '<a href="../Products/Edit?id=' + v.Id + '">Edit</a> | ' +
                        '<a href="../Products/Details?id=' + v.Id + '">Details</a> | ' +
                        '<a href="../Products/Delete?id=' + v.Id + '">Delete</a>' +
                        '</td>' +
                        '</tr>';
                });
                $("#tableBody").html(tr);
            },
            error: (error) => {
                console.log(error);
            }
        });
    }
});