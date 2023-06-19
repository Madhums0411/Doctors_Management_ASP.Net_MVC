$(document).ready(function () {
    ShowUserData();
});

function ShowUserData() {debugger
    $.ajax({
        url: '/Ajax/UserList',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, status, xhr) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.userID + '</td>';
                object += '<td>' + item.role_Id + '</td>';
                object += '<td>' + item.name + '</td>';
                object += '<td>' + item.password + '</td>';
                object += '<td>' + item.email_id + '</td>';
                object += '<td> <a href="#" class="btn btn-primary">Edit</a> ||<a href="#" class="btn btn-danger">Delete</a></td>'
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Data can't get");
        }


    });
};