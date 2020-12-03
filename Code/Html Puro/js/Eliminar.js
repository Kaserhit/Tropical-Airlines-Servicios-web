$(".MEliminar").click(function (event) {
    if (!confirm('¿Esta seguro de eliminar el Pais?')) {
        event.preventDefault();
    }
});