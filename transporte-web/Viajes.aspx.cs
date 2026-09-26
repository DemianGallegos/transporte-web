using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace transporte_web
{
    public partial class Viajes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ViajeDisponible> lista = (List<ViajeDisponible>)Session["listaViajeDisponible"];

            try
            {
                if (!IsPostBack)
                {

                    lblCiudadOrigen.Text = lista[0].CiudadOrigen;
                    lblCiudadDestino.Text = lista[0].CiudadDestino;

                    string fechaSalida = DateTime.Now.ToString("dddd d 'de' MMMM");
                    lblFechaSalida.Text = char.ToUpper(fechaSalida[0]) + fechaSalida.Substring(1);
                    //lblFechaSalida.Text = lista[0].FechaSalida.ToString("dddd d 'de' MMMM");

                    repRepetidor.DataSource = lista;
                    repRepetidor.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected string formatearDuracion(object duracion)
        {
            int minutos = (int)duracion;
            int horas = minutos / 60;
            int mins = minutos % 60;

            return $"{horas} hs {mins} min";
        }

        protected string calcularHoraLlegada(object horaSalida, object duracion)
        {
            TimeSpan hora = (TimeSpan)horaSalida;
            TimeSpan dur = TimeSpan.FromMinutes((int)duracion);

            return (hora + dur).ToString(@"hh\:mm");
        }

        protected void btnElegir_Command(object sender, CommandEventArgs e)
        {
            int idViaje = int.Parse(e.CommandArgument.ToString());
            Response.Redirect("Asientos.aspx?idViaje=" + idViaje);

        }
    }
}
