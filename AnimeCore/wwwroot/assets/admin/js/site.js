$(document).ready(function() {
    $("#dataTables").DataTable({
        responsive: true
    });
});

$(document).on("change",
    ":file",
    function() {
        var input = $(this),
            numFiles = input.get(0).files ? input.get(0).files.length : 1,
            label = input.val().replace(/\\/g, "/").replace(/.*\//, "");

        var text = $(this).parents(".input-group").find(":text"),
            log = numFiles > 1 ? numFiles + " files selected" : label;

        if (text.length) {
            text.val(log);
        } else {
            if (log) alert(log);
        }
    });