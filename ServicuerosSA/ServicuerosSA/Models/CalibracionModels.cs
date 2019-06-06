using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServicuerosSA.Data;


namespace ServicuerosSA.Models
{
    public class CalibracionModels
    {
        ApplicationDbContext _contexto;
        public CalibracionModels (ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<ClasificacionWB> Modelolistaclasiwb()
        {
            return _contexto.ClasificacionWB.Where(c => c.Activo == true).ToList();
        }

        public List<IdentityError> Claseguardacalibracion(int clasiweb, DateTime fecha, int bombo, int cantiA, int cantiB, string codigolote, string codiunicalibrado)
        {
            List<IdentityError> listacalibra = new List<IdentityError>();
            IdentityError error = new IdentityError();
            try
            {
                var guardacali = new Calibracion
                {
                    Fechacalibracion = fecha,
                    bombo = bombo,
                    CantidadA = cantiA,
                    CantidadB = cantiB,
                    codigolote = codigolote,
                    ClasificacionwbId = clasiweb,
                    codiunicalibrado = codiunicalibrado,
                    activo = true

                };
                _contexto.Calibracion.Add(guardacali);
                _contexto.SaveChanges();
                ////desactivo atras
                ClasificacionWB clasiwe = (from cla in _contexto.ClasificacionWB
                                           where cla.ClasificacionwbId == clasiweb
                                           select new ClasificacionWB
                                           {
                                              ClasificacionwbId = cla.ClasificacionwbId,
                                              BodegaId = cla.BodegaId,
                                              bombo = bombo,
                                              clasiweb = cla.clasiweb,
                                              codigolote = cla.codigolote,
                                              EscurridoId = cla.EscurridoId,
                                              Fecha = cla.Fecha,
                                              NumeroPieles = cla.NumeroPieles,
                                              PersonalId = cla.PersonalId,
                                              codiuniWb = cla.codiuniWb,
                                              Activo = false,
                                           }).FirstOrDefault();
                _contexto.ClasificacionWB.Update(clasiwe);
                _contexto.SaveChanges();
                error =  new IdentityError
                {
                    Code = "ok",
                    Description = "ok"
                };
            }
            catch(Exception e)
            {
                error = new IdentityError
                {
                    Code = e.Message,
                    Description = e.Message,
                };
            }
            listacalibra.Add(error);
            return listacalibra;
        }
        public List<object[]> ModelolistaindexCalibrado()
        {
            List<object[]> listaCalibrado = new List<object[]>();
            string datos = "";
            var res = (from cali in _contexto.Calibracion
                       join clawb in _contexto.ClasificacionWB on cali.ClasificacionwbId equals clawb.ClasificacionwbId
                       join cla in _contexto.ClasificacionesWebblue on clawb.clasiwebId equals cla.clasiwebId
                       join es in _contexto.Escurrido on clawb.EscurridoId equals es.EscurridoId
                       join cur in _contexto.Curtido on es.CurtidoId equals cur.CurtidoId
                       join clatri in _contexto.Bodegatripa on cur.BodegaTripaId equals clatri.BodegaTripaId
                       join tripa in _contexto.ClasificacionTripa on clatri.ClasificacionTripaId equals tripa.ClasificacionTripaId
                       //join sele in _contexto.Clasificacion on clawb.ClasificacionId equals sele.ClasificacionId
                       where cali.activo == true
                       select new
                       {
                           cali.codigolote,
                           cali.bombo,
                           cali.CantidadA,
                           dato = cla.Detalle,
                           tripa.Detalle

                       });

            foreach (var item in res.ToList())
            {
                datos += "<tr>" +

                    "<td>" + item.codigolote + "</td>" +
                    "<td>" + item.bombo + "</td>" +
                    "<td>" + item.CantidadA + "</td>" +
                    "<td>" + item.dato + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                     "</tr>";
            }
            object[] objetodatos = { datos };
            listaCalibrado.Add(objetodatos);
            return listaCalibrado;
        }
    }
}
