$.validator.unobtrusive.parse(".modal-form");
$(".modal-form").submit(function(e) {
    e.preventDefault();
    $.ajax({
        async: true,
        type: "POST",
        url: $(this).attr("action"),
        data: $(this).serialize(),
        success: function(data) {
            if (data.status === "Ok") {
                window.location = window.location;
            } else {
                $(".modal-content").html(data);
            }
        },
        statusCode: {
            500: function() {
                window.location = window.location;
            }
        },
        error: function() {
            window.location = window.location;
            console.log("error");
        }
    });
});