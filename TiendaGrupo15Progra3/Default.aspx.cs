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
    public partial class Default : System.Web.UI.Page
    {
        public int RolDefault;
        public Usuario UsuarioDefault= new Usuario();
      

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Rol"] != null)
                {
                    RolDefault = int.Parse(Session["Rol"].ToString());
                }
               else
                {
                    RolDefault = 0;
                }
                if (Session["Usuario"] != null) 
                {   

                    UsuarioDefault =(Usuario)Session["Usuario"];
                } else
                {
                    UsuarioDefault.nombre = "Anónimo";
                    UsuarioDefault.apellido = "   ";
                }
                if (UsuarioDefault.nombre == null)
                {
                    UsuarioDefault.nombre = "Usuario";
                }
                if (UsuarioDefault.apellido == null)
                {
                    UsuarioDefault.apellido = "Sin Registro Completo, porfavor complete la solapa mi perfil.";
                }
            }
            catch (Exception ex)
            {
               throw new Exception("Error de Sesion" + ex.Message);
            }
            
        }

        protected void btnParticipa_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ElegirProducto.aspx");
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Rol"] = null;
            Session["Usuario"] = null;
            RolDefault = 0;
            UsuarioDefault.nombre = "Anónimo";
            UsuarioDefault.apellido = " Usuario no logueado";
            Session["Usuario"] = null;
            fGlobales.MostrarAlerta(this, "Ha cerrado sesión.");
        }
    }
}