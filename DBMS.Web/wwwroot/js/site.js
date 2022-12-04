$(document).ready(function() {
    $('#myTable').DataTable({
        "paging": true
    });
});

function categoryShow(id) {
    let test = document.getElementById("table-" + id);
    test.classList.remove("hidden");
    test.classList.add("anim");
    console.log(3);
}

function categoryClose(id) {
    let test = document.getElementById("table-" + id);
    test.classList.add("hidden");
    console.log(4);
}

