document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".alert-dismissible").forEach(function (alert) {
        setTimeout(function () {
            const closeButton = alert.querySelector(".btn-close");
            if (closeButton) {
                closeButton.click();
            }
        }, 4000);
    });
});
