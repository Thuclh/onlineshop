var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $(".btn-active").off("click").on("click", function (e) {
            e.preventDefault();
            var btn = $(this);
            var uid = btn.data("userid");
            $.ajax({
                url: "/Admin/User/ChangeStatus",
                dataType: "json",
                type: "POST",
                data: { id: uid },
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn.text("Kích hoạt");
                    } else {
                        btn.text("Khóa");
                    }
                }
            });
        });
    }
}
user.init();