using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class BodegaCarnaza
    {
        public int  BodegaCarnazaId { get; set; }
        public decimal Cantidad { get; set; }
        public string Codigo { get; set; }
        //Relaciones
        public int BodegaTripaId { get; set; }
        public Bodegatripa Bodegatripas { get; set; }
        public int BodegaId { get; set; }
        public Bodega BodegaGeneral { get; set; }
    }
}
