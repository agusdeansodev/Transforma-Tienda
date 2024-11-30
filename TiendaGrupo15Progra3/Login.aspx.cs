using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGrupo15Progra3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        int RolTraido {  get; set; }    

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loMandamosLogin"] != null)
            {
                bool VieneDeAlgunLado = (bool)Session["loMandamosLogin"];

                if (VieneDeAlgunLado==true)
                {
                    fGlobales.MostrarAlerta(this, "Para Ver Productos Comprados, Vendidos y en Proceso, y demas acciones se requiere estar logueado.");
                    Session["loMandamosLogin"] = false;
                }
            }


        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
         
            string usuario = LoginTextUsuario.Text;
            string contrasenia = LoginTextContrasenia.Text;
            UsuarioService usuarioService = new UsuarioService();

            if (usuarioService.LoginSoloUsuarioYcontrasenia(usuario,contrasenia)==2)
            {
                Session["Rol"]=2;
                Session["Usuario"] = usuarioService.LoginUsuarioYcontraseniaDevuelveUsuario(usuario,contrasenia);
                Response.Redirect("Default.aspx");
                
               
            }
            else if(usuarioService.LoginSoloUsuarioYcontrasenia(usuario,contrasenia)==1)
            {
                Session["Rol"] = 1;
                Session["Usuario"] = usuarioService.LoginUsuarioYcontraseniaDevuelveUsuario(usuario, contrasenia);
                Response.Redirect("Default.aspx");
                
            }
            else
            {
                fGlobales.MostrarAlerta(this, "Los Datos ingresados no son correctos.");
            }


        }
    }
}