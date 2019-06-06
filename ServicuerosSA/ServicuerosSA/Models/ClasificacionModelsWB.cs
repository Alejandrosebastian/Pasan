using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using ServicuerosSA.Data;

namespace ServicuerosSA.Models
{
    public class ClasificacionModelsWB
    {
        ApplicationDbContext _contexto;
       
        public ClasificacionModelsWB(ApplicationDbContext contexto)
        {
            _contexto = contexto;
            
        }
        public List<Escurrido> Claselistamodelescurrido()
        {
            return _contexto.Escurrido.Where(es => es.Activo == true).ToList();
        }
        public List<object[]> ModelolistaindexclasiWB()
        {
            List<object[]> listaclasiWB = new List<object[]>();
            string datos = "";
            var res = (from claWB in _contexto.ClasificacionWB
                       join cla in _contexto.ClasificacionesWebblue on claWB.clasiwebId equals cla.clasiwebId
                       join es in _contexto.Escurrido on claWB.EscurridoId equals es.EscurridoId
                       join cur in _contexto.Curtido on es.CurtidoId equals cur.CurtidoId
                       join clatri in _contexto.Bodegatripa on cur.BodegaTripaId equals clatri.BodegaTripaId
                       join tripa in _contexto.ClasificacionTripa on clatri.ClasificacionTripaId equals tripa.ClasificacionTripaId
                      // join sele in _contexto.Clasificacion on claWB.ClasificacionId equals sele.ClasificacionId
                       where claWB.Activo == true
                       select new
                       {
                           claWB.codigolote,
                           claWB.NumeroPieles,
                           claWB.Fecha,
                           //sele.Selecciones,
                           datos = cla.Detalle,
                           tripa.Detalle,
                           claWB.Observaciones,


                       });
            foreach (var item in res)
            {
                datos += datos += "<tr>" +
                    
                    "<td>" + item.codigolote + "</td>" +
                    "<td>" + item.NumeroPieles + "</td>" +
                   // "<td>" + item.bombo + "</td>" +
                    "<td>" + item.Fecha + "</td>" +
                   // "<td>" + item.Selecciones + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.datos + "</td>" +
                    "<td>" + item.Observaciones + "</td>" +
                    "</tr>";
            }
            object[] objetodatos = { datos };
            listaclasiWB.Add(objetodatos);
            return listaclasiWB;
        }
        public List<IdentityError> claseguardaweb(DateTime fecha, int numeropieles, string observaciones, int bodega, int bombo,  int tipo, int personal, string codigolote, int escurrido, string codiuniWb)
        {
            List<IdentityError> listaweb = new List<IdentityError>();
            List<EscurriList> listaWB = (from es in _contexto.Escurrido
                                          where es.codiuniescurridio == codiuniWb
                                          select new EscurriList
                                          {
                                              Activo = es.Activo,
                                              CodigoLote = es.CodigoLote,
                                              escurridoId = es.EscurridoId,
                                              Fecha = es.Fecha,
                                              Cantidad = es.Cantidad,
                                              CurtidoId = es.CurtidoId,
                                              PersonalId = es.PersonalId,
                                              BomboId = es.BomboId
                                          }).ToList();


            try
            {
                var guardaweb = new ClasificacionWB
                {
                    Fecha = DateTime.Now,
                    clasiwebId = tipo,
                    BodegaId = bodega,
                    bombo = bombo,
                    NumeroPieles = numeropieles,
                    PersonalId = personal,
                    codigolote = codigolote,
                    Observaciones = observaciones,
                    EscurridoId = escurrido,
                    codiuniWb = codiuniWb,
                    Activo = true
                };
                _contexto.ClasificacionWB.Add(guardaweb);
                _contexto.SaveChanges();
                ////desactivo atras
                Escurrido escurri = (from es in _contexto.Escurrido
                                     where es.EscurridoId == escurrido
                                     select new Escurrido
                                     {
                                         EscurridoId = es.EscurridoId,
                                         PersonalId = es.PersonalId,
                                         BomboId = es.BomboId,
                                         CurtidoId = es.CurtidoId,
                                         CodigoLote = es.CodigoLote,
                                         Cantidad = es.Cantidad,
                                         codiuniescurridio = es.codiuniescurridio,
                                         Fecha = es.Fecha,
                                         Activo = false,
                                     }).FirstOrDefault();
                _contexto.Escurrido.Update(escurri);
                _contexto.SaveChanges();

                var clasificacionWBnuevo =(from es in _contexto.Escurrido
                                           where es.EscurridoId == escurrido
                                           select new Escurrido
                                           {
                                               EscurridoId = es.EscurridoId,
                                               PersonalId = es.PersonalId,
                                               BomboId = es.BomboId,
                                               CurtidoId = es.CurtidoId,
                                               CodigoLote = es.CodigoLote,
                                               Cantidad = es.Cantidad,
                                               codiuniescurridio = es.codiuniescurridio,
                                               Fecha = es.Fecha,
                                               Activo = false,
                                           }).FirstOrDefault();
                if((Convert.ToInt32(clasificacionWBnuevo.Cantidad)- Convert.ToInt32(numeropieles))>0)
                {
                    Escurrido dato = new Escurrido()
                    {
                        BomboId =clasificacionWBnuevo.BomboId,
                        CodigoLote = clasificacionWBnuevo.CodigoLote,
                        Cantidad = clasificacionWBnuevo.Cantidad - Convert.ToInt32(numeropieles),
                        CurtidoId = clasificacionWBnuevo.CurtidoId,
                        Fecha = clasificacionWBnuevo.Fecha,
                        PersonalId = clasificacionWBnuevo.PersonalId,
                        codiuniescurridio = clasificacionWBnuevo.codiuniescurridio,
                        Activo = true

                    };
                    _contexto.Escurrido.Add(dato);
                    _contexto.SaveChanges();
                }

                listaweb.Add( new IdentityError
                {
                    Code = "ok",
                    Description = "ok"
                });
            }
            catch (Exception e)
            {
                listaweb.Add( new IdentityError
                {
                    Code = e.Message,
                    Description = e.Message,
                });

            }
            return listaweb;

        }
    }
}
