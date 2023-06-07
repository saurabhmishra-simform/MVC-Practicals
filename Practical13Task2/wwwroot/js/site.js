// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ConfirmDelete(id,urlType) {
    let url;
    if (confirm("Are you sure you want to delete?")) {
        url = "/" + urlType + "/Delete?id=" + id;
    }
    else {
        url = "/" + urlType + "/Index";
    }
    window.location.href = url;
}

function EmployeeCount(id) {
    $(document).ready(function () {
        $.ajax({
            url: "/Designation/CountEmployee?id=" + id,
            type: "GET",
            success: function (data) {
                // This function is executed if the AJAX request is successful
                $("#GetEmp").text("Total Employee: " + data);
            },
            error: function () {
                // This function is executed if there is an error during the AJAX request
                alert("Error occurred while counting records.");
            }
        });
    });
}
