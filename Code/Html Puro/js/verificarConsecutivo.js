function verificar() {

    var rangoI = document.getElementById("rangoI").value;
    var rangoF = document.getElementById("rangoF").value;


    if (rangoI > rangoF) {
        alert("Error - El rango Inicial es mayor al rango Final");
    } else {
        alert("Ingreso Correcto");
    }
}

(function () {

    var Prefijo = document.getElementById("Prefijo");
    var rangoI = document.getElementById("rangoI");
    var rangoF = document.getElementById("rangoF");


    var CheckPrefijo = document.getElementById("CheckPrefijo");
    var CheckRango = document.getElementById("CheckRango");

    CheckPrefijo.addEventListener("click", function () {

        if (this.checked) {
            Prefijo.disabled = "";


        }
        else {
            Prefijo.disabled = "disabled";
            Prefijo.value = "";
        }
    });

    CheckRango.addEventListener("click", function () {

        if (this.checked) {
            rangoI.disabled = "";
            rangoF.disabled = "";

        }
        else {
            rangoI.disabled = "disabled";
            rangoF.disabled = "disabled";
            rangoI.value = "";
            rangoF.value = "";
        }
    });

})();