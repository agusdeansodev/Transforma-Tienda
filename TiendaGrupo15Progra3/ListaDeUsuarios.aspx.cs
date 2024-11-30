using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
namespace TiendaGrupo15Progra3
{

    public partial class ListaDeUsuarios : System.Web.UI.Page
    {
        public List<Usuario> ListaUsuarios = new List<Usuario>();
        public List<Usuario> ListaUsuariosDadosDeBaja = new List<Usuario>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)            
                {
                    Session["loMandamosLogin"] = true;
                    Response.Redirect("Login.aspx");
                }
            else
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario) Session["Usuario"];
                if (usuario.rol != 1)
                {
                    Response.Redirect("Login.aspx");
                }


            }


            UsuarioService usuarioService = new UsuarioService();
            List<Usuario> listaUsuariosDeAlta = new List<Usuario>();
            listaUsuariosDeAlta=usuarioService.listarUsuarios();
            List<Usuario> listaUsuariosDeAltaAux = new List<Usuario>();
            ListaUsuarios = listaUsuariosDeAltaAux;
            foreach(Usuario usuario1 in listaUsuariosDeAlta)
            {
                if (usuario1.esActivo == true)
                {
                    listaUsuariosDeAltaAux.Add(usuario1);
                }
            }
            ListaUsuarios = listaUsuariosDeAltaAux;
            


            RepeaterUsuarios.DataSource = ListaUsuarios;
            RepeaterUsuarios.DataBind();
            List<Usuario> listaUsuariosDeBaja = new List<Usuario>();
            ListaUsuariosDadosDeBaja = new List<Usuario>();
            List<Usuario> listaUsuariosTodos = usuarioService.listarUsuarios();

            foreach (Usuario usuario in listaUsuariosTodos)
            {
                if (usuario.esActivo == false)
                {
                    listaUsuariosDeBaja.Add(usuario);
                }
            }
            ListaUsuariosDadosDeBaja = listaUsuariosDeBaja;
            RepeaterUsuariosBaja.DataSource = ListaUsuariosDadosDeBaja;
            RepeaterUsuariosBaja.DataBind();


        }
        protected void btnAbrirModalModificar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string userId = btn.CommandArgument;
            Session["userId"] = userId;
            Response.Redirect("AdminMOdificarUsuario.aspx");


        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            //string userId = hiddenUserId.Value;
            //string nombre = txtNombre.Text;
            //string apellido = txtApellido.Text;
            //string correo = txtCorreo.Text;
            //string telefono = txtTelefono.Text;

            // Guardar cambios en la base de datos
            // Aquí llamas a tu lógica para actualizar el usuario

            // Opcional: Mostrar un mensaje de confirmación
            fGlobales.MostrarAlerta(this, "Cambios guardados con exito");

        }
        protected void btnDarAltaUsuario_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string userId = btn.CommandArgument;
            UsuarioService usuarioObj = new UsuarioService();
            usuarioObj.DarAltaUsuario( int.Parse( userId.ToString()));

            ArticuloService articuloService = new ArticuloService();
            articuloService.LevantarArticuloPorUsuario(int.Parse(userId.ToString()));


            fGlobales.MostrarAlerta(this, "Usuario con Accesso restringido cambiado a acceso permitido con exito");
            Page_Load(sender, e);
        }
        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string userId = btn.CommandArgument;
            UsuarioService usuarioObj = new UsuarioService();
            usuarioObj.EliminarUsuario(int.Parse(userId));
            ArticuloService articuloService = new ArticuloService();
            articuloService.BajarArticuloPorUsuario(int.Parse(userId.ToString()));
                   
           

            fGlobales.MostrarAlerta(this, "Usuario eliminado con exito");
            Page_Load(sender, e);
        }
    }
}