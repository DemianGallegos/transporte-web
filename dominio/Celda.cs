using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Celda
    {
        public int Id { get; set; }
        public Plantilla Plantilla { get; set; }
        public int Piso { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public CeldaTipo Tipo { get; set; }

    }
}
