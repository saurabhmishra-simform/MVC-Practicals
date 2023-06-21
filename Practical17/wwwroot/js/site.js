// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ConfirmDelete(studentId) {
    let url;
    if (confirm("Are you sure you want to delete?")) {
        url = "/Student/Delete?id=" + studentId;
    }
    else {
        url = "/Student/Index";
    }
    window.location.href = url;
}