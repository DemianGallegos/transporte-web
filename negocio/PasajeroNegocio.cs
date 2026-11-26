using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class PasajeroNegocio
    {
        public int insertarPasajero(Pasajero nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("spInsertarPasajero"); 
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@idDocumentoTipo", nuevo.Tipo);
                datos.setearParametro("@documentoNumero", nuevo.DocumentoNumero);
                datos.setearParametro("@idNacionalidad", nuevo.Nacionalidad.Id);
                datos.setearParametro("@fechaNacimiento", nuevo.FechaNacimiento);
                datos.setearParametro("@idGenero", nuevo.Genero);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@idPrefijoTel", nuevo.Prefijo.Id);
                datos.setearParametro("@telefonoNumero", nuevo.TelefonoNumero);

                return datos.ejecutarAccionScalar();
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
