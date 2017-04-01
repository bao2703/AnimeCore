$.validator.unobtrusive.parse(".modal-form");
$(".modal-form").submit(function(e) {
    e.preventDefault();
    $.ajax({
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
        error: function() {
            console.log("error");
        }
    });
});