class Medido {
    constructor(codigolote, fecha, calibracion, cantidad, pallet, area, bodega, personal, tipo, clasiweb, estan,codiunimedido,accion)
    {
        this.codigolote = codigolote;
       
        this.fecha = fecha;
        this.calibracion = calibracion;
        this.cantidad = cantidad;
        this.pallet = pallet;
        this.area = area;
        this.bodega = bodega;
        this.personal = personal;
        this.tipo = tipo;
        this.clasiweb = clasiweb;
        this.estan = estan;
        this.codiunimedido = codiunimedido;
        this.accion = accion;

    }
    ///combo lista 
    listacalibra() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                console.log(respuesta);
                if (0 < respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('CalibracionId').options[contador] = new Option(respuesta[i].codigolote, respuesta[i].calibracionId);
                        contador++;
                    }
                }
            }
        });
    }
    ClaseListtipotripa() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                // console.log(respuesta);
                if (0 < respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('ClasificaciontripaId').options[contador] = new Option(respuesta[i].detalle.toUpperCase(), respuesta[i].clasificacionTripaId);
                        contador++;
                    }
                }


            }
        });
    }
    listaindexmedido()
    {
        var accion = this.accion
        $.ajax({
            type: "POST",
            url: accion,
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#listaIndexMedido').html(val[0]);
                });
            }
        });
    }
    GuardaMedido() {
        if (this.calibracion == '0') {
            document.getElementById('mensajees').innerHTML = "Seleccione un lote";
        } else {
            document.getElementById('mensajees').innerHTML = "";
            if (this.bodega == '0') {
                document.getElementById('mensajebo').innerHTML = "Seleccione la bodega";
            } else {
                document.getElementById('mensajebo').innerHTML = "";
            } if (this.personal == '0') {
                document.getElementById('mensajeper').innerHTML = "";
            } else {
                var codigolote = this.codigolote;
                var fecha = this.fecha;
                var calibracion = this.calibracion;
                var cantidad = this.cantidad;
                var pallet = this.pallet;
                var area = this.area;
                var bodega = this.bodega;
                var personal = this.personal;
                var tipo = this.tipo;
                var clasiweb = this.clasiweb;
                var estan = this.estan;
                var codiunimedido = this.codiunimedido;
                var accion = this.accion;
                $.ajax({
                    type: "POST",
                    url: accion,
                    data: {
                        codigolote, fecha, calibracion, cantidad, pallet, area, bodega, personal, tipo, clasiweb, estan, codiunimedido
                    },
                    success: (respuesta) => {
                        if (respuesta[0].code === "ok") {
                            this.limpiacajas();
                            $('#IngresoMedido').modal('hide');
                            swal("Medido", "Seguardo con exito", "succes");
                            this.limpiarcajarclasiweb();
                        } else {
                           this.limpiacajas();
                            swal("Medido", "Error al guardar", "error");
                            this.limpiarcajarclasiweb();
                        }
                    }
                });
            }

        }
    }
        limpiarcajarclasiweb() {
            document.getElementById("CalibracionId").options.length = 1;
        }

    uncalibrado(id) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { id },
            success: (respuesta) => {
                console.table(respuesta);
                document.getElementById('codigolotemedido').value = respuesta.codigo;
                $('#codigolotemedido').value = respuesta.codigo;
                $("#codigolotemedido").removeClass("hide");
                document.getElementById('fechamedi').value = respuesta.fecha;
                $('#fechamedi').value = respuesta.fecha;
                $("#fechamedi").removeClass("hidden");
                document.getElementById('Totalpieles').value = respuesta.cantidad;
                $('#Totalpieles').value = respuesta.cantidad;
                $("#Totalpieles").removeClass("hidden");
                document.getElementById('bombo').value = respuesta.bombo;
                $('#bombo').value = respuesta.bombo;
                $("#bombo").removeClass("hidden");
                //document.getElementById('clasi').value = respuesta.detalle;
                //$('#clasi').value = respuesta.detalle;
                //$("#clasi").removeClass("hidden");
                //document.getElementById('tipo').value = respuesta.detalle;
                //$('#tipo').value = respuesta.detalle;
                //$("#tipo").removeClass("hidden");
                
            }
        });
    }
    limpiacajas() {
        document.getElementById('Totalpieles').text = '';
        document.getElementById('bombo').text = '';
        document.getElementById('fecha').text = '';
        document.getElementById('ClasificaciontripaId').selectedIndex = 0;
        document.getElementById('clasiwebId').selectedIndex = 0;
        document.getElementById('cantidad').value = '';
        document.getElementById('pallet').text = '';
        document.getElementById('fechamedi').value = '';
        document.getElementById('personalId').selectedIndex = 0;
        document.getElementById('BodegaId').selectedIndex = 0;
        document.getElementById('estante').text = '';
        document.getElementById('fecha').text = '';

        listaindexmedido();
        $('#IngresoMedido').html('');
        this.limpiarcajarclasiweb();
        $('#IngresoMedido').modal('hide');

    } 
        
}