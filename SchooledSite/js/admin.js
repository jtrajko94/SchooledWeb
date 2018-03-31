$(function () {
    function initLogin() {
        var form = $("#login-form");
        if (form.length > 0) {
            form.find("#login-submit").click(function (e) {
                var button = $(this);
                button.html("Logging In...");
                button.attr("disabled", "disabled");
                var postData = form.serialize();
                $.ajax({
                    type: "POST",
                    cache: false,
                    dataType: "json",
                    url: "ws/admin/login/",
                    data: postData,
                    success: function (data) {
                        if (!data.IsValid) {
                            button.removeAttr("disabled");
                            button.html("Login");
                            if (data.ErrFields.email) $("#login-email").parent().addClass("has-error");
                            if (data.ErrFields.password) $("#login-password").parent().addClass("has-error");
                            var msg = "";
                            for (var i in data.ErrFields) {
                                msg += ((msg == "") ? "" : "\n") + data.ErrFields[i];
                            }
                            alert(msg)
                        } else {
                            window.location = "admin";
                        }
                    }
                });
            });
        }
    }

    initLogin();
});