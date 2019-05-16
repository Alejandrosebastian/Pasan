using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class Calibracion
    {
        public int CalibracionId { get; set; }
        public DateTime Fechacalibracion { get; set; }

        public int bombo { get; set; }
        public int CantidadA { get; set; }
        public int CantidadB { get; set; }
        public string  codigolote { get; set; }
        public bool activo { get; set; }
        public int ClasificacionwbId { get; set; }
        public ClasificacionWB ClasificacionWB { get; set; }
        
       
       
    }
}
