// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function setAlert(className, message) {
    var div = document.getElementById("customDiv");
    var alertDiv = document.createElement("div");

    alertDiv.setAttribute("class", "alert");
    alertDiv.setAttribute("id", "alertDiv");
    alertDiv.setAttribute("role", "alert");

    if (className !== "")
        alertDiv.setAttribute("class", "alert " + className);

    if (message !== "")
        alertDiv.innerText = message;

    var button = document.createElement("button");
    button.setAttribute("class", "close");
    button.setAttribute("id", "closeAlert");
    button.setAttribute("data-dismiss", "alert");
    button.setAttribute("aria-label", "Close");
    button.setAttribute("type", "button");

    var spn = document.createElement("span");
    spn.setAttribute("aria-hidden", "true");
    spn.innerHTML = "&times;";
    button.appendChild(spn);
    alertDiv.appendChild(button);
    div.appendChild(alertDiv);

    var closeAlert = document.getElementById("closeAlert");

    setTimeout(function () {
        closeAlert.click();
    },2000);
}
