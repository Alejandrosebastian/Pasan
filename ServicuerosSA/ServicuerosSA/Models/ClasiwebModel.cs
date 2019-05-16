using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicuerosSA.Data;


namespace ServicuerosSA.Models
{
    public class ClasiwebModel
    {
        ApplicationDbContext _contexto;

        public ClasiwebModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        public List<Clasiweb> Clalisttipo()
        {
            return _contexto.ClasificacionesWebblue.OrderBy(cl => cl.Detalle).ToList();
        }
    }
}
