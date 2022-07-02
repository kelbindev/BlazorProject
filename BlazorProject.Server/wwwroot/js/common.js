window.showToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Success", { timeOut: 5000 });
    }
    else if (type === "warning") {
        toastr.warning(message, "Warning", { timeOut: 5000 });
    }
    else if (type === "error") {
        toastr.error(message, "Error", { timeOut: 5000 });
    }
}

function ShowDeleteConfirmationl() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmation() {
    $('#deleteConfirmationModal').modal('hide');
}