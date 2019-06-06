class ClasificacionWB {
    constructor(fecha, numeropieles, observaciones, bodega, bombo, tipo, personal, codigolote,escurrido,codiuniWb, accion) {
        this.fecha = fecha;
        this.numeropieles = numeropieles;
        this.observaciones = observaciones;
        this.bodega = bodega;
        this.bombo = bombo;
        this.tipo = tipo;
        this.personal = personal;
        this.codigoLote = codigolote,
        this.escurrido = escurrido,
        this.codiuniWb = codiuniWb,
        this.accion = accion;
    }
    listaindexweb() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ClasificacionWBlista').html(val[0]);
                });
            }
        });
    }
    
    //// combo lista de escurridos
    listaescurridos() {
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
                        document.getElementById('EscurridoId').options[contador] = new Option(respuesta[i].codigoLote, respuesta[i].escurridoId);
                        contador++;
                    }
                }
            }
        });
    }
    GuardaClasificacionWB() {
        if (this.escurrido == '0') {
            $('mensajees').remove.removeClass("hidden");
        } else {
            $('mensajees').addClass("hidden");
        if (this.bodega == '0') {
            $('mensajebo').remove.removeClass("hidden");
        } else {
            $('mensajebo').addClass("hidden");
            if (this.tipo == '0') {
                    $('mensajeti').remove.removeClass("hidden");
            } else {
                $('mensajeti').addClass("hidden");
                    if (this.personal == '0') {
                        $('mensajeper').remove.removeClass("hidden");
                    } else {
                        var fecha = this.fecha;
                        var numeropieles = this.numeropieles;
                        var observaciones = this.observaciones;
                        var bodega = this.bodega;
                        var bombo = this.bombo;
                        var tipo = this.tipo;
                        var personal = this.personal;
                        var codigolote = this.codigoLote;
                        var escurrido = this.escurrido;
                        var codiuniWb = this.codiuniWb;
                        var accion = this.accion;
                        $.ajax({
                            type: "POST",
                            url: accion,
                            data: {
                                
                                fecha, numeropieles, observaciones, bodega, bombo,  tipo, personal, codigolote, escurrido,codiuniWb
                            },
                            success: (respuesta) => {
                                console.log(respuesta);
                                if (respuesta[0].code == 'ok') {
                                    $('#IngresoClasificacionWB').modal('hide');
                                    swal("Clasificacion WEB BLUE", "Se guardo exitosamente", "success");
                                    listaindexweb();
                                    this.limpiacajas();
                                    this.limpiarcajarclasiweb();
                                } else {
                                    swal("Clasificacion WEB BLUE", "Ocurrio un error", "error");
                                }
                                this.limpiacajas();
                            }
                        });
                    }
                }
            }

        
        }
    }
    limpiarcajarclasiweb() {
        document.getElementById("EscurridoId").options.length = 1;
    }
   
    /////obtener valores del anterior proceso

    uncrutido(id) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { id },
            success: (respuesta) => {
                //console.log(respuesta);
                document.getElementById('TotalPieles').value = respuesta.cantidad;
                $('#TotalPieles').value = respuesta.cantidad;
                $("#TotalPieles").removeClass("hidden");
                /////////////bombo
                document.getElementById('bomboId').value = respuesta.bombo;
                $('#bomboId').value = respuesta.bombo;
                $("#bomboId").removeClass("hidden");
                ///////////fecha
                document.getElementById('fecha').value = respuesta.fecha;
                $('#fecha').value = respuesta.fehca;
                $("#fecha").removeClass("hidden");
                /////codigolote
                document.getElementById('codigolotescurri').value = respuesta.codigo;
                $('#codigolotescurri').value = respuesta.codigo;
                $("#codigolotescurri").removeClass("hide");
            }
        });
    }
    limpiacajas() {
        document.getElementById('TotalPieles').text='';
        document.getElementById('bomboId').text = '';
        document.getElementById('fecha').text = '';
        document.getElementById('clasiwebId').selectedIndex = 0;
        document.getElementById('BodegaId').selectedIndex = 0;
        document.getElementById('cantidad').value = '';
        document.getElementById('fechaclasi').value = '';
        document.getElementById('personalId').selectedIndex = 0;
        listaindexweb();
       $('#ClasificacionWBlista').html('');
        this.limpiarcajarclasiweb();
        $('#IngresoClasificacionWB').modal('hide');

    }
    
}