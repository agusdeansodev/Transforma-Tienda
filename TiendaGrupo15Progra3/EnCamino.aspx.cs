using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGrupo15Progra3
{
    public partial class EnCamino : System.Web.UI.Page
    {
        public List<ParaRepeter> paraRepeterList = new List<ParaRepeter>();
        public List<ParaRepeter> paraRepeterListComprados = new List<ParaRepeter>();
        public string mensajesAlerta;
        public void AgregarMensajeAlerta(string mensaje)
        {
            mensajesAlerta += mensaje + "\\n";
        }

        public void MostrarAlertas()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + mensajesAlerta + "');", true);
        }

        public void Page_Load(object sender, EventArgs e)
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


                List<ParaRepeter>limpia= new List<ParaRepeter>();
                paraRepeterList = limpia;
                ArticuloService articuloService = new ArticuloService();

                listaVentasVendidas = ventaService.buscarEnCaminoVentas(usuario.idUsuario);

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
                        paraRepeter.EnCamino = ventaItem.Vendido;
                        paraRepeterList.Add(paraRepeter);
                    }


                }
                RepeaterEnProcesoVendidos.DataSource = paraRepeterList;
                RepeaterEnProcesoVendidos.DataBind();

                Usuario usuario2 = (Usuario)Session["Usuario"];
                VentaService ventaService2 = new VentaService();
                List<Venta> listaVentasCompradas = new List<Venta>();
                Venta venta2 = new Venta();
                DetalleVenta detalleVenta2 = new DetalleVenta();
                DetalleVentaService detalleVentaService2 = new DetalleVentaService();



                ArticuloService articuloService2 = new ArticuloService();
                limpia = new List<ParaRepeter>();
                paraRepeterListComprados = limpia;
                listaVentasCompradas = ventaService2.buscarEnCaminoCompras(usuario.idUsuario);

                foreach (Venta ventaItem in listaVentasCompradas)
                {
                    if (detalleVentaService.BuscarPorIdVenta(ventaItem.idVenta) != null)
                    {
                        Usuario usuarioParaRepetear = new Usuario();
                        UsuarioService usuarioService = new UsuarioService();
                        detalleVenta = detalleVentaService.BuscarPorIdVenta(ventaItem.idVenta);
                        usuarioParaRepetear = usuarioService.TraerUsuarioPorId(ventaItem.idUsuario);


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
                        paraRepeter.EnCamino = ventaItem.Comprado;
                        paraRepeterListComprados.Add(paraRepeter);
                    }


                }
                RepeaterEnProcesoComprados.DataSource = paraRepeterListComprados;
                RepeaterEnProcesoComprados.DataBind();
            


        }

        protected void BTNEnProcesoVendidosEliminar_Click(object sender, EventArgs e)
        {
            Button idVentaAVenderBoton = (Button)sender;
            int idVenta = int.Parse(idVentaAVenderBoton.CommandArgument);
            VentaService ventaService = new VentaService();
            ventaService.MarcarComoVendido(idVenta);
            idVentaAVenderBoton.Enabled = false;
            idVentaAVenderBoton.Visible = false;
            idVentaAVenderBoton.Text = "ENTREGADO";
            fGlobales.MostrarAlerta(this, "Producto marcado como Entregado");
            Page_Load(sender, e);
        }
        protected void BTNEnProcesoComprados_Click(object sender, EventArgs e)
        {
            Button idVentaARecibirBoton = (Button)sender;
            int idVenta = int.Parse(idVentaARecibirBoton.CommandArgument);
            VentaService ventaService = new VentaService();
            ventaService.MarcarComoComprado(idVenta);
            idVentaARecibirBoton.Enabled=false;
            idVentaARecibirBoton.Visible=false;
            fGlobales.MostrarAlerta(this, "Producto marcado como Recibido");
            Page_Load(sender, e);
        }


    }
    
        


}
    
