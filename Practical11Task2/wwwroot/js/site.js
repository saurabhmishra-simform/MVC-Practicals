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

function CheckStudentId() {
    $(document).ready(function () {
        let id = $("#Id").val();
        let message = $("#findId");
        let url = "/Student/FindId?id=" + id;

        $.ajax({
            url: url,
            method: "GET",
            dataType: "text",
            success: function (data) {
                let result = parseInt(data);
                if (result === 0) {
                    message.html("Student ID already exists in a list");
                } else {
                    message.html("");
                }
            },
            error: function (error) {
                console.error("Error:", error);
            },
        });
    });
}