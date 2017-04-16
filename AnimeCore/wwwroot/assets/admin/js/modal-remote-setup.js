$(".action-modal").on("show.bs.modal",
    function() {
    }).on("hidden.bs.modal",
    function() {
        $(this).find("video")[0].remove();
        $(this).removeData("bs.modal");
    });