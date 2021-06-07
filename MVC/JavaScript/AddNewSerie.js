
$(document).ready(function () {
    $('[serie-show-btn]').on('click', function (event) {
        event.preventDefault();
        $.ajax({
            url: "/Article/Serie",
            method: "get",
            success: function (data) {
                var $data = $(data);
                $('[serie-form-container]').html($data);
                $('[serie-add-btn]').on('click', function (event) {
                    event.preventDefault();
                    var $form = $('[serie-add-form]');
                    $.validator.unobtrusive.parse($form);
                    if ($form.valid()) {
                        $.ajax({
                            url: "/Article/Serie",
                            method: "post",
                            data: $form.serialize(),
                            beforeSend: function () {
                                $('[serie-add-btn]').prop("disabled", true);
                            },
                            success: function (data) {
                                
                            },
                            error: showAjaxError,
                            complete: function () {
                                $('[serie-add-btn]').prop("disabled", false)
                            }
                        })
                    }
                })
            }
        })


    })

})

function showAjaxError(jqXHR, textStatus, errorThrown) {
    console.log(jqXHR.responseText);
    console.log(textStatus);
    console.log(errorThrown);
};