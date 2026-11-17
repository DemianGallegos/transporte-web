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
    public partial class Pasajeros : System.Web.UI.Page
    {
        private List<Nacionalidad> listaNacionalidades;
        private List<PrefijoTel> listaPrefijosTel;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Pasajero> listaPasajeros = new List<Pasajero>();
            //acá validar que no traiga un null el metodo listar();

            if (!IsPostBack)
            {
                try
                {
                    cargarNacionalidades();
                    cargarPrefijosTel();
                    
                    cargarResumen();

                    listaPasajeros = listar();


                    // AGRGREGAR Método cargarResumen (La lista de afuera, arriba )


                    Session["ListaPasajeros"] = listaPasajeros;

                    repRepetidor.DataSource = listaPasajeros;
                    repRepetidor.DataBind();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        }

        public List<Pasajero> listar()
        {
            int[] idsAsientos = (int[])Session["IdsAsientos"];
            int[] numerosAsientos = (int[])Session["NumerosAsientos"];

            if (idsAsientos == null || numerosAsientos == null)
            {
                Response.Redirect("Asientos.aspx", false);
                return null;
            }

            if (idsAsientos.Length != numerosAsientos.Length)
            {
                // Redirigir a Asientos.aspx
                return null;
            }

            int cantidad = idsAsientos.Length;

            List<Pasajero> lista = new List<Pasajero>();

            for (int i = 0; i < cantidad; i++)
            {
                Pasajero aux = new Pasajero();
                aux.NumeroAsiento = numerosAsientos[i];
                aux.IdAsiento = idsAsientos[i];
                aux.OrdenPasajero = i + 1;


                lista.Add(aux);
            }

            return lista;
        }
        private void cargarNacionalidades()
        {
            NacionalidadNegocio nacionalidadNegocio = new NacionalidadNegocio();

            listaNacionalidades = nacionalidadNegocio.listar();

        }

        private void cargarPrefijosTel()
        {
            PrefijoTelNegocio prefijoTelNegocio = new PrefijoTelNegocio();

            listaPrefijosTel = prefijoTelNegocio.listar();
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            List<Pasajero> listaPasajeros = (List<Pasajero>)Session["ListaPasajeros"];

            foreach (RepeaterItem item in repRepetidor.Items)
            {

                Pasajero aux = listaPasajeros[item.ItemIndex];

                TextBox txtNombre = (TextBox)item.FindControl("txtNombre");
                aux.Nombre = txtNombre.Text;
                TextBox txtApellido = (TextBox)item.FindControl("txtApellido");
                aux.Apellido = txtApellido.Text;

                DropDownList ddlDocumentoTipo = (DropDownList)item.FindControl("ddlDocumentoTipo");
                aux.Tipo = new DocumentoTipo();
                aux.Tipo = (DocumentoTipo)int.Parse(ddlDocumentoTipo.SelectedValue);

                TextBox txtDocumentoNumero = (TextBox)item.FindControl("txtDocumentoNumero");
                aux.DocumentoNumero = txtDocumentoNumero.Text;

                DropDownList ddlNacionalidad = (DropDownList)item.FindControl("ddlNacionalidad");
                aux.Nacionalidad = new Nacionalidad();
                aux.Nacionalidad.Id = int.Parse(ddlNacionalidad.SelectedValue);

                TextBox txtFechaNacimiento = (TextBox)item.FindControl("txtFechaNacimiento");
                aux.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                DropDownList ddlGenero = (DropDownList)item.FindControl("ddlGenero");
                aux.Genero = (Genero)int.Parse(ddlGenero.SelectedValue);

                TextBox txtEmail = (TextBox)item.FindControl("txtEmail");
                aux.Email = txtEmail.Text;

                DropDownList ddlPrefijoTel = (DropDownList)item.FindControl("ddlPrefijoTel");
                aux.Prefijo = new PrefijoTel();
                aux.Prefijo.Id = int.Parse(ddlPrefijoTel.SelectedValue);

                TextBox txtTelefono = (TextBox)item.FindControl("txtTelefono");
                aux.TelefonoNumero = txtTelefono.Text;

            }
        }

        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                    e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlDocumentoTipo = (DropDownList)e.Item.FindControl("ddlDocumentoTipo");
                ddlDocumentoTipo.Items.Add(new ListItem("DNI", "1"));
                ddlDocumentoTipo.Items.Add(new ListItem("Pasaporte", "2"));
                ddlDocumentoTipo.Items.Add(new ListItem("Cédula", "3"));

                DropDownList ddlGenero = (DropDownList)e.Item.FindControl("ddlGenero");
                ddlGenero.Items.Add(new ListItem("Seleccionar", "0"));
                ddlGenero.Items.Add(new ListItem("Masculino", "1"));
                ddlGenero.Items.Add(new ListItem("Femenino", "2"));
                ddlGenero.Items.Add(new ListItem("Otro", "3"));

                DropDownList ddlNacionalidad = (DropDownList)e.Item.FindControl("ddlNacionalidad");
                ddlNacionalidad.DataSource = listaNacionalidades;
                ddlNacionalidad.DataValueField = "Id";
                ddlNacionalidad.DataTextField = "Descripcion";
                ddlNacionalidad.DataBind();

                DropDownList ddlPrefijoTel = (DropDownList)e.Item.FindControl("ddlPrefijoTel");
                ddlPrefijoTel.DataSource = listaPrefijosTel;
                ddlPrefijoTel.DataValueField = "Id";
                ddlPrefijoTel.DataTextField = "Descripcion";
                ddlPrefijoTel.DataBind();


            }
        }

        protected void cargarResumen()
        {
            ViajeDisponible seleccionado = (ViajeDisponible)Session["viajeSeleccionado"];

            lblFechaSalida.Text = seleccionado.FechaSalida.ToString("dddd d 'de' MMMM");
            lblHoraSalida.Text = seleccionado.HoraSalida.ToString(@"hh\:mm");
            lblCiudadOrigen.Text = seleccionado.CiudadOrigen;
            lblHoraLlegada.Text = calcularHoraLlegada(seleccionado.HoraSalida, seleccionado.Duracion);
            lblCiudadDestino.Text = seleccionado.CiudadDestino;
        }

        protected string calcularHoraLlegada(object horaSalida, object duracion)
        {
            TimeSpan hora = (TimeSpan)horaSalida;
            TimeSpan dur = TimeSpan.FromMinutes((int)duracion);

            return (hora + dur).ToString(@"hh\:mm");
        }


    }
}