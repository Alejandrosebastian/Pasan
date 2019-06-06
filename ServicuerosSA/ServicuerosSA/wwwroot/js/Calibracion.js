class Calibracion {
    constructor(clasiweb,fecha, bombo, cantiA, cantiB,codigolote,codiuni,  accion) {
        this.clasiweb = clasiweb;
        this.fecha = fecha;
        this.bombo = bombo;
        this.cantiA = cantiA;
        this.cantiB = cantiB;
        this.codigolote = codigolote;
        this.codiuni = codiuni;
        
        this.accion = accion;
    }
    //// combo listacalibracion web blue
    listaclas() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                
                if (0 < respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('ClasificacionwbId').options[contador] = new Option(respuesta[i].codigolote, respuesta[i].clasificacionwbId);
                    }
                }
            }
        });
    }

    listaindexcalibrado() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            success: (respuesta) => {
                
                $.each(respuesta, (index, val) => {
                    $('#Listacalibrado').html(val[0]);
                });
            }
        });
    }
    
    GuardaCalibracion() {
        if (this.clasiweb == '0') {
            $('mensajees').remove.removeClass("hidden");
        } else {
               $('mensajeca').addClass("hidden");
        if (this.codigolote == '') {
               $('mensajeca').remove.removeClass("hidden");
        } else {
                 var clasiweb = this.clasiweb;
                 var cantiA = this.cantiA;
                 var cantiB = this.cantiB;
                 var fecha = this.fecha;
                 var bombo = this.bombo;
                 var codigolote = this.codigolote;
                 var codiuni = this.codiuni;
                 var accion = this.accion;
                $.ajax({
                 type: "POST",
                 url: accion,
                 data: {
                      clasiweb,fecha,bombo,cantiA,cantiB, codigolote,codiuni
                 },
                   success: (respuesta) => {
                      if (respuesta[0].code == 'ok') {
                           swal("Calibracion", "Se guardo exitosamente", "success");
                      } else {
                           swal(" Calibracion ", "Ocurrio un error", "error");
                      }
                            }
                        });
                }
                

            


        }
    }
    limpiarcajarclasiweb() {
        document.getElementById("ClasificacionwbId").options.length = 1;
    }
    unclasiweb(id) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { id },
            success: (respuesta) => {
                console.table(respuesta);
                document.getElementById('codigoloteclasi').value = respuesta.codigo;
                $('#codigoloteclasi').value = respuesta.codigo;
                $("#codigoloteclasi").removeClass("hide");
                document.getElementById('fechacurti').value = respuesta.fecha;
                $('#fechacurti').value = respuesta.fecha;
                $("#fechacurti").removeClass("hidden");
                document.getElementById('Totalpieles').value = respuesta.cantidad;
                $('#Totalpieles').value = respuesta.cantidad;
                $("#Totalpieles").removeClass("hidden");
                document.getElementById('bombo').value = respuesta.bombo;
                $('#bombo').value = respuesta.bombo;
                $("#bombo").removeClass("hidden");
                document.getElementById('clasi').value = respuesta.detalle;
                $('#clasi').value = respuesta.detalle;
                $("#clasi").removeClass("hidden");
                document.getElementById('tipo').value = respuesta.detalle;
                $('#tipo').value = respuesta.detalle;
                $("#tipo").removeClass("hidden");
            }
        });
    }
}