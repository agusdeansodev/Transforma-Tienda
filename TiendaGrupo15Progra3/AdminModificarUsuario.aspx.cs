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
    public partial class AdminModificarUsuario : System.Web.UI.Page
    {
        private bool SoloLetras(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }

        public string ArticuloId { get; set; }
        public Usuario UsuarioIngresaTusDatos = new Usuario();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] != null)
            {

                Usuario usuarioCheck = (Usuario)Session["Usuario"];
                if (usuarioCheck.rol != 1)
                {
                    Response.Redirect("Login.aspx");
                }
                

            }
            else
            {

                
                Session["loMandamosLogin"] = true;
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {


                Usuario usuario = new Usuario();

                UsuarioService usuarioService = new UsuarioService();
                usuario = usuarioService.TraerUsuarioPorId(int.Parse(Session["userId"].ToString()));




                nombreText.Text = usuario.nombre;
                apellidoText.Text = usuario.apellido;
                TextNombreUsuario.Text = usuario.nombreUsuario;

                EmailInput.Text = usuario.correo;

                List<string> list = new List<string>();
                list.Add("Administrador");
                list.Add("Usuario");

                DropDownListRol.DataSource = list;
                DropDownListRol.DataBind();
                TxtTelefono.Text = usuario.telefono;
                nombreText.Enabled = false;
                apellidoText.Enabled = false;
                TextNombreUsuario.Enabled = false;
                EmailInput.Enabled = false;
                TxtTelefono.Enabled = false;




                UsuarioIngresaTusDatos = usuario;
            }
        }

        public void AceptarButton_Click(object sender, EventArgs e)
        {


           
            try
            {
                int rol;
                
                if (DropDownListRol.SelectedValue.ToString() == "Administrador")
                {
                    rol = 1;
                }
                else
                {
                    rol = 2;
                }
                UsuarioService usuarioService = new UsuarioService();
                usuarioService.CambiarRolUsuarioPorId(rol, int.Parse(Session["userId"].ToString()));


                fGlobales.MostrarAlerta(this, "Rol cambiado con exito");



               

                //Response.Redirect("/Default.aspx");

            }

            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }
        protected void CancelarClickButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaDeUsuarios.aspx");
        }
        protected void VolverUsuariosClickButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaDeUsuarios.aspx");
        }
    }
}