using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class Medido
    {
        public int MedidoId { get; set; }
        public string Codigolote { get; set; }
        
        public int BodegaId { get; set; }
        public Bodega bodega { get; set; }
        public int PersonalId { get; set; }
        public Personal personal { get; set; }
        public int Cantidad { get; set; }
        public string Pallet { get; set; }
        public decimal Area { get; set; }
        public DateTime Fecha { get; set; }
        public bool activo { get; set; }
        public int estanteria { get; set; }
        public string tipotri { get; set; }
        public string tipoweb { get; set; }
        public string  codiunimedido { get; set; }
        public int CalibracionId { get; set; }
        public Calibracion Calibracion { get; set; }



    }
}
