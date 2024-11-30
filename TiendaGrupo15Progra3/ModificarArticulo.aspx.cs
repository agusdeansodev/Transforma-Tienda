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
    public partial class ModificarArticulo : System.Web.UI.Page
    {

        List<Articulo> articulosDelUsuario = new List<Articulo>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("/Login.aspx", false);
                return;
            }
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["Usuario"];

            List<Articulo> Listatemporal = new List<Articulo>();
            ArticuloService articuloService = new ArticuloService();
            Listatemporal = articuloService.GetArticulos();
            List<Articulo> ListatemporalFiltrada = new List<Articulo>();

            foreach (Articulo articulo in Listatemporal)
            {


                if (articulo.Alta==true && (articulo.IdUsuario == usuario.idUsuario))
                {
                    ListatemporalFiltrada.Add(articulo);
                }
            }

            articulosDelUsuario = ListatemporalFiltrada;
            RepeaterArticulosUsuario.DataSource = articulosDelUsuario;
            RepeaterArticulosUsuario.DataBind();

        }

        protected void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                string ArticuloId = btn.CommandArgument;
                Session.Add("Id", ArticuloId);
                Response.Redirect("EditarArticulo.aspx");

            }
            catch (Exception)
            {

                throw;
            }


        }

        protected void BtnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            ArticuloService busquedaavanzada = new ArticuloService();

            try
            {
                decimal? precioProducto = null;
                if (!string.IsNullOrWhiteSpace(TextFiltroAvanzadoPrecio.Text.Trim()))
                {
                    if (decimal.TryParse(TextFiltroAvanzadoPrecio.Text.Trim(), out decimal precio))
                    {
                        precioProducto = precio;
                    }
                }
                string nombreProducto = null;
                if (!string.IsNullOrWhiteSpace(TextFiltroAvanzadoNombre.Text.Trim()))
                {

                    nombreProducto = TextFiltroAvanzadoNombre.Text.Trim();

                }
                string categoria = null;
                if (!string.IsNullOrWhiteSpace(TextFiltroAvanzadoCategoria.Text.Trim()))
                {

                    categoria = TextFiltroAvanzadoCategoria.Text.Trim();

                }
                string marca = null;
                if (!string.IsNullOrWhiteSpace(TextFiltroAvanzadoMarca.Text.Trim()))
                {

                    categoria = TextFiltroAvanzadoMarca.Text.Trim();

                }
                List<Articulo> paraRepeterListFiltro = articulosDelUsuario;

                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["Usuario"];
                ArticuloService articuloService = new ArticuloService();
                List<Articulo> listaFiltrada = new List<Articulo>();
                listaFiltrada = articuloService.BusquedaAvanzadaTusArticulos(usuario.idUsuario, nombreProducto, precioProducto, categoria, marca);
                RepeaterArticulosUsuario.DataSource = listaFiltrada;
                

                RepeaterArticulosUsuario.DataBind();


            }
            catch (Exception ex)
            {

                throw ex;
            }



        }


        protected void BtnRefrescar_Click(object sender, EventArgs e)
        {
            Response.AddHeader("REFRESH", "0;URL=ModificarArticulo.aspx");
        }


    }



}