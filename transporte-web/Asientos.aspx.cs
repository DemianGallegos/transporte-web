using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace transporte_web
{
    public partial class Asientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if para que no se pinche por carga accidental, etc


            int idViaje = int.Parse(Request.QueryString["idViaje"].ToString());

            //Primero recupero la plantilla de ese viaje.
            //Luego pareceria mas razonable un metodo celdaNegocio para construir la plantilla
            //y otro para fijarme en esa plantilla cuales estan ocupados y cuales no.
            //y recien ahi le muestro al usuario

            //YO CREO QUE HAY QUE hay que agregar un dato mas en la consulta que empieza en
            //default, ese dato seria la plantilla que corresponde a ese micro de ese viaje.
            //Luego guardada en la session listaViajesDisponible, buscar el lugar (ejemplo [2]
            //) donde esté el Id del Viaje y el Id de la Plantilla coincidan y listo
            //analizarlo

        }
    }
}