using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class MicroModelo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public Plantilla Plantilla { get; set; }
    }
}
