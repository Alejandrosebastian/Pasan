using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class ListaEscurridoCheck
    {
        public int escurridoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoLote { get; set; }
       
       
        //RELACIONES
        public int BomboId { get; set; }
       
        public int CurtidoId { get; set; }
      
        public int PersonalId { get; set; }
        
    }
}
