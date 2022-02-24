$(document).ready(function () {

    $(".btn-push").each(function () {
        $(this).click(function () {
            let token = $(this).data("token");
            let msg = $(this).parent().parent().find(".msg").val();
            if (token && msg) {
                $.ajax({
                    url: "/user/push",
                    data: { "token": token, "message": msg },
                    dataType: "JSON",
                    method: "POST",
                    beforeSend: function () {
                        $(this).text("Sending ...");
                        $(this).add("disabled", "disabled");
                    },
                    success: function (data) {

                        $(this).text("Push");
                        $(this).removeAttr("disabled");

                        if (data) {
                            alert("Push sucessful!!");
                        } else {
                            alert("Can't push notification!!");
                        }
                    },
                    error: function () {
                        $(this).text("Push");
                        $(this).removeAttr("disabled");
                        alert("Can't push notification!!");
                    }
                });
            } else {
                $(this).parent().parent().find(".msg").focus();
            }
        });
    });

});