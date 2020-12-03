$(".MEliminar").click(function (event) {
    if (!confirm('¿Esta seguro de eliminar la Aerolinea?')) {
        event.preventDefault();
    }
});