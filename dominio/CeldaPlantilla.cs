using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class CeldaPlantilla
    {
        public int Id { get; set;}   // Id de la tabla Celdas 
        public int Fila { get; set; }
        public int Columna { get; set; }
        public int Piso { get; set; }
        public string Codigo { get; set; }
        public int IdAsiento { get; set; }    
        public int NumeroAsiento { get; set; }
        public string AsientoTipo { get; set; }
        public decimal Incremento { get; set; }
        public bool Ocupado { get; set; }


    }
}
