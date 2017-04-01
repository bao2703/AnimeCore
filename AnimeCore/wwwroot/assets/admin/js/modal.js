$(".action-modal").on("show.bs.modal",
    function() {
    }).on("hidden.bs.modal",
    function() {
        $(this).removeData("bs.modal");
    });