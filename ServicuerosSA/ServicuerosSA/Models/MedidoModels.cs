using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServicuerosSA.Data;
namespace ServicuerosSA.Models
{
    public class MedidoModels
    {
        private ApplicationDbContext _contexto;

        public MedidoModels(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        public List<Calibracion> Modelolistaclasiwb()
        {
            return _contexto.Calibracion.Where(c => c.activo == true).ToList();
        }
        public List<ClasificacionTripa> ClaseTripa()
        {
            return _contexto.ClasificacionTripa.OrderBy(c => c.Detalle).ToList();
        }
        public List<object[]> ModelolistaindexMedido()
        {
            List<object[]> listaMedido = new List<object[]>();
            string datos = "";
            var res = (from me in _contexto.Medido
                       join cali in _contexto.Calibracion on me.CalibracionId equals cali.CalibracionId
                       join clawb in _contexto.ClasificacionWB on cali.ClasificacionwbId equals clawb.ClasificacionwbId
                       join cla in _contexto.ClasificacionesWebblue on clawb.clasiwebId equals cla.clasiwebId
                       join es in _contexto.Escurrido on clawb.EscurridoId equals es.EscurridoId
                       join cur in _contexto.Curtido on es.CurtidoId equals cur.CurtidoId
                       join clatri in _contexto.Bodegatripa on cur.BodegaTripaId equals clatri.BodegaTripaId
                       join tripa in _contexto.ClasificacionTripa on clatri.ClasificacionTripaId equals tripa.ClasificacionTripaId
                       //join sele in _contexto.Clasificacion on clawb.ClasificacionId equals sele.ClasificacionId
                       where me.activo == true
                       select new
                       {
                           me.Codigolote,
                           me.Area,
                           me.Pallet,
                           me.Cantidad,
                           me.Fecha,
                          // sele.Selecciones,
                           datos = cla.Detalle,
                           tripa.Detalle

                       });

            foreach (var item in res)
            {
                datos += "<tr>" +

                    "<td>" + item.Codigolote + "</td>" +
                    "<td>" + item.Area + "</td>" +
                    "<td>" + item.Pallet + "</td>" +
                    "<td>" + item.Cantidad + "</td>" +
                    "<td>" + item.Fecha + "</td>" +
                    // "<td>" + item.Selecciones + "</td>" +
                    "<td>" + item.datos + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "</tr>";
            }
            object[] objetodatos = { datos };
            listaMedido.Add(objetodatos);
            return listaMedido;
        }
        public List<IdentityError> ClaseguardaMedido(string codigolote, DateTime fecha, int calibracion, int cantidad, string pallet, Decimal area, int bodega, int personal, string tipo, string clasiweb, int estan)
        {
            List<IdentityError> listamedido = new List<IdentityError>();
        IdentityError error = new IdentityError();
            try
            {
                var guardamedi = new Medido
                {
                    Codigolote = codigolote,
                    Fecha = DateTime.Now,
                    CalibracionId = calibracion,
                    Cantidad = cantidad,
                    Pallet = pallet,
                    Area = area,
                    BodegaId = bodega,
                    PersonalId = personal, 
                    tipotri = tipo,
                    tipoweb = clasiweb,
                    estanteria = estan,
                    activo = true 
                };
                _contexto.Medido.Add(guardamedi);
                _contexto.SaveChanges();
                ////desactivo atras
                Calibracion calibra = (from cali in _contexto.Calibracion
                                            where cali.CalibracionId == calibracion
                                       select new Calibracion
                                            {
                                             CalibracionId = cali.CalibracionId,
                                             bombo = cali.bombo,
                                             CantidadA = cali.CantidadA,
                                             CantidadB = cali.CantidadB,
                                             codigolote = cali.codigolote,
                                             Fechacalibracion = cali.Fechacalibracion,
                                             activo= false
                                            }).FirstOrDefault();
                _contexto.Calibracion.Update(calibra);
                _contexto.SaveChanges();

                var calibradonuevo = (from cali in _contexto.Calibracion
                                      where cali.CalibracionId == calibracion
                                      select new Calibracion
                                      {
                                          CalibracionId = cali.CalibracionId,
                                          bombo = cali.bombo,
                                          CantidadA = cali.CantidadA,
                                          CantidadB = cali.CantidadB,
                                          codigolote = cali.codigolote,
                                          Fechacalibracion = cali.Fechacalibracion,
                                          activo = false
                                      }).FirstOrDefault();
                if((calibradonuevo.CantidadA - Convert.ToInt32(cantidad))>0)
                {
                    Calibracion dato = new Calibracion()
                    {
                        CalibracionId = calibradonuevo.CalibracionId,
                        bombo = calibradonuevo.bombo,
                        CantidadA = calibradonuevo.CantidadA - Convert.ToInt32(cantidad),
                        CantidadB = calibradonuevo.CantidadB,
                        codigolote = calibradonuevo.codigolote,
                        Fechacalibracion = calibradonuevo.Fechacalibracion,
                        activo = true
                    };
                    _contexto.Calibracion.Add(dato);
                    _contexto.SaveChanges();
                }

                error = new IdentityError
                {
                    Code = "ok",
                    Description = "ok"
                };
            }
            catch (Exception e)
            {
                error = new IdentityError
                {
                    Code = e.Message,
                    Description = e.Message,
                };

            }
            listamedido.Add(error);
            return listamedido;
        }





    }
}
    

