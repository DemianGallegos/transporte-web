using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ViajeDisponibleNegocio
    {
         public List<ViajeDisponible> listarDisponiblesConSP(int IdCiudadOrigen, int IdCiudadDestino,
             DateTime FechaSalida, int CantidadPasajeros)

         {         
            List<ViajeDisponible> lista = new List<ViajeDisponible>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("spViajesDisponiblesListar");
                datos.setearParametro("@IdCiudadOrigen", IdCiudadOrigen);
                datos.setearParametro("@IdCiudadDestino", IdCiudadDestino);
                datos.setearParametro("@FechaSalida", FechaSalida);
                datos.setearParametro("@CantidadPasajeros", CantidadPasajeros );

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    ViajeDisponible aux = new ViajeDisponible();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.FechaSalida = (DateTime)datos.Lector["FechaSalida"];
                    aux.HoraSalida = (TimeSpan)datos.Lector["HoraSalida"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Duracion = (int)datos.Lector["Duracion"];
                    aux.CiudadOrigen = (string)datos.Lector["CiudadOrigen"];
                    aux.CiudadDestino = (string)datos.Lector["CiudadDestino"];
                    aux.AsientosDisponibles = (int)datos.Lector["AsientosDisponibles"];

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
