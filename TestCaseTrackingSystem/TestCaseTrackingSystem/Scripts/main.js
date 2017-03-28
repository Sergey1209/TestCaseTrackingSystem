// common startup scripts
var TCTS = TCTS || {}; // TCTS stands for Test Case Tracking System

TCTS.Startup = TCTS.Startup || {};

$.extend(TCTS.Startup,
{
    ButtonConfirm: function() {
        $("input[data-btn-delete]")
            .each(function() {
                $(this)
                    .click(function() {
                        return confirm("You are about to delete an iteration. Are you sure?");
                    });
            });
    },
    DisableLinks: function() {
        $("a[disabled=true]").each(function() {
            $(this).click(function(e) {
                e.preventDefault();
            });
        });
    }
});

$(function() {
    TCTS.Startup.ButtonConfirm();
    TCTS.Startup.DisableLinks();
});