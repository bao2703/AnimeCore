$(document).on("submit",
    ".modal-form",
    function(e) {
        e.preventDefault();
        if ($(this).valid()) {
            $.ajax({
                type: this.method,
                url: this.action,
                data: new FormData(this),
                processData: false,
                contentType: false,
                success: function(data) {
                    if (data.status === "Ok") {
                        location.reload();
                        console.log("Ok");
                    } else {
                        console.log("not valid");
                        $(".modal-content").html(data);
                    }
                },
                error: function() {
                    console.log("error");
                },
                beforeSend: function() {
                    $(".btn").addClass("disabled");
                    $(".action-modal").on("hide.bs.modal.prevent",
                        function(e) {
                            e.preventDefault();
                        });
                },
                complete: function() {
                    
                }
            });
        }
    });