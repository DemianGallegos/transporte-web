using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ViajeDisponible
    {
        public int Id { get; set; }
        public DateTime FechaSalida { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public decimal Precio { get; set; }
        public int Duracion { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public int AsientosDisponibles { get; set; }
    }
}
