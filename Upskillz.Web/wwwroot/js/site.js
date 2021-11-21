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

showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
}

//function addSamurai() {
//    var modal = $("#addSamuraiModal");
//    var form = $('form[name="addSamuraiForm"]');

//    form.validate();
//    if (!form.valid()) {
//        return;
//    } else {
//        var data = form.serialize();
//        $.post("/Samurai/AddSamurai", data, function (res) {
//            if (res) {
//                modal.modal('hide');

//            }
//        })
//    }
//}

const getSamurais = () => {
    $.ajax({
        type: 'GET',
        url: "/Samurai/AllSamurais",
        contentType: "application/json",
        success: (res) => {
            console.log(res)
            var samurais = res.html;
            $("#samuraiList").empty()
            $("#samuraiList").append(samurais)
        }
    })
}

jQueryAjaxPost = form => {

    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $("#samuraiList").html(res.html);
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                } else {
                    $('#form-modal .modal-body').html(res.html);
                }
            },
            error: function (err) {

            }
        })
    } catch (e) {

    }

    //to prevent default form submit
    return false;
}
