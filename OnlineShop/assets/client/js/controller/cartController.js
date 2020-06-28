var cartController = {
    init: function () {
        cartController.registerEvent();
    },
    registerEvent: function () {

        $("#btnContineu").off("click").on("click", function () {
            window.location.href = "/";
        });

        $("#btnUpdate").off("click").on("click", function () {
            var listProduct = $(".txtQuantity");
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ID: $(item).data("id")
                    }
                });
            });
            $.ajax({
                url: "/Cart/Update",
                data: { cartModel: JSON.stringify(cartList) },
                type: "POST",
                dataType: "json",
                success: function (response) {
                    if (response.status == true) {
                        window.location.href = "/gio-hang"
                    }
                }
            });
        });

        $("#btnDeleteAll").off("click").on("click", function () {
            $.ajax({
                url: "/Cart/DeleteAll",
                type: "POST",
                dataType: "json",
                success: function (response) {
                    if (response.status == true) {
                        window.location.href = "/gio-hang"
                    }
                }
            });
        });

        $(".btn-delete").off("click").on("click", function (e) {
            e.preventDefault();
            $.ajax({
                url: "/Cart/Delete",
                type: "POST",
                data: { id: $(this).data("id") },
                dataType: "json",
                success: function (response) {
                    if (response.status == true) {
                        window.location.href = "/gio-hang"
                    }
                }
            });
        });
    }
}
cartController.init();