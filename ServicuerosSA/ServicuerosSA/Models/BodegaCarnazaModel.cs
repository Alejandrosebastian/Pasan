using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServicuerosSA.Data;

namespace ServicuerosSA.Models
{
    public class BodegaCarnazaModel
    {
        ApplicationDbContext _contexto;

        public BodegaCarnazaModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<Descarne> modelolistacarnaza()
        {
            return _contexto.Descarne.Where(de => de.Activo).ToList();
        }
        //***GUARDA
        public List<IdentityError> ClaseguardaCarnaza(string codigo, decimal peso)
        {
            List<IdentityError> listacarnaza = new List<IdentityError>();
            IdentityError error = new IdentityError();

            try
            {
                var guardacarnaza = new BodegaCarnaza
                {
                    Codigo = codigo,
                    Cantidad = peso
                };

                _contexto.BodegaCarnaza.Add(guardacarnaza);
                _contexto.SaveChanges();

            }
            catch (Exception ex)
            {
                listacarnaza.Add(new IdentityError
                {
                    Code = ex.Message,
                    Description = ex.Message
                });
            }

               return listacarnaza;
           
            //******
        }
    }
}
