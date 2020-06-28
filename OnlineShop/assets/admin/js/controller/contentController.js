$(document).ready(function () {
    changeStatus();
});
function changeStatus() {
    $(".btn-active").off("click").on("click", function (e) {
        e.preventDefault();
        var btn = $(this);
        var id = btn.data("id");
        $.ajax({
            url: "/Admin/Content/ChangeStatus",
            type: "POST",
            data: { id: id },
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    btn.text("Kích hoạt");
                } else {
                    btn.text("Khóa");
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
}
