using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class PrefijoTel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Pais { get; set; }
        public string Descripcion
        {
            get { return Pais + "("+ Codigo +")"; }
        }
    }
}
