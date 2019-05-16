using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class EscurriList
    {
        public int escurridoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoLote { get; set; }
        public bool Activo { get; set; }
        public string codiuniescurridio { get; set; }
        //RELACIONES
        public int BomboId { get; set; }
        public Bombo Bombos { get; set; }
        public int CurtidoId { get; set; }
        public Curtido Curtido { get; set; }
        public int PersonalId { get; set; }
        public Personal personal { get; set; }
    }
}
