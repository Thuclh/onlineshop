var productCategory = {
    init: function() {
        productCategory.registerEvents();
    },
    registerEvents: function () {
        //$(".btn-active").off("click").on("click", function (e) {
        //    e.preventDefault();
        //    var btn = $(this);
        //    var productid = btn.data("proid");
        //    $.ajax({
        //        url: "/Admin/ProductCategory/ChangeStatus",
        //        dataType: "json",
        //        type: "POST",
        //        data: { id: productid },
        //        success: function (response) {
        //            if (response.status == true) {
        //                btn.text("Kích hoạt");
        //            } else {
        //                btn.text("Khóa");
        //            }
        //        }
        //    });
        //});

        $("#btnAddNew").off("click").on("click", function () {
            $("#modalAddUpdate").modal("show");
            productCategory.resetForm();
        });
        $("#btnSave").off("click").on("click", function () {
            $("#modalAddUpdate").modal("hide");
            productCategory.createUpdate();
        });
    },
    createUpdate: function () {
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
                } else {
                    alert("Update failed.");
                }
            },
            error: function () {

            }
        });
    },
    resetForm: function () {
        $("#hidID").val("0");
        $("#txtName").val("");
        $("#txtMetaTitle").val("");
        $("#txtCreatedBy").val("");
        $("#ckStatus").prop("checked", true);
    }
}
productCategory.init();