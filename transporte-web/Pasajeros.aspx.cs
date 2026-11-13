using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace transporte_web
{
    public partial class Pasajeros : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

            List<Pasajero> listaPasajeros = new List<Pasajero>();
            //acá validar que no traiga un null el metodo listar();


            if (!IsPostBack)
            {
                try
                {
                    listaPasajeros = listar();

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

        protected void Continuar_Click(object sender, EventArgs e)
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
                aux.Tipo.Nombre = ddlDocumentoTipo.SelectedValue;
                TextBox txtDocumentoNumero = (TextBox)item.FindControl("txtDocumentoNumero");
                aux.DocumentoNumero = txtDocumentoNumero.Text;
                DropDownList ddlNacionalidad = (DropDownList)item.FindControl("ddlNacionalidad");
                aux.Nacionalidad = new Nacionalidad();
                aux.Nacionalidad.Descripcion = ddlNacionalidad.SelectedValue;

                TextBox txtFechaNacimiento = (TextBox)item.FindControl("txtFechaNacimiento");
                aux.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                DropDownList ddlGenero = (DropDownList)item.FindControl("ddlGenero");
                aux.Genero = (Genero)int.Parse(ddlGenero.SelectedValue);

                TextBox txtEmail = (TextBox)item.FindControl("txtEmail");
                aux.Email = txtEmail.Text;
                DropDownList ddlPrefijo = (DropDownList)item.FindControl("ddlPrefijo");
                aux.Prefijo = new PrefijoTelefonico();
                aux.Prefijo.Codigo = ddlPrefijo.SelectedValue;
                TextBox txtTelefono = (TextBox)item.FindControl("txtTelefono");
                aux.TelefonoNumero = txtTelefono.Text;





                // Capturar la valores de todos los controles. son las propiedades de aux que
                // quedaron en null cuando cree la lista

            }
        }
    }
}