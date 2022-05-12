
function initializeModal(dialog, reference) {
    dialog.addEventListener("close", async e => {
        await reference.invokeMethodAsync("Close");
    });
}

function openModal(dialog) {
    if (!dialog.open) {
        dialog.showModal();
    }
}

function closeModal(dialog) {
    if (dialog.open) {
        dialog.close();
    }
}
