$(function () {

    $.ajaxSetup({ cache: false });

    $("a[data-modal]").on("click", function (e) {
        // hide dropdown if any
        $(e.target).closest('.btn-group').children('.dropdown-toggle').dropdown('toggle');

        
        $('#myModalContent').load(this.href, function () {
            

            $('#employee2').modal({
                /*backdrop: 'static',*/
                keyboard: true
            }, 'show');

            $("#fileUpload2").change(function () {
                var data = new FormData();

                var files = $("#fileUpload2").get(0).files;

                var towerId = $("#fileUpload2").attr('towerId');
                data.append("TowerId", towerId);
                // Add the uploaded image content to the form data collection
                if (files.length > 0) {
                    data.append("UploadedImage", files[0]);
                }

                // Make Ajax request with the contentType = false, and procesDate = false
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "AscTowerImageUploadEdit",
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (data) {
                        fileuploadresult(data);
                    },
                    error: function (error) { }
                });

            });

            function fileuploadresult(data) {
                var html = '';
                $.each(data.ImagePath, function (key, value) {
                    html += "<img src='../Images/Uploads/Towers/" + value + "' width='100' height='100' alt='' />";

                });
                $("#uploadedimagediv2").html(html);

            }


            bindForm(this);
        });

        return false;
    });


});

function bindForm(dialog) {
    
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#employee2').modal('hide');
                    //Refresh
                    location.reload();
                } else {
                    $('#myModalContent').html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}