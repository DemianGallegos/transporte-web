using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Micro
    {
        public int Id { get; set; }
        public int NumeroInterno { get; set; }
        public MicroModelo Modelo { get; set; } 

        public string Patente { get; set;}
    }
}
