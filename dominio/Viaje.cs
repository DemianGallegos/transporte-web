using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Viaje
    {
        public int Id { get; set; }
        public int NumeroServicio { get; set; }
        public Ruta Ruta { get; set; }
        public ViajeEstado Estado { get; set; }
        public Micro Micro { get; set; }
        public DateTime FechaSalida { get; set; }
        public TimeSpan HoraSalida { get; set; }
    }
}
