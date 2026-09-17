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
            List<ViajeDisponible> listaViajeDisponible = (List<ViajeDisponible>)Session["listaViajeDisponible"];
            //ViajeDisponibleNegocio negocio = new ViajeDisponibleNegocio();
            try
            {
                if (!IsPostBack)
                {
                    repRepetidor.DataSource = listaViajeDisponible;
                    repRepetidor.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}