using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace transporte_web
{
    public partial class Pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                Compra compra = new Compra();
                CompraNegocio compraNegocio = new CompraNegocio();

                compra.TotalCompra = decimal.Parse(Session["Total"].ToString());
                int IdCompra = compraNegocio.insertarCompra(compra);

                List<Pasajero> listaPasajeros = (List<Pasajero>)Session["ListaPasajeros"];
                PasajeroNegocio pasajeroNegocio = new PasajeroNegocio();

                PasajeNegocio pasajeNegocio = new PasajeNegocio(); // este afuera. no hace falta cada vez que itere el ciclo

                int[] idAsiento = (int[])Session["idsAsientos"];
                decimal[] incrementoAsiento = (decimal[])Session["IncrementosAsientos"];

                ViajeDisponible seleccionado = (ViajeDisponible)Session["viajeSeleccionado"];
                decimal precioBase = seleccionado.Precio;

                int x = 0;

                foreach (Pasajero pasajero in listaPasajeros)
                {
                    int IdPasajero = pasajeroNegocio.insertarPasajero(pasajero);

                    pasajero.IdAsiento = idAsiento[x];
                    pasajero.IncrementoAsiento = incrementoAsiento[x];
                    decimal incremento = pasajero.IncrementoAsiento;

                    
                    Pasaje pasaje = new Pasaje();

                    // NUMERO PASAJE ???? de donde lo saco o como se genera? habia pensado un auto incremental
                    // ese autoincremental podria empezar en una cifra determinada o no?

                    pasaje.Viaje = new ViajeDisponible();
                    pasaje.Viaje.Id = seleccionado.Id;
                    pasaje.Asiento = new Asiento();
                    pasaje.Asiento.Id = pasajero.IdAsiento;
                    pasaje.Pasajero = new Pasajero();
                    pasaje.Pasajero.Id = IdPasajero;
                    pasaje.Compra = new Compra();
                    pasaje.Compra.Id = IdCompra;
                    pasaje.PrecioPagado = precioBase * incremento;

                    pasajeNegocio.insertarPasaje(pasaje);

                    x++;
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }


    }
}