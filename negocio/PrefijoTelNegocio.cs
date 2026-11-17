using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class PrefijoTelNegocio
    {
        public List<PrefijoTel> listar()
        {
            List<PrefijoTel> lista = new List<PrefijoTel>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Codigo, Pais From PrefijosTel");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    PrefijoTel aux = new PrefijoTel();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Pais = (string)datos.Lector["Pais"];

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
