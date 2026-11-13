using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pasajero
    {
        public int Id { get; set; }
        public int OrdenPasajero { get; set; }
        public int IdAsiento { get; set; }
        public int NumeroAsiento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DocumentoTipo Tipo { get; set; }
        public string DocumentoNumero { get; set; }
        public Nacionalidad Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Genero Genero { get; set; } // es un enum
        public string Email { get; set; }
        public PrefijoTelefonico Prefijo { get; set; }
        public string TelefonoNumero { get; set; }
        
        //public PasajeroTipo Tipo { get; set; } Esto se va
        //public Pasajero Tutor { get; set; } Esto se va también
    }
}
