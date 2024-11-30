using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGrupo15Progra3
{
    public partial class ActualizarContrasenia : System.Web.UI.Page
    {

        public string mailRecuperacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emailRecuperacion"].ToString()!=null)
            {
                mailRecuperacion = Session["emailRecuperacion"].ToString();
            }

        }

        protected void btnActualizarPasword_Click(object sender, EventArgs e)
        {
            try
            {
               UsuarioService contrasenia = new UsuarioService();
               
                
                contrasenia.actualizarContrasenia(TxtContraseniaPin.Text, TxtActualizarContrasenia.Text, mailRecuperacion);
                
                lblMessage.Text = "Contraseña actualiza con exito";
                 
                Response.AddHeader("REFRESH", "3;URL=Login.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}