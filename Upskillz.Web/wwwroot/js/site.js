// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-samurai-target"));
            $target.replaceWith(data);
        });
    };

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-samurai-autocomplete")
        };

        $input.autocomplete(options);
    };

    $("form[data-samurai-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-samurai-autocomplete]").each(createAutocomplete);
});