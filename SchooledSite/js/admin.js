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
                    url: "/ws/admin/login/",
                    data: postData,
                    success: function (data) {
                        if (!data.IsValid) {
                            button.removeAttr("disabled");
                            button.html("Login");
                            if (data.ErrFields.email) $("#login-email").parent().addClass("has-error");
                            if (data.ErrFields.password) $("#login-password").parent().addClass("has-error");
                            var msg = "";
                            for (var i in data.ErrFields) {
                                msg += ((msg === "") ? "" : "\n") + data.ErrFields[i];
                            }
                            alert(msg);
                        } else {
                            window.location = "/admin";
                        }
                    }
                });
            });
        }
    }

    function initLogout() {
        if ($("#logout-user").length > 0) {
            $("#logout-user").click(function (e) {
                $.ajax({
                    type: "POST",
                    cache: false,
                    dataType: "json",
                    url: "/ws/admin/logout/",
                    data: "",
                    success: function (data) {
                        window.location = "/admin";
                    }
                });
            });
        }
    }

    function initAddEditUser() {
        var form = $("#user-form");
        if (form.length > 0) {
            form.find("#user-submit").click(function (e) {
                var button = $(this);
                button.html("Saving...");
                button.attr("disabled", "disabled");
                var postData = form.serialize();
                $.ajax({
                    type: "POST",
                    cache: false,
                    dataType: "json",
                    url: "/ws/admin/users/add-edit/",
                    data: postData,
                        //+ "&action=" + $("#action").val(),
                    success: function (data) {
                        if (!data.IsValid) {
                            button.removeAttr("disabled");
                            button.html("Save");
                            if (data.ErrFields.email) $("#user-email").parent().addClass("has-error");
                            if (data.ErrFields.password) $("#user-password").parent().addClass("has-error");
                            if (data.ErrFields.firstname) $("#user-firstname").parent().addClass("has-error");
                            if (data.ErrFields.lastname) $("#user-lastname").parent().addClass("has-error");
                            var msg = "";
                            for (var i in data.ErrFields) {
                                msg += ((msg === "") ? "" : "\n") + data.ErrFields[i];
                            }
                            alert(msg);
                        } else {
                            window.location = "/admin/users";
                        }
                    }
                });
            });
        }
    }

    initLogin();
    initLogout();
    initAddEditUser();
});