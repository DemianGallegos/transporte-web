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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idViaje = int.Parse(Request.QueryString["idViaje"].ToString());
                CeldaPlantillaNegocio negocio = new CeldaPlantillaNegocio();

                try
                {
                    List<CeldaPlantilla> listaCeldasPlantilla = negocio.listarCeldasConSP(idViaje);

                    dibujarPlantilla(listaCeldasPlantilla, 1, tblPisoSuperior);
                    dibujarPlantilla(listaCeldasPlantilla, 2, tblPisoInferior);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

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
                                    tc.CssClass = "asiento-libre";
                                    tc.Text = celda.NumeroAsiento.ToString();
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
    }
}