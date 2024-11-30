using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGrupo15Progra3
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected List<Dominio.Carrito> CarritoProductos = new List<Dominio.Carrito>();
        public int cantidadCarrito = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
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
                cantidadCarrito = listaSubMenu.Count;
            }
   
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Rol"] = null;
            Session["Usuario"] = null;
            lblCerrarSesion.Text= "Sesion cerrada con exito.";
        }
    }
}
