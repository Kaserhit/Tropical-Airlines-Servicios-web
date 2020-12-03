$(".MEliminar").click(function (event) {
    if (!confirm('¿Esta seguro de eliminar el Consecutivo?')) {
        event.preventDefault();
    }
});