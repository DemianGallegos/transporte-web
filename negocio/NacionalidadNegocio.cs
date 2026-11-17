using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class NacionalidadNegocio
    {
        public List<Nacionalidad> listar()
        {
            List<Nacionalidad> lista = new List<Nacionalidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Descripcion From Nacionalidades");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Nacionalidad aux = new Nacionalidad();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
