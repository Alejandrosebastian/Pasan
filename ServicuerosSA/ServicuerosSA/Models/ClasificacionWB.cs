using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ServicuerosSA.Models
{
    public class ClasificacionWB
    {
        public int ClasificacionwbId { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroPieles { get; set; }
        public string Observaciones { get; set; }
        public bool Activo { get; set; }
        public string codigolote { get; set; }
        public int bombo { get; set; }
        public string codiuniWb { get; set; }
        //relaciones
        public int BodegaId { get; set; }
        public Bodega bodega { get; set; }
        public int PersonalId { get; set; }
        public Personal personal { get; set; }
        //public int ClasificacionId { get; set; }
        //public Clasificacion clasificacion { get; set; }
        
        
        public int clasiwebId { get; set; }
        public Clasiweb clasiweb { get; set; }
        public int EscurridoId { get; set; }
        public Escurrido escurrido { get; set; }





    }
}
