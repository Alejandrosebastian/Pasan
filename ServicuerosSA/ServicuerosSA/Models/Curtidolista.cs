using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class Curtidolista
    {
        public int curtidoId { get; set; }
        public DateTime Fecha { get; set; }
        public int Peso { get; set; }
        public string Observaciones { get; set; }
        public decimal NPieles { get; set; }
        public string codicurtido { get; set; }
        public bool Activo { get; set; }
        public string codigolote { get; set; }
        //RELACIONES
        public int FormulaId { get; set; }
      
        public int PersonalId { get; set; }
       
        //public int ClasificacionTripaId  { get; set; }
        //public ClasificacionTripa ClasificacionTripa { get; set; }
        public int BodegaTripaId { get; set; }
        
        public int MedidaId { get; set; }
        
        public int BomboId { get; set; }
       
        public int BodegaId { get; set; }
     
    }
}
