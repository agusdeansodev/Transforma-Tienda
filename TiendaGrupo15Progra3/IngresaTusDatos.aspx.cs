using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TiendaGrupo15Progra3
{
    public partial class IngresaTusDatos : System.Web.UI.Page
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

                UsuarioIngresaTusDatos = (Usuario)Session["Usuario"];
                
            }
            else
            {   

                UsuarioIngresaTusDatos.nombre = "No se encuentra";
                UsuarioIngresaTusDatos.apellido = "Registrado";
                Session["loMandamosLogin"] = true;
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {

                    UsuarioIngresaTusDatos = (Usuario)Session["Usuario"];
                    nombreText.Text = UsuarioIngresaTusDatos.nombre;
                    apellidoText.Text = UsuarioIngresaTusDatos.apellido;
                    TextNombreUsuario.Text = UsuarioIngresaTusDatos.nombreUsuario;
                    TxtClave.Text = UsuarioIngresaTusDatos.clave;
                    EmailInput.Text = UsuarioIngresaTusDatos.correo;
                    TxtTelefono.Text = UsuarioIngresaTusDatos.telefono;

                }
            }
        }

        public void AceptarButton_Click(object sender, EventArgs e)
        {


            if (!terminosCheckBox.Checked)
            {
                fGlobales.MostrarAlerta(this, "Por favor, acepte los términos y condiciones.");
                return;
            }
            if (string.IsNullOrWhiteSpace(nombreText.Text) ||
                string.IsNullOrWhiteSpace(apellidoText.Text) ||
                string.IsNullOrWhiteSpace(TextNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(TxtClave.Text) ||
                string.IsNullOrWhiteSpace(EmailInput.Text) ||
                string.IsNullOrWhiteSpace(TxtTelefono.Text))
            {
                fGlobales.MostrarAlerta(this, "Todos los campos son obligatorios.");
                return;
            }


            if (!SoloLetras(nombreText.Text.Trim()))
            {
                string script = "alert('El campo \\\"Nombre\\\" solo puede contener letras.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "AlertNombre", script, true);
                return;
            }
            if (!SoloLetras(apellidoText.Text.Trim()))
            {
                string script = "alert('El campo \\\"Apellido\\\" solo puede contener letras.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "AlertApellido", script, true);
                return;
            }


            if (!EmailInput.Text.Contains("@") || !EmailInput.Text.Contains("."))
            {
                fGlobales.MostrarAlerta(this, "Ingrese un correo electrónico válido.");
                return;
            }



          
            if (!long.TryParse(TxtTelefono.Text, out _))
            {
                fGlobales.MostrarAlerta(this, "El número de teléfono debe contener solo números");
                return;
            }


            try
            {
                if (Session["Usuario"] == null)
                {

                    string script = "alert('No se encuentra logueado debe loguearse para actualizar perfil.'); window.location='Login.aspx';"; 
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true); 
                    return; 
                    
                }


                Usuario usuario = new Usuario();
                Usuario usuarioTraidoSession = new Usuario();
                UsuarioService usuarioService = new UsuarioService();

                usuarioTraidoSession = (Usuario)Session["Usuario"];
                if (usuarioService.NoExisteUsuarioSinChequearElmismo(EmailInput.Text.Trim(),usuarioTraidoSession.idUsuario)==false)
                {
                    fGlobales.MostrarAlerta(this, "Ese mail de Usuario ya existe");
                    return;

                }

                usuario.nombre = nombreText.Text.Trim();
                usuario.apellido = apellidoText.Text.Trim();
                usuario.nombreUsuario = TextNombreUsuario.Text.Trim();
                usuario.clave = TxtClave.Text.Trim();
                usuario.correo = EmailInput.Text.Trim();
                usuario.idUsuario = usuarioTraidoSession.idUsuario;
                usuario.rol = 2;
                usuario.telefono = TxtTelefono.Text.Trim();



                usuarioService.ActualizarPerfil(usuario, UsuarioIngresaTusDatos.idUsuario);

                UsuarioIngresaTusDatos = usuario;
               

                

                    fGlobales.MostrarAlerta(this, "Perfil actualizado con exito");

                    Session["Usuario"] = usuarioService.LoginUsuarioYcontraseniaDevuelveUsuario(usuario.nombreUsuario, usuario.clave);

                    //Response.Redirect("/Default.aspx");
                
            }

            catch (Exception ex)
            {
                new Exception("Error al modificar producto:" + ex.Message);

            }
        }
    
        
        protected void CancelarClickButton_Click(object sender, EventArgs e)
        {
            
               
           
            
        }
    }
}