class Escurrido {
    constructor(Bombo, Cantidad, Codigolote, Fecha, Curtidos, personal, codiuniescurridio, accion)
    {
        this.Bombo = Bombo;
        this.Cantidad = Cantidad;
        this.Codigolote = Codigolote;
        this.Fecha = Fecha;
        this.CurtidoId = Curtidos;
        this.personal = personal,
        this.codiuniescurridio = codiuniescurridio,
        this.accion = accion;
    }
    ListaIndexEscurrido() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#EscurridoLista').html(val[0]);
                });
            }
        });
    }

    listatablamodal() {
        var accion = this.accion;
        $.post(accion,
            { },
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListaEscurrido').html(val[0]);
                });
            
            });
    }
    ///combo lista curtidos
    listacurtidos(id) {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {id},
            success: (respuesta) => {
                
                if (respuesta.length < 0) {
                    $('#ListaEscurrido').html('No tiene presenta registros');
                } else {
                    $.each(respuesta, (index, val) => {
                        $('#ListaEscurrido').html(val[0]);
                    });
                }
            }
        });
    }
        Guardaescurrdio()
        {
            if (this.Bombo == '0') {
                $("mensajebo").remove.removeClass("hidden");
            } else {
                $("mensajebo").addClass("hidden");
                if (this.Cantidad == '') {
                    $("mensajeca").remove.removeClass("hidden");
                } else {
                    $("mensajeca").addClass("hidden");
                    if (this.Codigolote == '') {
                        $("mensajees").remove.removeClass("hidden");
                    } else {
                        $("mensajees").addClass("hidden");
                        if (this.personal == '0') {
                            document.getElementById('mensajeper').innerHTML = 'Seleccione a la persona indicada en este proceso';
                        } else {
                        var bombo = this.Bombo;
                        var codigolote = this.Codigolote;
                        var cantidad = this.Cantidad;
                        var curtido = this.CurtidoId;
                        var fecha = this.Fecha;
                            var personal = this.personal;
                        var codiuniescurridio = this.codiuniescurridio;
                        var accion = this.accion;
                        $.ajax({
                            type: "POST",
                            url: accion,
                            data: {
                                bombo, cantidad, codigolote, curtido, fecha, personal,codiuniescurridio
                            },
                            success: (respuesta) => {
                                console.log(respuesta);
                                if (respuesta[0].code == "ok") {
                                    $('#IngresoEscurrido').modal('hide');
                                    ListaIndexEscurrido;
                                    swal("Escurrido", "Se guardo exitosamente", "success");
                                    this.limpiarcajas();
                                    
                                } else {
                                    
                                    swal("Escurrido", "Ocurrio un error", "error");

                                }
                            }
                            });
                        }
                    }
                   
                }

            }
        
          }

   
 
    NumeroPielesCurtido(id) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { id },
            success: (respuesta) => {
                document.getElementById('TotalPielesInput').value = respuesta;
                $('#TotalPielesInput').value = respuesta;
                $("#TotalPielesInput").removeClass("hidden");
            }
        });
    }
    codilote(id) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { id },
            success: (respuesta) => {
                document.getElementById('codigolotecurt').value = respuesta[0].codigolote;
                $('#codigolotecurt').value = respuesta[0].codigoLote;
                $('#codigolotecurt').removeClass('hidden');
                

            }
        });
    }
    limpiarcajas() {
        document.getElementById('Cantidad').value = '';
        document.getElementById('fecha').selectedIndex = 0;
        document.getElementById('bomboId').value = '';
        ListaIndexEscurrido;
        $('#IngresoEscurrido').modal('hidden');

    }
}