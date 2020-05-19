
$(document).ready(function () {
    loadData();
});

function loadData() {
    $.ajax({
        url: "/Admin/Category/LoadData",
        type: "GET",
        dataType: "json",
        success: function (response) {
            if (response.status) {
                var data = response.data;
                var html = "";
                $.each(data, function (i, item) {
                    html += "<tr>";
                    html += "<td>" + item.Name + "</td>";
                    html += "<td>" + item.MetaTitle + "</td>";
                    html += "<td>" + item.Status + "</td>";
                    html += "<td><input type='button' class='btn btn-primary btn-edit' onclick='loadDetail(" + item.ID + ")' data-id ='" + item.ID + "' value='Edit' /> <input type='button' class='btn btn-danger btn-delete' onclick='deleteCategory(" + item.ID + ")' data-id='" + item.ID + "' value ='Delete' /></td > ";
                    html += "</tr>";
                });
                $("#tbl-category").html(html);
            }
            else {
                alert("Load failed.");
            }
        }
    });
}

function saveData() {
    var name = $("#txtName").val();
    var metaTitle = $("#txtMetaTitle").val();
    var status = $("#ckStatus").prop("checked");
    var id = parseInt($("#hidID").val());
    var category = {
        Name: name,
        MetaTitle: metaTitle,
        Status: status,
        ID: id
    }
    $.ajax({
        url: "/Admin/Category/SaveData",
        type: "POST",
        dataType: "json",
        data: { strCategory: JSON.stringify(category) },
        success: function (response) {
            if (response.status == true) {
                $("#modalAddUpdate").modal("hide");
                loadData();
            } else {
                bootbox.alert(response.message);
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function loadDetail(id) {
    $.ajax({
        url: "/Admin/Category/GetDetail",
        data: { id: id },
        type: "GET",
        dataType: "json",
        success: function (response) {
            if (response.status == true) {
                var data = response.data;
                $("#hidID").val(data.ID);
                $("#txtName").val(data.Name);
                $("#txtMetaTitle").val(data.MetaTitle);
                $("#ckStatus").prop("checked", data.Status);

                $("#modalAddUpdate").modal("show");
            } else {
                alert(response.message);
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function resetForm() {
    $("#hidID").val("0");
    $("#txtName").val("");
    $("#txtMetaTitle").val("");
    $("#ckStatus").prop("checked", true);
}

function deleteCategory(id) {
    var ans = confirm("Are you sure delete this records?")
    if (ans) {
        $.ajax({
            url: "/Admin/Category/Delete",
            data: { id: id },
            type: "POST",
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    alert("Delete success", function () {
                        categoryController.loadData();
                    });
                    loadData();
                }
                else {
                    alert(response.message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
}

/*var categoryController = {
    init: function () {
        categoryController.registerEvents();
        categoryController.loadData();
    },
    registerEvents: function () {
        $("#btnAddNew").off("click").on("click", function () {
            $("#modalAddUpdate").modal("show");
            categoryController.resetForm();
        });
        $(document).ready(function () {
            $(".btn-edit").off("click").on("click", function () {
                $("#modalAddUpdate").modal("show");
                var id = $(this).data("id");
                categoryController.loadDetail(id);
                categoryController.loadData();
            });
        });
        $(document).ready(function () {
            $(".btn-delete").off("click").on("click", function () {
                var id = $(this).data("id");
                categoryController.deleteCategory(id);
                categoryController.loadData();
            });
        });
        $("#btnSave").off("click").on("click", function () {
            categoryController.saveData();
            categoryController.loadData();
        });
    },
    loadDetail: function (id) {
        $.ajax({
            url: "/Admin/Category/GetDetail",
            data: { id: id },
            type: "GET",
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    var data = response.data;
                    $("#hidID").val(data.ID);
                    $("#txtName").val(data.Name);
                    $("#txtMetaTitle").val(data.MetaTitle);
                    $("#ckStatus").prop("checked", data.Status);
                } else {
                    alert(response.message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    },
    deleteCategory: function (id) {
        var ans = confirm("Are you sure delete this records?")
        if (ans) {
            $.ajax({
                url: "/Admin/Category/Delete",
                data: { id: id },
                type: "POST",
                dataType: "json",
                success: function (response) {
                    if (response.status == true) {
                        categoryController.loadData();
                    }
                    else {
                        alert(response.message);
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
    },
    saveData: function () {
        var name = $("#txtName").val();
        var metaTitle = $("#txtMetaTitle").val();
        var status = $("#ckStatus").prop("checked");
        var id = parseInt($("#hidID").val());
        var category = {
            Name: name,
            MetaTitle: metaTitle,
            Status: status,
            ID: id
        }
        $.ajax({
            url: "/Admin/Category/SaveData",
            type: "POST",
            dataType: "json",
            data: { strCategory: JSON.stringify(category) },
            success: function (response) {
                if (response.status == true) {
                    $("#modalAddUpdate").modal("hide");
                    categoryController.loadData();
                    bootbox.alert("Save success.");

                } else {
                    bootbox.alert(response.message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    },
    resetForm: function () {
        $("#hidID").val("0");
        $("#txtName").val("");
        $("#txtMetaTitle").val("");
        $("#ckStatus").prop("checked", true);
    },
    loadData: function () {
        $.ajax({
            url: "/Admin/Category/LoadData",
            type: "GET",
            dataType: "json",
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = "";
                    $.each(data, function (i, item) {
                        html += "<tr>";
                        html += "<td>" + item.Name + "</td>";
                        html += "<td>" + item.MetaTitle + "</td>";
                        html += "<td>" + item.Status + "</td>";
                        html += "<td><input type='button' class='btn btn-primary btn-edit' data-id ='" + item.ID + "' value='Edit' /> <input type='button' class='btn btn-danger btn-delete' data-id='" + item.ID + "' value ='Delete' /></td > ";
                        html += "</tr>";
                    });
                    $("#tbl-category").html(html);
                }
                else {
                    alert("Load failed.");
                }
            }
        });
    }
}
categoryController.init();*/