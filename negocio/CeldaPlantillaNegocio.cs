using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CeldaPlantillaNegocio
    {
        public List<CeldaPlantilla> listarCeldasConSP(int IdViaje)
        {
            List<CeldaPlantilla> lista = new List<CeldaPlantilla>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("spCeldasPlantillaListar");
                datos.setearParametro("@IdViaje", IdViaje);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    CeldaPlantilla aux = new CeldaPlantilla();  

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Fila = (int)datos.Lector["Fila"];
                    aux.Columna = (int)datos.Lector["Columna"];
                    aux.Piso = (int)datos.Lector["Piso"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    if(!(datos.Lector["IdAsiento"] is DBNull))
                        aux.IdAsiento = (int)datos.Lector["IdAsiento"];
                    if (!(datos.Lector["NumeroAsiento"] is DBNull))
                        aux.NumeroAsiento = (int)datos.Lector["NumeroAsiento"];
                    if (!(datos.Lector["AsientoTipo"] is DBNull))
                        aux.AsientoTipo = (string)datos.Lector["AsientoTipo"];
                    if (!(datos.Lector["Incremento"] is DBNull))
                        aux.Incremento = (decimal)datos.Lector["Incremento"];
                    aux.Ocupado = Convert.ToBoolean(datos.Lector["Ocupado"]);

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
