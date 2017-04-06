$.validator.unobtrusive.parse(".modal-form");
$(".modal-form").submit(function(e) {
    e.preventDefault();
    $.ajax({
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function(data) {
            if (data.status === "Ok") {
                window.location = window.location;
                console.log("Ok");
            } else {
                console.log("not valid");
            }
        },
        error: function() {
            console.log("error");
        }
    });
});