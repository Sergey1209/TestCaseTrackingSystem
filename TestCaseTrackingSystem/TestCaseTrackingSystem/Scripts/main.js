// common startup scripts
var Startup = Startup || {};

$.extend(Startup, {
        ButtonConfirm: function () {
            $("input[data-btn-confirm]").each(function () {
                $(this).click(function() {
                    return confirm("Are you sure?");
                });
            });
        }
    });

$(function() {
    Startup.ButtonConfirm();
});