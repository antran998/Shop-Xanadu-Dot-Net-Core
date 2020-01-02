$(document).ready(function() {
    $('#myTable').DataTable();
    $(document).ready(function() {
        var table = $('#example').DataTable({
            "columnDefs": [{
                "visible": false,
                "targets": 2
            }],
            "order": [
                [2, 'asc']
            ],
            "displayLength": 25,
            "drawCallback": function(settings) {
                var api = this.api();
                var rows = api.rows({
                    page: 'current'
                }).nodes();
                var last = null;
                api.column(2, {
                    page: 'current'
                }).data().each(function(group, i) {
                    if (last !== group) {
                        $(rows).eq(i).before('<tr class="group"><td colspan="5">' + group + '</td></tr>');
                        last = group;
                    }
                });
            }
        });
        // Order by the grouping
        $('#example tbody').on('click', 'tr.group', function() {
            var currentOrder = table.order()[0];
            if (currentOrder[0] === 2 && currentOrder[1] === 'asc') {
                table.order([2, 'desc']).draw();
            } else {
                table.order([2, 'asc']).draw();
            }
        });
    });
});

var typeId = window.location.pathname.split("/");
typeId = typeId[2];

$('.product-table').DataTable({    
    dom: 'Bfrtip',
    buttons: [
        'copy', 'csv', 'excel', 'pdf', 'print'
    ],
    "processing": true,
    "serverSide": true,
    "ajax": {
        "url": "/LoadData",
        "type": "POST",
        "datatype": "json",
        "data": {
            "CateId": typeId
        }
    },
    "columns": [
        { "data": "productId","class":"product-id-row"},
        {
            "data": null,
            "render": function (data, type, row) {
                return '<img class="img-row" src="../assets/images/items/'+data.image+'" alt="Hình sản phẩm" />'
            },
        },
        { "data": "productName"},
        { "data": "price"},
        { "data": "discountPrice"},            
        { "data": "describe"},
        {
            "data": null,
            "render": function (data, type, row) {
                return '<button class="btn btn-info btn-rounded edit-button" onclick="UpdateProduct(this);" data-toggle="modal" data-target="#EditModal">Edit</button><button onclick="DeleteProduct(this);" class="btn btn-danger btn-rounded delete-btn">Delete</button>';
            }
        }
    ],
    "initComplete": function (settings, json) {
        var updated = window.location.href.search("updated=");
        if (updated != -1) {
            var updateId = window.location.href.substring(updated + 8, window.location.href.length);
            var updatedRow = $(".product-id-row:contains(" + updateId + ")").parent();
            var rowScroll = $(updatedRow).offset().top - 100;
            $(updatedRow).hide();
            history.pushState(null, null, window.location.pathname);
            Swal.fire({
                type: 'success',
                text: "Success",
                customClass: {
                    confirmButton: 'update-success-confirm'
                },
                onAfterClose: () => {
                    $('html, body').animate({
                        scrollTop: rowScroll
                    }, 1000);
                    setTimeout(function () {
                        $(updatedRow).addClass("animated flipInX");                            
                        $(updatedRow).show();                                   
                    }, 1100)                        
                }
            })
        }
    }
});

////////////////////////////////////// user
var roleId = window.location.pathname.split("/");
roleId = roleId[2];

$('.user-table').DataTable({
    dom: 'Bfrtip',
    buttons: [
        'copy', 'csv', 'excel', 'pdf', 'print'
    ],
    "processing": true,
    "serverSide": true,
    "ajax": {
        "url": "/LoadUserData",
        "type": "POST",
        "datatype": "json",
        "data": {
            "roleId": roleId
        }
    },
    "columns": [
        { "data": "id", "class": "user-id-row id-row" },
        { "data": "fullname" },
        { "data": "email" },        
        { "data": "address" },
        { "data": "phoneNumber" },
        { "data": "moneySpended" },
        {
            "data": null,
            "render": function (data, type, row) {
                return '<button class="btn btn-info btn-rounded edit-user-button" onclick="UpdateUser(this);" data-toggle="modal" data-target="#EditModal">Edit</button><button onclick="DeleteUser(this);" class="btn btn-danger btn-rounded delete-user-btn">Delete</button>';
            }
        }
    ],
    "initComplete": function (settings, json) {
        var updated = window.location.href.search("updated=");
        if (updated != -1) {
            var updateId = window.location.href.substring(updated + 8, window.location.href.length);
            var updatedRow = $(".user-id-row:contains(" + updateId + ")").parent();
            var rowScroll = $(updatedRow).offset().top - 100;
            $(updatedRow).hide();
            history.pushState(null, null, window.location.pathname);
            Swal.fire({
                type: 'success',
                text: "Success",
                customClass: {
                    confirmButton: 'update-success-confirm'
                },
                onAfterClose: () => {
                    $('html, body').animate({
                        scrollTop: rowScroll
                    }, 1000);
                    setTimeout(function () {
                        $(updatedRow).addClass("animated flipInX");
                        $(updatedRow).show();
                    }, 1100)
                }
            })
        }
    }
});

////////////////////////////////////// Bill
$('.bill-table').DataTable({
    dom: 'Bfrtip',
    buttons: [
        'copy', 'csv', 'excel', 'pdf', 'print'
    ],
    "processing": true,
    "serverSide": true,
    "ajax": {
        "url": "/LoadBillData",
        "type": "POST",
        "datatype": "json"
    },
    "columns": [
        { "data": "billId", "class": "bill-id-row id-row" },
        { "data": "customerName" },
        { "data": "customerEmail" },
        { "data": "customerAddress" },
        { "data": "customerPhone" },
        { "data": "createDate" },        
        {
            "data": "status",
            "render": function (data, type, row) {
                if (data == "FAIL") return '<span class="badge badge-danger">'+data+'</span>';
                else return '<span class="badge badge-success">'+data+'</span>';            
            }
        },
        { "data": "accountId" },
    ],
    'createdRow': function (row, data, dataIndex) {
        $(row).attr('onclick', 'ShowBillDetail(this)');
    }
});

function ShowBillDetail(obj) {    
    Swal.fire({
        text: " ",
        showConfirmButton: false,
        customClass: {
            popup: 'hide-popup'
        },
        onOpen: () => {
            $('#swal2-content').load('/GetBillDetail/' + $(obj).find('td:first-child').html());
        }
    })
}
