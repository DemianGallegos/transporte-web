using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pasaje
    {
        public int Id { get; set; }
        public int NumeroPasaje { get; set; }
        public ViajeDisponible Viaje { get; set; }
        public Asiento Asiento { get; set; }
        public Pasajero Pasajero { get; set; }
        public Compra Compra { get; set; }
        public decimal PrecioPagado { get; set; }
    }
}
