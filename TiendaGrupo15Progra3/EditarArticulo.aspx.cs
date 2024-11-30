
using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaGrupo15Progra3
{
    public partial class EditarArticulo : System.Web.UI.Page
    {
        public Articulo articulo = new Articulo();
        public Articulo articuloNuevo = new Articulo();
        public ArticuloService articuloService = new ArticuloService();
        public ImagenService imagenService = new ImagenService();
        public Imagen imagen =new Imagen();

        public string IdArticulo { get; set; }
        public Usuario UsuarioModificarArticulo = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Session["DebeLoguearse"] = true;
                Response.Redirect("Login.aspx");
            }
            else
            {

                if (!IsPostBack)
                {

                    articuloService = new ArticuloService();
                    imagenService = new ImagenService();
                    articulo = new Articulo();


                    UsuarioModificarArticulo = (Usuario)Session["Usuario"];
                    IdArticulo = Session["Id"].ToString();

                    try
                    {
                        if (CompletarArticulo() != null)
                        {
                            PrellenarCamposArticulo();
                            PrellenarImagenesUrl();

                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
                    articuloService = new ArticuloService();
                    imagenService = new ImagenService();
                    imagen = new Imagen();
                    IdArticulo = Session["Id"].ToString();


            }
        }


        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                if (actualizarArticulo())
                {

                    lblMessage.Text = "Las caracteristicas del producto han sido actualizadas con exito";
                    
                    Response.AddHeader("REFRESH", "3;URL=VenderProductos.aspx");
                }
                else
                {
                    lblMessage.Text = "El producto no se ha podido modificar, verifique que los campos estan completos";
                    
                }


           
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected Articulo CompletarArticulo()
        {
            Articulo aux = new Articulo();
            

            try
            {
                int idArticulo;


                if (int.TryParse(IdArticulo, out idArticulo) && idArticulo != 0)
                {
                    aux = articuloService.listarXid(int.Parse(IdArticulo));

                    return aux;
                }

                else { return null; }

            }
            catch (Exception)
            {

                throw;
            }

        }
        protected List <Imagen> CompletarImagen()
        {
            List<Imagen> ListaUrlImagenAux = new List<Imagen>();

            try
            {
                int idArticulo;


                if (int.TryParse(IdArticulo, out idArticulo) && idArticulo != 0)
                {
                    ListaUrlImagenAux=imagenService.listarPorIdArticulo(int.Parse(IdArticulo));
                    
                    return ListaUrlImagenAux;

                }

                else { return null; }



            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void PrellenarCamposArticulo()
        {
            articulo = CompletarArticulo();

            try
            {
                if (articulo != null)
                {
                    nombreArtTxt.Text = articulo.Nombre;
                    TxtCategoria.Text = articulo.Categoria.Descripcion;
                    TxtMarca.Text = articulo.Marca.Descripcion;
                    CodigoArticuloTxt.Text = articulo.CodigoArticulo;
                    DescripcionTxt.Text = articulo.Descripcion;
                    PrecioTxt.Text = Math.Round(articulo.Precio, 2).ToString();
                    txtStock.Text = articulo.Stock.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        protected void PrellenarImagenesUrl()
        {
            List<Imagen>ImagenesPorProducto = new List<Imagen>();

            ImagenesPorProducto = CompletarImagen();

            ddlImagenes.DataSource = ImagenesPorProducto;
            ddlImagenes.DataTextField = "UrlImagen"; 
            ddlImagenes.DataValueField = "UrlImagen"; 
            ddlImagenes.DataBind();
            if (ImagenesPorProducto.Count > 0) 
            { 
              imgDefault.ImageUrl = ImagenesPorProducto[0].UrlImagen; 
            } 
            else 
            { 
               
                imgDefault.ImageUrl = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"; 
            }

            txtModificarImagenUrl.Text = "";
        }

        protected void ddlImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {  //Actualizar la imagen según la selección del dropdown 
           string selectedImageUrl = ddlImagenes.SelectedValue; 
           imgDefault.ImageUrl = selectedImageUrl; 
          txtModificarImagenUrl.Text = " "; 
        }

        protected bool cambiosENcampos()
        {
            CategoriaService categoriaService = new CategoriaService();
            MarcaService marcaService = new MarcaService();
            Marca marca = new Marca();
            Categoria categoria = new Categoria();


            try
            {   

                if (validarCamposEntrada())
                {
                    if ((int.TryParse(txtStock.Text, out int stock) &&
                    decimal.TryParse(PrecioTxt.Text, NumberStyles.Any, new CultureInfo("es-ES"), out decimal precio)))
                    {
                        Usuario usuario = (Usuario)Session["Usuario"];
                        articuloNuevo.Nombre = nombreArtTxt.Text;
                        articuloNuevo.CodigoArticulo = CodigoArticuloTxt.Text;
                        articuloNuevo.Descripcion = DescripcionTxt.Text;
                        articuloNuevo.Precio = Math.Round(precio, 2);
                        articuloNuevo.Stock = stock;
                        articuloNuevo.IdUsuario = usuario.idUsuario;
                        
                        

                        if (categoriaService.BuscarCategoria(TxtCategoria.Text) != 0)
                        {
                            CategoriaService categoriaService2 = new CategoriaService();
                            

                            categoria.Id = categoriaService2.BuscarCategoria(TxtCategoria.Text);
                            articuloNuevo.Categoria = new Categoria();
                            articuloNuevo.Categoria.Id = categoria.Id;

                        }
                        else
                        {
                            CategoriaService categoriaService2 = new CategoriaService();
                            

                            
                            categoriaService.AgregarCategoriaNueva(TxtCategoria.Text);
                            
                            categoria.Id = categoriaService2.BuscarCategoria(TxtCategoria.Text);
                            articuloNuevo.Categoria = new Categoria();
                            articuloNuevo.Categoria.Id = categoria.Id;
                        }

                        if (marcaService.BuscarMarca(TxtMarca.Text) != 0)
                        {
                            
                            MarcaService marcaService2 = new MarcaService();
                           

                            marca.Id = marcaService2.BuscarMarca(TxtMarca.Text);
                            articuloNuevo.Marca = new Marca();
                            articuloNuevo.Marca.Id = marca.Id;

                        }
                        else
                        {


                            
                            MarcaService marcaService2 = new MarcaService();
                            
                            

                            marcaService2.AgregarMarcaNueva(TxtMarca.Text);
                            marca.Id = marcaService2.BuscarMarca(TxtMarca.Text);
                            articuloNuevo.Marca = new Marca();
                            articuloNuevo.Marca.Id = marca.Id;
                        }

                        return true;
                    }
                    else
                    {
                        lblMessage.Text = "Alguno de los campos no se encuentra en el formato correcto. Recuerde que los precios llevan 2 decimales y el stock siempre es entero";
                        return false;
                    }

                }
                else
                {
                    lblMessage.Text = "Alguno de los campos no se encuentra en el formato correcto.";
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected bool validarCamposEntrada()
        {
            if (string.IsNullOrWhiteSpace(nombreArtTxt.Text) ||
                string.IsNullOrWhiteSpace(CodigoArticuloTxt.Text) ||
                string.IsNullOrWhiteSpace(DescripcionTxt.Text) ||
                string.IsNullOrWhiteSpace(PrecioTxt.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text) ||
                string.IsNullOrWhiteSpace(TxtCategoria.Text) ||
                string.IsNullOrWhiteSpace(TxtMarca.Text))
            {
                lblMessage.Text = "Es obligatorio rellenar todos los campos";
                return false;
            }
            if(decimal.Parse(PrecioTxt.Text)<0||int.Parse(txtStock.Text)<0)
            {
                lblMessage.Text = "No se pueden agregar precios o stock en negativo";
                return false;
            }
                    

            return true;

        }

        protected bool actualizarArticulo()
        {
            try
            {
                int idArticulo = 0;
                if (IdArticulo != null ){
                    idArticulo = int.Parse(IdArticulo);
                }

                if (idArticulo != 0)
                {
                    if (cambiosENcampos())
                    {

                        articuloService.ModificarArticulo(int.Parse(IdArticulo), articuloNuevo);

                        return true;
                    }

                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnModificarImagen_Click(object sender, EventArgs e)
        {

            try
            {
                    string urlImagenAnterior = ddlImagenes.SelectedValue;
                
                if (string.IsNullOrWhiteSpace(txtModificarImagenUrl.Text))
                {
                    fGlobales.MostrarAlerta(this, "No ha agregado ninguna imagen para modificar");
                    return;
                }
                    string urlImagenNueva = txtModificarImagenUrl.Text; 
                    string idArt = Session["Id"].ToString(); 

                    bool modificado = imagenService.ModificarImagenporUrl(urlImagenNueva,urlImagenAnterior, idArt);

                    if (modificado)
                    {
                        
                        List<Imagen> imagenes = CompletarImagen();

                        ddlImagenes.DataSource = imagenes;
                        ddlImagenes.DataTextField = "UrlImagen";
                        ddlImagenes.DataValueField = "UrlImagen";
                        ddlImagenes.DataBind();

                        if (imagenes.Count > 0)
                        {
                            
                            imgDefault.ImageUrl = imagenes[0].UrlImagen;
                        }
                        else
                        {
                            
                            imgDefault.ImageUrl = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png";
                        }

                        lblMessage.Text = "Imagen modificada correctamente.";
                    }
                    else
                    {
                        lblMessage.Text = "No se pudo modificar la imagen.";
                    }

                    }
            catch (Exception)
            {

                throw;
            }
        }

    }
} 
        
    
