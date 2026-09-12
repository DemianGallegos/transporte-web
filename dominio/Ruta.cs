using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Ruta
    {
        public int Id { get; set; }

        public Ciudad CiudadOrigen { get; set; }

        public Ciudad CiudadDestino { get; set; }

        public int KmsDistancia { get; set;  } //   Modificar nombre del dato en DB

        public int MinsDuracion { get; set; } //   Modificar nombre del dato 

        public decimal Precio { get; set; }
    }
}
