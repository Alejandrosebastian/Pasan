class BodegaCarnaza {
    constructor(codigo, peso,tripa,bodega, accion)
    {
        this.codigo = codigo;
        this.peso = peso;
        this.tripa = tripa;
        this.bodega = bodega;
        this.accion = accion;
    }
    GuardaCarnaza() {
        if (this.codigolote == '0') {
            document.getElementById('mensajelo').innerHTML = "Seleccione el bombo";
        } else {
            document.getElementById('mensajelo').innerHTML = "";
            if (this.medida == '0') {
                document.getElementById('mensajeme').innerHTML = "Seleccione una medida";
            } else {
                document.getElementById('mensajeme').innerHTML = "";
                if (this.personal == '0') {
                    document.getElementById('mensajep').innerHTML = "Seleccione al personal asignado";
                } else {
                    var peso = this.peso;
                    var codigo = this.codigol;
                    var tripa = this.tripa;
                    var bodega = this.bodega;
                    var accion = this.accion;
                    $.ajax({
                        type: "POST",
                        url: accion,
                        data: {
                            peso,codigo,tripa,bodega
                        },
                        success: (respuesta) => {
                            if (respuesta[0].code == "ok") {
                                $('#IngresoCarnaza').modal('hide');
                                ListaIndexCurt();
                                swal("Carnaza", "Se guardo exitosamente", "success");
                                this.limpiarcajas();
                            } else {
                                this.limpiarcajas();
                                swal("Carnaza", "Ocurrio un error", "error");
                            }

                        }
                    });
                }
            }
        }
    }
    ClaseListacarna() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                if (0 < respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('Descarneid').options[contador] = new Option(respuesta[i].codigoLote, respuesta[i].descarneId);
                        contador++;
                    }
                }


            }
        });
    }
     limpiarcajas() {
        document.getElementById('loteId').selectedIndex = 0;
        document.getElementById('medidaId').selectedIndex = 0;
        document.getElementById('personalId').selectedIndex = 0;
        ListaIndexCurt();
         $('#IngresoCarnaza').modal('hidden');

    }
}