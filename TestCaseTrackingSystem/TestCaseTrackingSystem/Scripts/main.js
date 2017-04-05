// common startup scripts
var TCTS = TCTS || {}; // TCTS stands for Test Case Tracking System

TCTS.Startup = TCTS.Startup || {};

$.extend(TCTS.Startup,
{
    ButtonConfirm: function() {
        $("input[data-delete-item-name]")
            .each(function () {
                var deleteItemName = $(this).attr("data-delete-item-name");
                $(this)
                    .click(function() {
                        return confirm("You are about to delete " + deleteItemName + ". Are you sure?");
                    });
            });
    },
    DisableLinks: function() {
        $("a[disabled=true]").each(function() {
            $(this).click(function(e) {
                e.preventDefault();
            });
        });
    },
    InitDatePicker: function () {
        $('.date-picker').datepicker();
    }
});

$(function() {
    TCTS.Startup.ButtonConfirm();
    TCTS.Startup.DisableLinks();
    TCTS.Startup.InitDatePicker();
});