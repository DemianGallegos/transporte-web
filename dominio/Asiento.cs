using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Asiento
    {
        public int Id { get; set; }
        public int NumeroAsiento { get; set; }
        public AsientoTipo Tipo { get; set; }
        public decimal Incremento { get; set; }
    }
}
