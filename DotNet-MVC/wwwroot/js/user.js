var dataTable;

$(document).ready(function () {
    loadDataTable()
});

function loadDataTable() {
    dataTable = $('#tblUser').DataTable({
        "ajax": {
            "url": "/Admin/User/GetAll"
        },
        "columns": [
            {"data": "name", width: "15%"},
            {"data": "email", width: "15%"},
            {"data": "phoneNumber", width: "15%"},
            {"data": "company.name", width: "15%"},
            {"data": "role", width: "15%"},
            {
                "data": {
                    id: "id",
                    lockoutEnd: "lockoutEnd"
                }, "render": function (data) {
                    var today = new Date().toLocaleString();
                    var lockout = new Date(data.lockoutEnd).toLocaleString();


                    console.log(today);
                    console.log(lockout);
                    console.log("===========");

                    if (lockout > today) {
                        return `
                        <div class="text-center">
                            <a onclick="Restriction('${data.id}', '/Admin/User/UnrestrictUser')" class="btn btn-success text-white" style="cursor: pointer; font-weight: bold">
                                <i class="fas fa-lock-open"></i> &nbsp; Unlock 
                            </a>
                        </div>
                        `;
                    } else {
                        return `
                        <div class="text-center">
                            <a onclick="Restriction('${data.id}', '/Admin/User/RestrictUser')" class="btn btn-danger text-white" style="cursor: pointer; font-weight: bold">
                                <i class="fas fa-lock"></i> &nbsp; Lock 
                            </a>
                        </div>
                        `;
                    }
                }, width: "40%"
            }
        ]
    });
}

function Restriction(userId, action) {
    $.ajax({
        type: "POST",
        url: action,
        data: JSON.stringify(userId),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                Swal.fire(
                    {
                        icon: 'success',
                        title: data.message,
                        showConfirmButton: false,
                        timer: 750
                    }
                )
                dataTable.ajax.reload();
            } else {
                Swal.fire(
                    data.message,
                    'error'
                )
            }
        }
    })
}


function Delete(url) {
    Swal.fire({
        title: 'Are you sure you want to Delete it?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        Swal.fire(
                            data.message,
                            'Your file has been deleted.',
                            'success'
                        )
                        dataTable.ajax.reload();
                    } else {
                        Swal.fire(
                            data.message,
                            'error'
                        )
                    }
                }
            })

        }
    })
}