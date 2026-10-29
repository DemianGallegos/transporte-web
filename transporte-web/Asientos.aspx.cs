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
    public partial class Asientos : System.Web.UI.Page
    {
        protected decimal precio;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ViajeDisponible> listaViajes = (List<ViajeDisponible>)Session["listaViajeDisponible"];

            int idViaje = int.Parse(Request.QueryString["idViaje"].ToString());
            CeldaPlantillaNegocio negocio = new CeldaPlantillaNegocio();

            if (!IsPostBack)
            {
                try
                {
                    precio = listaViajes[0].Precio;

                    lblFechaSalida.Text = listaViajes[0].FechaSalida.ToString("dddd d 'de' MMMM");
                    lblHoraSalida.Text = listaViajes[0].HoraSalida.ToString(@"hh\:mm");
                    lblCiudadOrigen.Text = listaViajes[0].CiudadOrigen;
                    lblHoraLlegada.Text = calcularHoraLlegada(listaViajes[0].HoraSalida, listaViajes[0].Duracion);
                    lblCiudadDestino.Text = listaViajes[0].CiudadDestino;
                    //int cantPasajeros = (int)Session["cantidadPasajeros"];
                    //lblCantPasajeros.Text = cantPasajeros.ToString();

                    lblSubtotal.Text = "AR$ 0";

                    List<CeldaPlantilla> listaCeldasPlantilla = negocio.listarCeldasConSP(idViaje);
                    Session["listaCeldasPlantilla"] = listaCeldasPlantilla;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            List<CeldaPlantilla> listaPlantilla = (List<CeldaPlantilla>)Session["listaCeldasPlantilla"];
            dibujarPlantilla(listaPlantilla, 1, tblPisoSuperior);
            dibujarPlantilla(listaPlantilla, 2, tblPisoInferior);

        }

        protected void dibujarPlantilla(List<CeldaPlantilla> lista, int piso,
            System.Web.UI.WebControls.Table tabla)
        {
            tabla.CssClass = "plano-piso";

            List<CeldaPlantilla> celdasPiso = lista.Where(c => c.Piso == piso).ToList();
            if (celdasPiso.Count == 0)
                return;

            int numrows = celdasPiso.Max(c => c.Fila);      // fila máxima
            int numcells = celdasPiso.Max(c => c.Columna);  // columna máxima 

            for (int j = 1; j <= numrows; j++)
            {
                TableRow r = new TableRow();
                for (int i = 1; i <= numcells; i++)
                {
                    CeldaPlantilla celda = lista.FirstOrDefault(c => c.Fila == j && c.Columna == i && c.Piso == piso);
                    TableCell tc = new TableCell();
                    
                    if(celda != null)
                    {
                        switch (celda.Codigo)
                        {
                            case "A":
                                if (celda.Ocupado)
                                {
                                    //tc.CssClass
                                    tc.CssClass = "asiento-ocupado";
                                    tc.Text = celda.NumeroAsiento.ToString();
                                }
                                else
                                {
                                    tc.CssClass = celda.AsientoTipo == "Cama" ? "asiento-cama" : "asiento-libre";
                                    tc.Text = celda.NumeroAsiento.ToString();
                                    tc.Attributes.Add("data-id-asiento", celda.IdAsiento.ToString());
                                    tc.Attributes.Add("data-tipo-asiento", celda.AsientoTipo);
                                    tc.Attributes.Add("data-incremento", celda.Incremento.ToString(
                                        System.Globalization.CultureInfo.InvariantCulture));
                                    tc.Attributes.Add("onclick", $"seleccionarAsiento(this, {celda.IdAsiento})");
                                }

                                break;

                            case "P":
                                tc.CssClass = "pasillo";
                                break;

                            default:
                                // E, W, B y cualquier otro especial
                                tc.Text = celda.Codigo;
                                tc.CssClass = "celda-especial";
                                break;
                        }
                        
                    }
                    r.Cells.Add(tc);

                }
                tabla.Rows.Add(r);

            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            string idsAsientos = hdnIdAsiento.Value;
            int cant = (int)Session["cantidadPasajeros"];

            if(string.IsNullOrEmpty(idsAsientos))
            {
                Response.Write("<script>alert('Seleccioná al menos un asiento.');</script>");
                return;
            }
            
            int cantidadSeleccionados = idsAsientos.Split(',').Length;

            if (cantidadSeleccionados < cant)
            {
                Response.Write($"<script>alert('Debés seleccionar {cant} asientos.');</script>");
                return;
            }

            Session["IdsAsientos"] = idsAsientos;
            Response.Redirect("Pasajes.aspx", false);

        }
        protected string calcularHoraLlegada(object horaSalida, object duracion)
        {
            TimeSpan hora = (TimeSpan)horaSalida;
            TimeSpan dur = TimeSpan.FromMinutes((int)duracion);

            return (hora + dur).ToString(@"hh\:mm");
        }
    }
}