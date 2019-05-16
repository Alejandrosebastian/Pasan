using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class datosmedido
    {
        public string detalle { get; set; }
        public DateTime fecha { get; set; }
        public int cantidad { get; set; }
        public int bombo { get; set; }
        public string tipo { get; set; }
    }
}
