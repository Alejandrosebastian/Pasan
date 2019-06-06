using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class LsitaclasiWB
    {
        public int clasificacionwbId { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroPieles { get; set; }
        public string Observaciones { get; set; }
        public bool Activo { get; set; }
        public string codigolote { get; set; }
        public int bombo { get; set; }
        //relaciones
        public int BodegaId { get; set; }
        public int PersonalId { get; set; }
        public int clasiwebId { get; set; }
        public int EscurridoId { get; set; }
       
    }
}
