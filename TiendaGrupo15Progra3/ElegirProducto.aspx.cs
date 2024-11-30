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
    public partial class ElijeTuPremio : System.Web.UI.Page
    {
        public List<Articulo> Productos;
        ArticuloService articuloService = new ArticuloService();
        bool FiltradoAvanzado = false;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                CategoriaService categoriaService = new CategoriaService();
                MarcaService marcaService = new MarcaService();
                List<Categoria> DropDownListCategoriaGlobal = new List<Categoria>();
                List<Marca> DropDownListMarca = new List<Marca>();



                Categoria categoria = new Categoria();
                categoria.Descripcion = "No Filtrar Por Categoria";
                Marca marca = new Marca();
                marca.Descripcion = "No Filtrar Por Marca";




                DropDownListMarca = marcaService.getMarcas();
                DropDownListMarca.Insert(0, marca);
                
                DropDownListCategoriaGlobal = categoriaService.getCategorias();
                DropDownListCategoriaGlobal.Insert(0,categoria);
                DropDownListFiltroAvanzadoMarca.DataSource = DropDownListMarca;
                DropDownListFiltroAvanzadoCategoria.DataSource = DropDownListCategoriaGlobal;
                DropDownListFiltroAvanzadoMarca.DataBind();
                DropDownListFiltroAvanzadoCategoria.DataBind();


                
            }
            Productos = articuloService.GetArticulos();
            List<Articulo> productosConStock= new List<Articulo>();

            foreach(Articulo articuloItem in Productos)
            {
                if (articuloItem.Stock > 0 && articuloItem.Alta==true)
                {
                    productosConStock.Add(articuloItem);
                }

            }
            Productos= productosConStock;
        }

        protected void ProductoBoton_Click(object sender, EventArgs e)
        {
           // Response.Redirect("/ElijeTuPremio.aspx?articulo=" + );
            //Session["Articulo"] = 
        }

       

        protected void BtnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            ArticuloService busquedaavanzada = new ArticuloService();
            string nombreProducto = TextFiltroAvanzadoNombre.Text.Trim();
            try
            {
                decimal? precioProducto = null; // Usamos un valor nullable por si no se ingresa un precio
                if (!string.IsNullOrWhiteSpace(TextFiltroAvanzadoPrecio.Text))
                {
                    if (decimal.TryParse(TextFiltroAvanzadoPrecio.Text.Trim(), out decimal precio))
                    {
                        precioProducto = precio;
                    }
                }


                string categoriaProducto = DropDownListFiltroAvanzadoCategoria.Text.Trim();
                if (categoriaProducto == "No Filtrar Por Categoria")
                {
                    categoriaProducto = null;
                }
                string marcaProducto = DropDownListFiltroAvanzadoMarca.Text.Trim();
                if (marcaProducto == "No Filtrar Por Marca")
                {
                    marcaProducto = null;
                }
                Productos = busquedaavanzada.BusquedaAvanzada(nombreProducto, precioProducto, categoriaProducto, marcaProducto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

       
    }
}
public partial class ElegirProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int articuloId;
            if (int.TryParse(Request.QueryString["id"], out articuloId))
            {
                // Aquí deberías obtener el objeto articulo de tu base de datos o lista
                // Ejemplo:
                var articulo = ObtenerArticuloPorId(articuloId);
                if (articulo != null)
                {
                    // Mostrar los detalles del artículo en la página
                    //NombreArticulo.Text = articulo.Nombre;
                    // Otros detalles del artículo...
                }
            }
        }
    }

    public Articulo ObtenerArticuloPorId(int id)
    {
        // Implementa este método para obtener el artículo por ID
        // Puede ser una consulta a la base de datos o una búsqueda en una lista
        
        ArticuloService articuloService = new ArticuloService();
        
        Articulo articulo = new Articulo();
        articulo=articuloService.listarXid(id);
        return articulo; // Ejemplo de objeto de retorno

    }
}
