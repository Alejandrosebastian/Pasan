using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServicuerosSA.Data;

namespace ServicuerosSA.Models
{
    public class EscurridoModels
    {
        private ApplicationDbContext _contexto;

        public EscurridoModels(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<object[]> Modelolistacurtido(int id)
        {
            List<object[]> lista = new List<object[]>();
            string html = "";

            var datos = (from cur in _contexto.Curtido
                         join clat in _contexto.Bodegatripa on cur.BodegaTripaId equals clat.BodegaTripaId
                         join tri in _contexto.ClasificacionTripa on clat.ClasificacionTripaId equals tri.ClasificacionTripaId
                         where cur.BomboId == id && cur.Activo == true
                         select new
                         {
                             cur.CurtidoId,
                             cur.codigolote,
                             cur.NPieles,
                             cur.Fecha,
                             tri.Detalle,
                             cur.Peso
                         });

            foreach (var item in datos.ToList())
            {
                html += "<tr>" +
                    "<td hidden>" + item.CurtidoId +  "</td>" +
                     "<td>" + "<input type='checkbox' class='form-control' />" + "</td>" +
                    "<td>" + item.codigolote + "</td>" +
                    "<td>" + item.NPieles + "</td>" +
                    "<td>" + item.Peso + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                     "</tr>";
            }
            object[] objetos = { html };
            lista.Add(objetos);
            return lista;
        }
        public List<IdentityError> Modelonumeropielescurrido(int codigocurti, int valor)
        { 
            List<IdentityError> lista = new List<IdentityError>();
        IdentityError er = new IdentityError();
            int curtidonum = _contexto.Curtido.Where(c => c.CurtidoId == codigocurti && c.NPieles == valor).Count();
                if(valor <= curtidonum)
            {
                er = new IdentityError
                {
                    Code = "vale",
                    Description = "vale"
                };
            }
            else
            {
                er = new IdentityError
                {
                    Code = "no",
                    Description = "no"
                };
            }
            return lista;
        }
        public List<IdentityError> GuardarEscurrido(int bombo, int cantidad, string codilote, DateTime fecha, int curtido, int personal, string codiuniescurridio)
        {
            List<IdentityError> listaerror = new List<IdentityError>();
            List<Curtidolista> curtilis = (from cur in _contexto.Curtido
                                         where cur.codicurtido == codiuniescurridio
                                           select new Curtidolista
                                         {
                                             Activo = cur.Activo,
                                             codigolote = cur.codigolote,
                                             codicurtido = cur.codicurtido,
                                             Fecha = cur.Fecha,
                                             NPieles = cur.NPieles,
                                             curtidoId = cur.CurtidoId,
                                             Peso = cur.Peso,
                                             Observaciones = cur.Observaciones
                                         }).ToList();
            try
            {
                    var guardaescurrido = new Escurrido
                    {
                        
                        CurtidoId =Convert.ToInt32(curtido),
                        BomboId = bombo,
                        Cantidad = cantidad,
                        CodigoLote = codilote,
                        Fecha = DateTime.Now,
                        PersonalId = personal,
                        codiuniescurridio= codiuniescurridio,
                        Activo = true
                    };
                    _contexto.Escurrido.Add(guardaescurrido);
                    _contexto.SaveChanges();
                        /////desactivo atras
                    Curtido curt = (from curti in _contexto.Curtido
                                     where curti.CurtidoId == curtido
                                    select new Curtido
                                     {
                                         Activo =false,
                                         BomboId = curti.BomboId,
                                         codigolote = curti.codigolote,
                                         NPieles = curti.NPieles,
                                         PersonalId = curti.PersonalId,
                                         BodegaId = curti.BodegaId,
                                         CurtidoId = curti.CurtidoId,
                                         Fecha = curti.Fecha,
                                         BodegaTripaId = curti.BodegaTripaId,
                                         MedidaId = curti.MedidaId,
                                         FormulaId = curti.FormulaId,
                                         Observaciones = curti.Observaciones,
                                         codicurtido = curti.codicurtido,
                                         Peso = curti.Peso
                                     }).FirstOrDefault();
                    _contexto.Curtido.Update(curt);
                    _contexto.SaveChanges();
                    
                    var escurrdionuevo = (from curti in _contexto.Curtido
                                          where curti.CurtidoId == curtido
                                          select new Curtido
                                          {
                                              Activo = false,
                                              BomboId = curti.BomboId,
                                              codigolote = curti.codigolote,
                                              NPieles = curti.NPieles,
                                              PersonalId = curti.PersonalId,
                                              BodegaId = curti.BodegaId,
                                              CurtidoId = curti.CurtidoId,
                                              Fecha = curti.Fecha,
                                              BodegaTripaId = curti.BodegaTripaId,
                                              MedidaId = curti.MedidaId,
                                              FormulaId = curti.FormulaId,
                                              Observaciones = curti.Observaciones,
                                              codicurtido = curti.codicurtido,
                                              Peso = curti.Peso
                                          }).FirstOrDefault();
                if ((Convert.ToInt32(escurrdionuevo.NPieles) - Convert.ToInt32(cantidad)) > 0)
                {
                    Curtido dato = new Curtido()
                    {
                       
                        BomboId = escurrdionuevo.BomboId,
                        codigolote = escurrdionuevo.codigolote,
                        NPieles = escurrdionuevo.NPieles - Convert.ToInt32(cantidad),
                        BodegaTripaId = escurrdionuevo.BodegaTripaId,
                        BodegaId = escurrdionuevo.BodegaId,
                        PersonalId = escurrdionuevo.PersonalId,
                        FormulaId = escurrdionuevo.FormulaId,
                        Fecha =escurrdionuevo.Fecha,
                        MedidaId = escurrdionuevo.MedidaId,
                        Observaciones = escurrdionuevo.Observaciones,
                        Peso= escurrdionuevo.Peso,
                        codicurtido = escurrdionuevo.codicurtido,
                        Activo = true
                    };
                    _contexto.Curtido.Add(dato);
                    _contexto.SaveChanges();
                }

                listaerror.Add(new IdentityError
                {
                        Code = "ok",
                        Description = "ok"
                });
            }
            catch(Exception e)
            {
                listaerror.Add(new IdentityError
                {
                        Code= e.Message,
                        Description = e.Message
                });
            }
            return listaerror;
        }       
        
        
        public List<object[]> ModeloListaEscurrido()
        {
            List<object[]> lista = new List<object[]>();
            string list = "";
            var escu = (from es in _contexto.Escurrido
                        join bo in _contexto.Bombo on es.BomboId equals bo.BomboId
                        join cur in _contexto.Curtido on es.CurtidoId equals cur.CurtidoId
                        join clatri in _contexto.Bodegatripa on cur.BodegaTripaId equals clatri.BodegaTripaId
                        join tri in _contexto.ClasificacionTripa on clatri.ClasificacionTripaId equals tri.ClasificacionTripaId
                        where es.Activo == true
                        select new
                        {
                            cur.CurtidoId,
                            es.CodigoLote,
                            es.Cantidad,
                            es.Fecha,
                            bo.Num_bombo,
                            tri.Detalle
                        } );
            foreach(var item in escu)
            {
                list += "<tr>"+
                    // "<td>" +
                    //"<input type='checkbox' class='form-control'  value=" + item.CurtidoId + "|" + item.CodigoLote + "|" + item.Cantidad + "|" + item.Detalle + " />" +
                    //"</td>" +
                    "<td>" + item.CodigoLote + "</td>" +
                    "<td>" + item.Cantidad + "</td>" +
                    "<td>" + item.Fecha + "</td>" +
                    "<td>" + item.Num_bombo + "</td>" +
                    "<td>" + item.Detalle + "</td>" +

                     "</tr>";
            }
            object[] datos = { list };
            lista.Add(datos);
            return lista;
                    
        }
        public List<object[]> tablamodeloescurrdio(int id)
        {
            List<object[]> escurri = new List<object[]>();
            string lista = "";
            var esc = (from cur in _contexto.Curtido
                        join clat in _contexto.Bodegatripa on cur.BodegaTripaId equals clat.BodegaTripaId
                        join tri in _contexto.ClasificacionTripa on clat.ClasificacionTripaId equals tri.ClasificacionTripaId
                        where cur.BomboId == id && cur.Activo == true 
                        select new
                        {
                            cur.CurtidoId,
                            cur.codigolote,
                            cur.NPieles,
                            cur.Fecha,
                            tri.Detalle,
                            cur.Peso
                        });
            foreach (var item in esc)
            {
                lista += "<tr>" +
                    "<td>" +
                    "<input type='checkbox' class='form-control'  value=" + item.CurtidoId + "|" + item.codigolote + "|" + item.NPieles + "|" + item.Peso + " />" +
                    "</td>" +
                   "<td>" + item.codigolote + "</td>" +
                   "<td>" + item.NPieles + "</td>" +
                   "<td>" + item.Fecha + "</td>" +
                   "<td>" + item.Detalle + "</td>" +
                   "<td>" + item.Peso + "</td>" +

                    "</tr>";
            }
            object[] datos = { lista };
            escurri.Add(datos);
            return escurri;
        }

    }
}
