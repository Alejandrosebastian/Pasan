class clasiweb {
    constructor(detalle, accion) {
        this.detalle = detalle;
        this.accion = accion;
    }
    listatipo() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                if (0, respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('clasiwebId').options[contador] = new Option(respuesta[i].detalle, respuesta[i].clasiwebId);
                        contador++;
                    }
                }
            }

        });
    }
    listabanda() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                if (0, respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('clasiwebId').options[contador] = new Option(respuesta[i].detalle, respuesta[i].clasiwebId);
                        contador++;
                    }
                }
            }

        });
    }
}