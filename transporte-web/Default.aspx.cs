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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CiudadNegocio negocioCiudad = new CiudadNegocio();
            try
            {
                if (!IsPostBack)
                {
                    List<Ciudad> listaCiudades = negocioCiudad.listar();

                    ddlCiudadOrigen.DataSource = listaCiudades;
                    ddlCiudadOrigen.DataTextField = "Nombre";
                    ddlCiudadOrigen.DataValueField = "Id";
                    ddlCiudadOrigen.DataBind();

                    ddlCiudadDestino.DataSource = listaCiudades;
                    ddlCiudadDestino.DataTextField = "Nombre";
                    ddlCiudadDestino.DataValueField = "Id";
                    ddlCiudadDestino.DataBind();
                }
                    
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ViajeDisponibleNegocio negocio = new ViajeDisponibleNegocio();
            List<ViajeDisponible> listaViajeDisponible = negocio.listarDisponiblesConSP(
                int.Parse(ddlCiudadOrigen.SelectedValue),
                int.Parse(ddlCiudadDestino.SelectedValue),
                DateTime.Parse(txtFechaIda.Text),
                int.Parse(txtPasajeros.Value));

            Session["listaViajeDisponible"] = listaViajeDisponible;
            Response.Redirect("Viajes.aspx", false);
        }
    }
}