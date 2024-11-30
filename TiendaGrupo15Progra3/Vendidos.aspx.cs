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
    public partial class Vendidos : System.Web.UI.Page
    {
        public List<ParaRepeter> paraRepeterList = new List<ParaRepeter>();
        public string mensajesAlerta;
        public decimal TotalVendido = new decimal();
        public void AgregarMensajeAlerta(string mensaje)
        {
            mensajesAlerta += mensaje + "\\n";
        }

        public void MostrarAlertas()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + mensajesAlerta + "');", true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {

                Session["loMandamosLogin"] = true;
                Response.Redirect("Login.aspx");

            }


            Usuario usuario = (Usuario)Session["Usuario"];
            VentaService ventaService = new VentaService();
            List<Venta> listaVentasVendidas = new List<Venta>();
            Venta venta = new Venta();
            DetalleVenta detalleVenta = new DetalleVenta();
            DetalleVentaService detalleVentaService = new DetalleVentaService();



            ArticuloService articuloService = new ArticuloService();

            listaVentasVendidas = ventaService.buscarVendido(usuario.idUsuario);

            foreach (Venta ventaItem in listaVentasVendidas)
            {
                if (detalleVentaService.BuscarPorIdVenta(ventaItem.idVenta) != null)
                {
                    Usuario usuarioParaRepetear = new Usuario();
                    UsuarioService usuarioService = new UsuarioService();
                    detalleVenta = detalleVentaService.BuscarPorIdVenta(ventaItem.idVenta);
                    usuarioParaRepetear = usuarioService.TraerUsuarioPorId(ventaItem.Id_cliente);


                    Articulo articulo = new Articulo();
                    ParaRepeter paraRepeter = new ParaRepeter();
                    articulo = articuloService.listarXid(detalleVenta.idProducto);
                    paraRepeter.producto = articulo.Nombre;
                    paraRepeter.precio = Math.Round(articulo.Precio, 2);
                    paraRepeter.cantidad = detalleVenta.cantidad;
                    paraRepeter.Total = Math.Round(detalleVenta.cantidad * articulo.Precio, 2);
                    paraRepeter.categoria = detalleVenta.categoriaProducto;
                    paraRepeter.marca = detalleVenta.marcaProducto;
                    paraRepeter.Stock = articulo.Stock;
                    paraRepeter.telefono = usuarioParaRepetear.telefono;
                    paraRepeter.correo = usuarioParaRepetear.correo;
                    paraRepeter.idVenta = ventaItem.idVenta;
                    paraRepeterList.Add(paraRepeter);
                }


            }
            RepeaterComprado.DataSource = paraRepeterList;

            RepeaterComprado.DataBind();
            RepeaterComprado.DataBind();
            decimal TotalParaMostrar = 0;
            foreach (ParaRepeter paraRepeterItem in paraRepeterList)
            {
                TotalParaMostrar += paraRepeterItem.Total;
            }
            TotalVendido = TotalParaMostrar;



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
                List<ParaRepeter> paraRepeterListFiltro = paraRepeterList;

                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["Usuario"];
                ParaRepeterService paraRepeterService = new ParaRepeterService();
                paraRepeterList = paraRepeterService.BusquedaAvanzadaVendidos(usuario.idUsuario, nombreProducto, precioProducto, categoria, marca);
                RepeaterComprado.DataSource = paraRepeterList;

                RepeaterComprado.DataBind();


            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        protected void BtnRefrescar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Vendidos.aspx");
            
            Response.AddHeader("REFRESH","0;URL=Vendidos.aspx");
            
        }
    }
}