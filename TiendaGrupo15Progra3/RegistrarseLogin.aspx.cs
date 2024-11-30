using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TiendaGrupo15Progra3
{
    public partial class RegistrarseLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Revisada: Ok. Se agregael mail para evitar conflictos de nombres iguales
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            string Nombre;
            string Apellido;
            string Username;
            string Clave;
            string RepetirClave;
            string Email;
            string Telefono;
            bool TieneEspacioBlancoNull = false;

            if (string.IsNullOrWhiteSpace(nombreText.Text) ||
                string.IsNullOrWhiteSpace(apellidoText.Text) ||
                string.IsNullOrWhiteSpace(TextNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(TxtClave.Text) ||
                string.IsNullOrWhiteSpace(TxtRepetirClave.Text) ||
                string.IsNullOrWhiteSpace(EmailInput.Text) ||
                string.IsNullOrWhiteSpace(TxtTelefono.Text))
            {
                fGlobales.MostrarAlerta(this, "Todos los campos deben estar completos.");
                return;
            }
            else
            {
                if (int.Parse(TxtTelefono.Text) > 0)
                {
                    Nombre = nombreText.Text.Trim();
                    Apellido = apellidoText.Text.Trim();
                    Username = TextNombreUsuario.Text.Trim();
                    Clave = TxtClave.Text.Trim();
                    RepetirClave = TxtRepetirClave.Text.Trim();
                    Email = EmailInput.Text.Trim();
                    Telefono = TxtTelefono.Text.Trim();
                    TieneEspacioBlancoNull = true;
                }
                else 
                {
                    fGlobales.MostrarAlerta(this, "El telefono no puede ser un numero negativo.");
                    return;
                }
            }
            UsuarioService usuarioService = new UsuarioService();
            bool confirmarContraseniaBool = false;
            bool UsuarioPrimeraVez = false;

            try
            {

                if (Clave == RepetirClave)
                {
                    confirmarContraseniaBool = true;
                }
                UsuarioPrimeraVez = usuarioService.NoExisteUsuario(Email);

                if (UsuarioPrimeraVez == true && confirmarContraseniaBool == true && TieneEspacioBlancoNull==true)
                {
                    Usuario nuevoUsuario = new Usuario();

                    nuevoUsuario.nombre = Nombre;
                    nuevoUsuario.apellido = Apellido;
                    nuevoUsuario.nombreUsuario = Username;
                    nuevoUsuario.clave = Clave;
                    nuevoUsuario.correo = Email;
                    nuevoUsuario.telefono = Telefono;
                    nuevoUsuario.rol = 2;

                    usuarioService.RegistrarUsuario(nuevoUsuario);
                    Session["Rol"] = 2;
                    string script = "alert('Se ha creado con exito su usuario'); window.location='RegistrarseLogin.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
                    Session["Usuario"] = usuarioService.LoginUsuarioYcontraseniaDevuelveUsuario(nuevoUsuario.nombreUsuario, nuevoUsuario.clave);
                    
                   // 
                    Response.Redirect("/Default.aspx",false);
                    //Context.ApplicationInstance.CompleteRequest();
                  //

                }
                else if( confirmarContraseniaBool == false )
                {
                    fGlobales.MostrarAlerta(this,"Ocurrió un error:Las contraseñas no coinciden");

                } else if (UsuarioPrimeraVez == false)
                {
                    fGlobales.MostrarAlerta(this, "Ocurrió un error:El mail ya se encuentra registrado, si olvido su contraseña puede recuperarla en Login");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Registrar Cliente (RegistrarseLogin) Linea 68 " + ex.Message);
            }
          
           
        }

        protected void CancelarClickButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx",false);
        }
    }
}