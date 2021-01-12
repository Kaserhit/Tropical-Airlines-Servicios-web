$(".MEliminar").click(function (event) {
    if (!confirm('¿Esta seguro de eliminar la Aeropuerto?')) {
        event.preventDefault();
    }
});