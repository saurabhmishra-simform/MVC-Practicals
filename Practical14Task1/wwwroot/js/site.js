// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ConfirmDelete(id) {
    let url;
    if (confirm("Are you sure you want to delete?")) {
        url = "/Employee/Delete?id=" + id;
    }
    else {
        url = "/Employee/Index";
    }
    window.location.href = url;
}

$(function () {
    $("#SearchForm").submit(function (e) {
        e.preventDefault();
        let name = $("#SearchInput").val();
        let form = $(this);
        let url = "/Employee/Search?name=" + name;
        let formData = form.serialize();

        $.ajax({
            type: 'Post',
            url: url,
            data: formData,
            success: function (data) {
                $('#SearchResult').html(data);
            }
        });
    });
});
