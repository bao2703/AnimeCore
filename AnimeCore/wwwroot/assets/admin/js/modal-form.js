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
                console.log("Ok");
            } else {
                $(".modal-content").html(data);
                console.log("not valid");
            }
        },
        statusCode: {
            500: function() {
                window.location = window.location;
                console.log("500");
            }
        },
        error: function() {
            window.location = window.location;
            console.log("error");
        }
    });
});