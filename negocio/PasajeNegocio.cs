using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class PasajeNegocio
    {
        public void insertarPasaje(Pasaje nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("spInsertarPasaje");
                datos.setearParametro("@idViaje", nuevo.Viaje.Id);
                datos.setearParametro("@idAsiento", nuevo.Asiento.Id);
                datos.setearParametro("@idPasajero", nuevo.Pasajero.Id);
                datos.setearParametro("@idCompra", nuevo.Compra.Id);
                datos.setearParametro("@precioPagado", nuevo.PrecioPagado);

                datos.ejecutarAccion();
            }

            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }
        }
    }
} 