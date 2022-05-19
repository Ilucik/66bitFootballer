
$(() => {
    LoadProdData();
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();
    connection.on("LoadProducts", function () {
        LoadProdData();
    })

    LoadProdData();

    function LoadProdData() {
        var tr = '';

        $.ajax({
            url: '/FootballersList/GetFootballers',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr += `<tr>
                        <td>${v.Name}</td>
                        <td>${v.Surname}</td>
                        <td>${v.Gender}</td>
                        <td>${v.Birthday}</td>
                        <td>${v.TeamId}</td>
                        <td>${v.Country}</td>
                        <td>
                        <a class='btn btn-primary btn-sm' href='../FootballersList/Edit/${v.Id}'>Edit</a>
                        <a class='btn btn-danger btn-sm' href='../FootballersList/Delete/${v.Id}'>Delete</a>
                        </td>
                    </tr>`
                })

                $("#tableBody").html(tr);
            },
            error: (error) => {
                console.log(error)
            }
        })

    }

})
