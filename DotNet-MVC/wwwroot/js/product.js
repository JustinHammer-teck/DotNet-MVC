var dataTable;

$(document).ready(function () {
    loadDataTable()
});

function loadDataTable() {
    dataTable = $('#tblProduct').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            {"data": "title", width: "15%"},
            {"data": "isbn", width: "15%"},
            {"data": "price", width: "15%"},
            {"data": "author", width: "15%"},
            {"data": "category.name", width: "15%"},
            {
                "data": "id", "render": function (data) {
                    return `
                <div class="text-center">
                    <a href="/Admin/Product/Upsert/${data}" class="btn btn-success text-white" style="cursor: pointer; font-weight: bold">
                        <i class="fas fa-edit"></i> &nbsp;
                    </a>
                    <a onclick="Delete('/Admin/Product/Delete/${data}')" class="btn btn-danger text-white" style="cursor: pointer; font-weight: bold">
                        <i class="fas fa-trash-alt"></i> &nbsp;
                    </a>
                </div>
                `;
                }, width: "15%"
            }
        ]
    });
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