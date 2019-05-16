class BodegaTripa {
    constructor(tipotripa, descarne, bodega, codigolote,numeropieles, peso, medida, personal, accion) {
        this.tipotripa = tipotripa;
        this.descarne = descarne;
        this.bodega = bodega;
        this.codigolote = codigolote;
        this.numeropieles = numeropieles;
        this.peso = peso;
        this.medida = medida;
        this.personal = personal;
        this.accion = accion;
    }
    GuardaClasificacionTripa() {
        if (this.tipotripa == '0') {
            document.getElementById('mensajede').innerHTML = 'Selecciona un tipo de clasificacion';
        } else {
            document.getElementById('mensajede').innerHTML = '';
            if (this.descarne == '0') {
                document.getElementById('mensajetri').innerHTML = 'seleccione que desea clasificar';
            } else {
                document.getElementById('mensajetri').innerHTML = '';
                if (this.bodega == '0') {
                    document.getElementById('mensajebo').innerHTML = 'Seleccione una bodega de almacenamineto';
                } else {
                    document.getElementById('mensajebo').innerHTML = '';
                    if (this.medida == '0') {
                        document.getElementById('mensajeme').innerHTML = 'Seleccione una medida';
                    } else {
                        document.getElementById('mensajeme').innerHTML = '';
                        if (this.personal == '0') {
                            document.getElementById('mensajeper').innerHTML = 'Seleccione a la persona indicada en este proceso';
                        } else {
                            var tipotripa = this.tipotripa;
                            var descarne = this.descarne;
                            var bodega = this.bodega;
                            var codigolote = this.codigolote;
                            var numeropieles = this.numeropieles;
                            var peso = this.peso;
                            var medida = this.medida;
                            var personal = this.personal;
                            var accion = this.accion;
                           
                            $.ajax({
                                type: "POST",
                                url: accion,
                                data: {
                                    tipotripa, descarne, bodega, codigolote, numeropieles, peso, medida, personal
                                },
                                success: (respuesta) => {
                                    console.log(respuesta);
                                    if (respuesta[0].code == 'ok') {
                                        $('#IngresoClasificacionTripa').modal('hide');
                                        listatripasindex();
                                        swal('Clasificacion Tripa', "Se guardo con exito", 'success');
                                        this.limpiarcajas();
                                        this.limpiarcajasTripa();

                                        
                                    } else {
                                        swal('Clasificacion Tripa', respuesta[0].description, 'error');
                                    }      
                                    this.limpiarcajas();
                                }
                            });
                        }
                    }
                }
            }
        }
    }
    limpiarcajasTripa() {
        document.getElementById("Descarneid").options.length = 1;
    }
    bodegatripa() {
        var bodegatripaId = this.numeropieles;
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { bodegatripaId },
            success: (respuesta) => {
                $('#BodegaTripa').html(respuesta[0]);
            }
        });
    }


    ClaseListaClasificacionTripa() {
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
    Claselistabodegas() {
        var accion = this.accion;
        var conta = 1;

        $.post(accion,
            {},
            (respuesta) => {
               
                if (0 < respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('BodegaId').options[conta] = new Option(respuesta[i].nombreBodega.toUpperCase(), respuesta[i].bodegaId);
                        conta++;
                    }

                }
            });

      
    }
    ClaseListadescarnes() {
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
    Numeropielstripas(id) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { id },
            success: (respuesta) => {
                $('#PielesInput').text(respuesta[0].cantidad);
                $('#PielesInput').removeClass("hidden");
            }
        });
    }
    Listaclasificaciontripaindex() {
        var accion = this.accion;
        $.post(accion,
            {},
            (res) => {
                
                $.each(res, (contador, valor) => {
                    $('#BodegaTripa').html(valor[0]);
                });
            });
      
    }
   

    limpiarcajas() {
        document.getElementById('Descarneid').selectIndex = 0;
        document.getElementById('PielesInput').text = '';
        document.getElementById('ClasificaciontripaId').selectIndex = 0;
        document.getElementById('NumeroPielesInput').value = '';
        document.getElementById('personalId').selectedIndex = 0;
        document.getElementById('PesoInput').selecttext = 0;
        listatripasindex();
       /// this.limpiarcajascombo();
        this.limpiarcajasTripa();
        
        $('#IngresoClasificacionTripa').modal('hidden');
       
        

    }
    
    
   
}
