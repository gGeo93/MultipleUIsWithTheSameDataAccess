// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function VisibilityOfList()
{
    let liststyle = document.getElementById('navlist');
    if (liststyle.style.display == 'inline-block') {
        liststyle.style.display = 'none';
    }
    else {
        liststyle.style.display = 'inline-block';
    }
}
