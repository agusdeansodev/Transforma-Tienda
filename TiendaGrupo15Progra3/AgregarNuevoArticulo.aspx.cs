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
    public partial class AgregarNuevoArticulo : System.Web.UI.Page
    {
        public Usuario usuarioAgregarProducto = new Usuario();
        public List<Imagen> listaImagenesGlobal = new List<Imagen>();
        
        
        public void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {

                usuarioAgregarProducto = (Usuario)Session["Usuario"];

            }
            else
            {
                usuarioAgregarProducto.nombre = "No se encuentra";
                usuarioAgregarProducto.apellido = "Registrado";
            }
            if (Session["listaImagenes"] != null)
            {
                 listaImagenesGlobal = (List<Imagen>)Session["ListaImagenes"];
            }

        }

        protected void AgregarProductoNuevo_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                string script = "alert('No se encuentra logueado debe loguearse para agregar producto.'); window.location='Login.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
                return;
            }

            usuarioAgregarProducto = (Usuario)Session["Usuario"];


            if (string.IsNullOrWhiteSpace(CodigoArticuloTxt.Text) ||
                string.IsNullOrWhiteSpace(nombreArtTxt.Text) ||
                string.IsNullOrWhiteSpace(DescripcionTxt.Text) ||
                string.IsNullOrWhiteSpace(TxtMarca.Text) ||
                string.IsNullOrWhiteSpace(TxtCategoria.Text) ||
                string.IsNullOrWhiteSpace(PrecioTxt.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text) ||
                string.IsNullOrWhiteSpace(TxtAgregarImg.Text))
            {
                fGlobales.MostrarAlerta(this, "Todos los campos son obligatorios.");
                return;
            }
            if(decimal.Parse(PrecioTxt.Text)<0 || int.Parse(txtStock.Text) < 0)
            {
                fGlobales.MostrarAlerta(this, "El precio y el stock deben ser numeros positivos (mayores a cero).");
                return;
            }


            try
            {  
                ArticuloService articuloService =new ArticuloService();
                int CategoriaId,MarcaId;       
                Marca marca = new Marca();
                MarcaService marcaService =new MarcaService();  
                Categoria categoria = new Categoria();
                CategoriaService categoriaService = new CategoriaService();
                ImagenService imagenService =new ImagenService();
                Articulo nuevoArticulo = new Articulo
                {
                    Categoria = new Categoria(), // Inicializa la propiedad
                    Marca = new Marca() // Inicializa la propiedad Marca };
                };

                nuevoArticulo.CodigoArticulo=CodigoArticuloTxt.Text.Trim();
                nuevoArticulo.Nombre=nombreArtTxt.Text.Trim();
                nuevoArticulo.Descripcion = DescripcionTxt.Text.Trim();
                
                categoria.Descripcion=TxtCategoria.Text.Trim();
                marca.Descripcion=TxtMarca.Text.Trim();

                nuevoArticulo.Precio = decimal.Parse(PrecioTxt.Text.Trim());
                nuevoArticulo.Stock=int.Parse(txtStock.Text.Trim());
                nuevoArticulo.IdUsuario = usuarioAgregarProducto.idUsuario;
                

                CategoriaId=categoriaService.BuscarCategoria(categoria.Descripcion);
                MarcaId=marcaService.BuscarMarca(marca.Descripcion);

                if (CategoriaId != 0)
                {
                    
                    
                    nuevoArticulo.Categoria.Id = categoriaService.BuscarCategoria(categoria.Descripcion);
                   
                } 
                else
                {
                    categoriaService.AgregarCategoriaNueva(categoria.Descripcion);
                    nuevoArticulo.Categoria.Id = categoriaService.BuscarCategoria(categoria.Descripcion);
                }
                if (MarcaId != 0)
                {
                    
                    nuevoArticulo.Marca.Id = marcaService.BuscarMarca(marca.Descripcion);

                }
                else
                {
                    marcaService.AgregarMarcaNueva(marca.Descripcion);

                    nuevoArticulo.Marca.Id = marcaService.BuscarMarca(marca.Descripcion);
                }
                
                articuloService.AgregarArticulo(nuevoArticulo);
                int idArticuloRecienSubido=articuloService.TraerArticuloId(nuevoArticulo);
                List<Imagen> imagenLista=new List<Imagen>();
                if (Session["ListaImagenes"] != null)
                {
                    imagenLista = (List<Imagen>)Session["ListaImagenes"];
                }
                

                foreach (var imagen in imagenLista)
                {
                    imagenService.AgregarImagenesUrlporId(idArticuloRecienSubido, imagen.UrlImagen);
                }



                fGlobales.MostrarAlerta(this, "Articulo con nombre " + nuevoArticulo.Nombre + " agregado con exito.");



            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar un nuevo producto:"+ ex.Message);
            }
        }

        protected void AgregarImagenUrl_Click(object sender, EventArgs e)
        {   
            List<Imagen> listaImagenes = new List<Imagen>();
            if (Session["ListaImagenes"] != null)
            {
                listaImagenes = (List<Imagen>)Session["ListaImagenes"];
            }
            else
            {
                listaImagenes = new List<Imagen>();
            }
            Imagen imagen = new Imagen();
             imagen.UrlImagen = TxtAgregarImg.Text.Trim();
            listaImagenes.Add(imagen);

            Session["ListaImagenes"] = listaImagenes;



            
        }
    }
}