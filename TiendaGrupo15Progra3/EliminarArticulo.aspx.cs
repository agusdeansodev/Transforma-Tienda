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
    public partial class EliminarArticulo : System.Web.UI.Page
    {
        List<Articulo> articulosDelUsuario = new List<Articulo>();
        protected Articulo articulo { get; set; }
        protected ArticuloService articuloService { get; set; }
        protected ImagenService imagenService { get; set; }

        protected string IdArticulo { get; set; }
       

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
            articuloService = new ArticuloService();
            imagenService = new ImagenService();
            Listatemporal = articuloService.GetArticulos();
            List<Articulo> ListatemporalFiltrada = new List<Articulo>();

            foreach (Articulo articulo in Listatemporal)
            {


                if (articulo.Alta && (articulo.IdUsuario == usuario.idUsuario))
                {
                    ListatemporalFiltrada.Add(articulo);
                }
            }

            articulosDelUsuario = ListatemporalFiltrada;

            RepeaterArticulosAltaUsuario.DataSource = articulosDelUsuario;
            RepeaterArticulosAltaUsuario.DataBind();

        }

        protected void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                string ArticuloId = btn.CommandArgument;
                Session.Add("Id", ArticuloId);

                BajaArticulo();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BajaArticulo()
        {
            try
            {
                string Eliminar = Session["id"].ToString();

                if (Eliminar != null)
                {
                    imagenService.EliminarImagenesArticulo(int.Parse(Eliminar));

                    articuloService.BajaLogicaArticuloPorId(int.Parse(Eliminar));

                    lblMessage.Text = "Producto eliminado con exito";

                    Response.AddHeader("REFRESH", "3;URL=EliminarArticulo.aspx");

                }

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
                RepeaterArticulosAltaUsuario.DataSource = listaFiltrada;


                RepeaterArticulosAltaUsuario.DataBind();


            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
        protected void BtnRefrescar_Click(object sender, EventArgs e)
        {
            Response.AddHeader("REFRESH", "0;URL=EliminarArticulo.aspx");
        }

    }
}