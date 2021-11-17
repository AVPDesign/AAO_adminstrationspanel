// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function openTableColunm() {
    document.getElementById("tableToOpen").style.display = "revert";
    document.getElementsByClassName("expandMore").style.display = "none";
    document.getElementsByClassName("expandLess").style.display = "visible";

}

function closeTableColumn() {
    document.getElementById("tableToOpen").style.display = "none";
}