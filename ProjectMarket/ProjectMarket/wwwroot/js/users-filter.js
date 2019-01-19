function filterUsers() {
    var filter = {};
    var userName = $('#UserName').val();
    if (typeof userName !== 'undefined' && userName != "") {
        filter.userName = userName;
    }
    var firstName = $('#FirstName').val();
    if (typeof firstName !== 'undefined' && firstName != "") {
        filter.firstName = firstName;
    }
    var lastName = $('#LastName').val();
    if (typeof lastName !== 'undefined' && lastName != "") {
        filter.lastName = lastName;
    }
    var includeDeleted = $('#IncludeDeleted').val();
    if (typeof includeDeleted !== 'undefined' && includeDeleted != "") {
        filter.includeDeleted = includeDeleted;
    }

    $.ajax({
        type: "GET",
        url: '/Users/Filter',
        data: filter,
        success: function (data) {
            $('#Users').empty();
            for (i in data) {
                var item = data[i];
                var userNameHtml = `<td>${item.userName}</td>`;
                var fullNameHtml = `<td>${item.fullName}</td>`;
                var emailHtml = `<td><a href="mailto:${item.eMail}">${item.eMail} </a></td>`;
                var isChecked = item.isAdmin ? "checked =\"checked\"" : "";
                var isAdminHtml = `<td><input ${isChecked} class="check-box" disabled="disabled" type="checkbox" /></td>`;
                var linksHtml = `<td><a href="/Users/Edit/${item.id}">Edit</a> | <a href="/Users/Details/${item.id}">Details</a> | <a href="/Users/Delete/${item.id}">Delete</a></td>`
                var delMsgHtml = "<td><b>משתמש מחוק</b></td>";
                var extraDetailsHtml = item.isDeleted ? delMsgHtml : linksHtml;
                var userRow = `<tr> ${userNameHtml} ${fullNameHtml} ${emailHtml} ${isAdminHtml} ${extraDetailsHtml}</tr>`;
                $('#Users').append(userRow);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
        }
    });
}

$(document).ready(function () {
    $("#users-filter").click(filterUsers);
}
);