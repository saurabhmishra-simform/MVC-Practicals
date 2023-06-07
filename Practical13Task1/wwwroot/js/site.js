// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ConfirmDelete(employeeId) {
    let url;
    if (confirm("Are you sure you want to delete?")) {
        url = "/Employee/Delete?id=" + employeeId;
    }
    else {
        url = "/Employee/Index";
    }
    window.location.href = url;
}