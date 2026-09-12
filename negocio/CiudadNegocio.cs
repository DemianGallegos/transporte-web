using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CiudadNegocio
    {
        public List<Ciudad> listar()
        {
            List<Ciudad> lista = new List<Ciudad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Nombre From Ciudades");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Ciudad aux = new Ciudad();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

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
