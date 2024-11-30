using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TiendaGrupo15Progra3
{
    public partial class CarritoWebForm : System.Web.UI.Page
    {
        protected List<Dominio.Carrito> CarritoProductos = new List<Dominio.Carrito>();
        protected List<CarritoSubMenu> carritoSubMenusGlobal = new List<CarritoSubMenu>();
        public decimal TotalCarritoGlobal { get;set;}=0;
        protected string mensajesAlerta = null;

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
            
            
                CargarCarrito();
            
        }

        private void CargarCarrito()
        {
            if (Session["Usuario"] == null)
            {
                string script = "alert('No se encuentra logueado debe loguearse para ver su carrito.'); window.location='Login.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
                return;
            }

            Usuario usuario = (Usuario)Session["Usuario"];
            CarritoService carritoService = new CarritoService();
            List<Dominio.Carrito> listaCarrito = carritoService.BuscarEnCarritoporIdUsuario(usuario.idUsuario);
            List<CarritoSubMenu> listaSubMenu = new List<CarritoSubMenu>();

            if (listaCarrito != null)
            {
                CarritoProductos = listaCarrito;
            }

            foreach (Dominio.Carrito carrito in CarritoProductos)
            {
                CarritoSubMenu carritoSubMenu = new CarritoSubMenu();
                ArticuloService articuloService = new ArticuloService();
                carritoSubMenu.IdCarrito = carrito.Id;
                carritoSubMenu.IdProducto = carrito.IdProducto;
                carritoSubMenu.Nombre = articuloService.listarXid(carrito.IdProducto).Nombre;
                carritoSubMenu.Precio = Math.Round(articuloService.listarXid(carrito.IdProducto).Precio, 2);
                carritoSubMenu.Cantidad = carrito.Cantidad;
                carritoSubMenu.Total = Math.Round(carrito.Cantidad * articuloService.listarXid(carrito.IdProducto).Precio, 2);
                listaSubMenu.Add(carritoSubMenu);
            }

            carritoSubMenusGlobal = listaSubMenu;
            foreach (CarritoSubMenu item in listaSubMenu)
            {
                TotalCarritoGlobal = TotalCarritoGlobal + item.Total;
            }
            TotalCarritoGlobal = Math.Round(TotalCarritoGlobal, 2);
            
            LiteralTotalCarrito.Text = TotalCarritoGlobal.ToString("C");

            RepeaterCarrito.DataSource = listaSubMenu;
            RepeaterCarrito.DataBind();
        }

        protected void ProcederPago(object sender, EventArgs e)
        {
            bool HayStockdeTodo = true;
            List<int> articulosConSobraDeStock = new List<int>();
            List<CarritoSubMenu> listaCarrito = new List<CarritoSubMenu>();
            Venta nuevaVenta = new Venta();
            DetalleVenta nuevoDetalle = new DetalleVenta();
            VentaService ventaService = new VentaService();
            DetalleVentaService detalleVentaService = new DetalleVentaService();

            if (carritoSubMenusGlobal.Count == 0)
            {
                fGlobales.MostrarAlerta(this, "El carrito se encuentra vacio. NO SE PUEDE COMPRAR NADA.");
                return;
            }

            foreach (CarritoSubMenu carritoItem in carritoSubMenusGlobal)
            {
                Articulo articulo = new Articulo();
                ArticuloService articuloService = new ArticuloService();
                articulo = articuloService.listarXid(carritoItem.IdProducto);
                if (articulo.Stock < carritoItem.Cantidad)
                {
                    HayStockdeTodo = false;
                    articulosConSobraDeStock.Add(carritoItem.IdProducto);
                    listaCarrito.Add(carritoItem);
                }
            }

            if (HayStockdeTodo)
            {
                foreach (CarritoSubMenu carritoItem in carritoSubMenusGlobal)
                {
                    int StockNuevo;
                    Usuario usuario = new Usuario();
                    DetalleVenta detalleVenta = new DetalleVenta();
                    DetalleVentaService detalleVentaService1 = new DetalleVentaService();


                    usuario = (Usuario)Session["Usuario"];
                    ArticuloService articuloService = new ArticuloService();
                    Articulo articulo = new Articulo();
                    CarritoService carritoService = new CarritoService();
                    articulo = articuloService.listarXid(carritoItem.IdProducto);
                    nuevaVenta.nombreCliente = usuario.nombre;
                    nuevaVenta.Id_cliente = usuario.idUsuario;
                    nuevaVenta.idUsuario = articulo.IdUsuario;
                    nuevaVenta.fechaRegistro = DateTime.Now;
                    nuevaVenta.subTotal = (decimal)articulo.Precio;
                    nuevaVenta.Total = nuevaVenta.subTotal * carritoItem.Cantidad;
                    StockNuevo = articulo.Stock - carritoItem.Cantidad;

                    detalleVenta.idProducto = articulo.Id;
                    detalleVenta.cantidad = carritoItem.Cantidad;
                    detalleVenta.marcaProducto = articulo.Marca.Descripcion;
                    detalleVenta.descripcionProducto = articulo.Descripcion;
                    detalleVenta.categoriaProducto = articulo.Categoria.Descripcion;
                    detalleVenta.precio= articulo.Precio;
                    detalleVenta.total= nuevaVenta.Total;



                    articuloService.CambiarStockArticuloPorId(articulo.Id, StockNuevo);
                    ventaService.CargarVenta(nuevaVenta);
                    int nuevoIdVentaGenerado = ventaService.UltimaVenta();
                    detalleVenta.idVenta = nuevoIdVentaGenerado;
                    detalleVentaService.CargarDetalleVenta(detalleVenta);


                    carritoService.EliminarArticulosEnCarritoPorId(articulo.Id, usuario.idUsuario);
                }

                
                CargarCarrito();
                lblMessage.Text = "Compra exitosa,sera redirigido para ver el estado de su compra";
                Response.AddHeader("REFRESH", "3;URL=EnCamino.aspx");

              
            }
            else
            {
                AgregarMensajeAlerta("Contiene uno o más articulos en su carrito con una cantidad que supera el stock actual del producto. ESOS PRODUCTOS HAN BAJADO SU CANTIDAD HASTA EL MAXIMO DISPONIBLE EN STOCK.");
                foreach (int idProductoLista in articulosConSobraDeStock)
                {
                    ArticuloService articuloService = new ArticuloService();
                    
                    Articulo articulo = articuloService.listarXid(idProductoLista);
                    AgregarMensajeAlerta(articulo.Nombre.ToString());
                }

                foreach (CarritoSubMenu carritoItem in listaCarrito)
                {
                    CarritoService carritoService = new CarritoService();
                    ArticuloService articuloService = new ArticuloService();
                    Articulo articulo = new Articulo();
                    articulo = articuloService.listarXid(carritoItem.IdProducto);
                    carritoService.CarritoCambiarCantidad(carritoItem.IdCarrito, articulo.Stock);
                }
                AgregarMensajeAlerta("Aprete de vuelta para proceeder con la compra.");
            }
            if (mensajesAlerta != null)
            {
                MostrarAlertas();
            }
            CargarCarrito();
        }

        protected void BTNCarritoModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnModificar = (Button)sender;
                int idCarrito = int.Parse(btnModificar.CommandArgument);
                // Lógica para modificar la cantidad
            }
            catch (Exception ex)
            {
                // Manejo del error
                Response.Write($"Error: {ex.Message}");
            }
        }

        protected void BTNCarritoEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                CarritoService carritoService = new CarritoService();
               
                Button btnEliminar = (Button)sender;
                int idCarrito = int.Parse(btnEliminar.CommandArgument);
                carritoService.EliminarEnCarritoPorIdCarrito(idCarrito);
                CargarCarrito();
                // Lógica para eliminar el producto del carrito
            }
            catch (Exception ex)
            {
                // Manejo del error
                Response.Write($"Error: {ex.Message}");
            }
        }
    }
}
