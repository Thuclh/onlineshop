$(document).ready(function () {
    loadData();
});

var productCategoryConfig = {
    pageSize: 5,
    pageIndex: 1
}

function loadData() {
    $.ajax({
        url: "/Admin/ProductCategory/LoadData",
        type: "GET",
        data: {
            page: productCategoryConfig.pageIndex,
            pageSize: productCategoryConfig.pageSize
        },
        dataType: "json",
        success: function (response) {
            if (response.status) {
                var data = response.data;
                var html = "";
                $.each(data, function (i, item) {
                    html += "<tr>";
                    html += "<td>" + item.Name + "</td>";
                    html += "<td>" + item.MetaTitle + "</td>";
                    html += "<td>" + item.CreatedBy + "</td>";
                    html += "<td>" + item.Status + "</td>";
                    html += "<td><button class='btn btn-primary' onclick='getDetail(" + item.ID + ")'><i class='glyphicon glyphicon-pencil'></i> </button>"
                        + " <button class='btn btn-danger' onclick='deleteProductCategory(" + item.ID + ")'><i class='glyphicon glyphicon-trash'></i></button>"
                        + "</td >";
                    html += "</tr>";
                });
                $("#tbl-productcategory").html(html);
                paging(response.total, function () {
                    loadData();
                });
            } else {
                alert("Load failed.");
            }
        }
    });
}

function getDetail(id) {
    $.ajax({
        url: "/Admin/ProductCategory/GetDetail",
        type: "GET",
        data: { id: id },
        dataType: "json",
        success: function (response) {
            if (response.status == true) {
                var data = response.data;
                $("#hidID").val(data.ID);
                $("#txtName").val(data.Name);
                $("#txtMetaTitle").val(data.MetaTitle);
                $("#txtCreatedBy").val(data.CreatedBy);
                $("#ckStatus").prop("checked", data.Status);

                $("#modalAddUpdate").modal("show");
            }
            else {
                alert("Load detail failed.");
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function createUpdate() {
    var name = $("#txtName").val();
    var metaTitle = $("#txtMetaTitle").val();
    var createdBy = $("#txtCreatedBy").val();
    var status = $("#ckStatus").prop("checked");
    var id = parseInt($("#hidID").val());
    var productCategory = {
        Name: name,
        MetaTitle: metaTitle,
        CreatedBy: createdBy,
        Status: status,
        ID: id
    }
    $.ajax({
        url: "/Admin/ProductCategory/CreateUpdate",
        type: "POST",
        dateType: "json",
        data: { strProductCategory: JSON.stringify(productCategory) },
        success: function (response) {
            if (response.status == true) {
                $("#modalAddUpdate").modal("hide");
                loadData();
            } else {
                alert("Update failed.");
            }
        },
        error: function () {

        }
    });
}

function resetForm() {
    $("#hidID").val("0");
    $("#txtName").val("");
    $("#txtMetaTitle").val("");
    $("#txtCreatedBy").val("");
    $("#ckStatus").prop("checked", true);
}

function deleteProductCategory(id) {
    var ans = confirm("Are you sure delete this record?");
    if (ans) {
        $.ajax({
            url: "/Admin/ProductCategory/Delete",
            type: "POST",
            data: { id: id },
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    alert("Delete success.");
                }
                else {
                    alert(response.message);
                }
                loadData();
            }
        })
    }
}

function paging(totalRow, callback) {
    var totalPage = Math.ceil(totalRow / productCategoryConfig.pageSize);
    $('#pagination').twbsPagination({
        totalPages: totalPage,
        first: "Đầu",
        next: "Tiếp",
        last: "Cuối",
        prev: "Trước",
        visiblePages: 7,
        onPageClick: function (event, page) {
            productCategoryConfig.pageIndex = page;
            setTimeout(callback, 200);
            loadData();
        }
    });
}
