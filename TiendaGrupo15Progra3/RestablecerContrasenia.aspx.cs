using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGrupo15Progra3
{
    public partial class RestablecerContrasenia : System.Web.UI.Page
    {
      

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnRestablecerPasword_Click(object sender, EventArgs e)
        {
            EmailService emailService = new EmailService();
            

            string enviarContraseniaNueva = null;

            try
            {
                enviarContraseniaNueva = emailService.ExisteMail(TxtEmail.Text);


                if (enviarContraseniaNueva!=null)
                {
                    string email = TxtEmail.Text;

                    Session.Add("emailRecuperacion", email);

                    

                    emailService.armarMail(email, "Restablecimiento de Contraseña", "Su contrasenia Pin es la siguiente: " + enviarContraseniaNueva);
                    emailService.enviarEmail();                  
        
                   
                    Response.Redirect("ActualizarContrasenia.aspx",false);        
                }
                else
                {
                    fGlobales.MostrarAlerta(this, "El mail ingresado no se encuentra registrado, registrese");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("error btnRestablecer Contraseña" + ex.Message);
            }

        }
    }
}