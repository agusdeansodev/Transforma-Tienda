using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Dominio;
using System.Data.SqlClient;
using System.Collections;

namespace Negocio
{
    public class ArticuloService
    {

        public List<Articulo> GetArticulos()
        {
            List<Articulo> ArticulosFinal = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            ImagenService imagenArticulos = new ImagenService();
            

            try
            {
                datos.setearConsulta(@"SELECT ART.Id, ART.Nombre, ART.Codigo, ART.Descripcion, ART.Precio,ART.Stock,ART.IdUsuario, ART.Alta,
                                        MAR.Descripcion AS MarcaDescripcion, CAT.Descripcion AS CategoriaDescripcion 
                                     FROM ARTICULOS ART 
                                     INNER JOIN CATEGORIAS CAT ON ART.IdCategoria = CAT.Id 
                                     INNER JOIN MARCAS MAR ON ART.IdMarca = MAR.Id");
                datos.ejecutarLectura();
             
                while (datos.Lector.Read())
                {   Marca Maraux = new Marca();
                    Categoria CatAux = new Categoria();
                    Articulo aux = new Articulo();
                    aux.Id = Convert.ToInt32(datos.Lector["Id"]);
                    aux.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    aux.CodigoArticulo = Convert.ToString(datos.Lector["Codigo"]);
                    aux.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);
                    aux.Precio = (decimal)(datos.Lector["Precio"]);
                    aux.Stock = (int)(datos.Lector["Stock"]);
                    aux.IdUsuario = (int)(datos.Lector["IdUsuario"]);
                    aux.Alta = (bool)datos.Lector["Alta"];
                    Maraux.Descripcion = Convert.ToString(datos.Lector["MarcaDescripcion"]);
                    CatAux.Descripcion = Convert.ToString(datos.Lector["CategoriaDescripcion"]);
                    aux.Marca = Maraux;
                    aux.Categoria = CatAux;
                   

                    ArticulosFinal.Add(aux);
                }

                foreach (Articulo a in ArticulosFinal)
                {
                    List<Imagen> listaimagenesArticulos = imagenArticulos.listarPorIdArticulo(a.Id);
                    a.Imagenes = listaimagenesArticulos;
                }

                return ArticulosFinal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Articulo> GetArticulosBusquedaNombre(string Busqueda)
        {
            List<Articulo> ArticulosFinal = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            Articulo aux = new Articulo();
            ImagenService imagenArticulos = new ImagenService();
            

            try
            {
                datos.setearConsulta(@"SELECT id,nombre,precio 
                                            FROM ARTICULOS 
                                        WHERE Nombre LIKE '%' + @Busqueda + '%'");
                datos.setearParametro("@Busqueda",Busqueda);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.Id = (int)(datos.Lector["id"]);
                    aux.Nombre = Convert.ToString(datos.Lector["nombre"]);
                    aux.Precio = (decimal)(datos.Lector["precio"]);
                    
                    //Maraux.Descripcion = Convert.ToString(datos.Lector["MarcaDescripcion"]);
                    //CatAux.Descripcion = Convert.ToString(datos.Lector["CategoriaDescripcion"]);


                    ArticulosFinal.Add(aux);
                }

                foreach (Articulo a in ArticulosFinal)
                {
                   List<Imagen> listaimagenesArticulos = imagenArticulos.listarPorIdArticulo(a.Id);
                    a.Imagenes = listaimagenesArticulos;
                }

                return ArticulosFinal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> BusquedaAvanzada(string nombre, decimal? precio, string categoria, string marca)
        {
            // Construir la consulta dinámica
            var query = "SELECT Articulos.Id,Nombre,precio FROM Articulos inner join Categorias on Articulos.IdCategoria=Categorias.Id inner join Marcas on Articulos.IdMarca=Marcas.Id WHERE 1=1"; // 1=1 facilita agregar condiciones dinámicas
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(nombre))
            {
                query += " AND Nombre LIKE @Nombre";
                parameters.Add(new SqlParameter("@Nombre", $"%{nombre}%")); // Búsqueda parcial
            }

            if (precio.HasValue)
            {
                query += " AND Precio = @Precio";
                parameters.Add(new SqlParameter("@Precio", precio.Value));
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                query += " AND Categorias.Descripcion = @Categoria";
                parameters.Add(new SqlParameter("@Categoria", categoria));
            }

            if (!string.IsNullOrEmpty(marca))
            {
                query += " AND Marcas.Descripcion = @Marca";
                parameters.Add(new SqlParameter("@Marca", marca));
            }

            // Ejecutar la consulta
            using (var connection = new SqlConnection("server=.\\SQLEXPRESS; database =  EcomerceTCPGrupo15A; integrated security = true"))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddRange(parameters.ToArray());

                var reader = command.ExecuteReader();
                var resultados = new List<Articulo>();

                while (reader.Read())
                {
                    resultados.Add(new Articulo
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Precio = reader.GetDecimal(2),
                        
                    });
                }
                ImagenService imagenService = new ImagenService();
                foreach (Articulo a in resultados)
                {
                    List<Imagen> listaimagenesArticulos =  imagenService.listarPorIdArticulo(a.Id);
                    a.Imagenes = listaimagenesArticulos;

                }

                return resultados;
            }
        }

       /* public List<ParaRepeter> BusquedaComprados(string nombre, decimal? precio, string categoria, string marca)
        {
            // Construir la consulta dinámica
            var query = "SELECT Articulos.Id,Nombre,precio FROM Articulos inner join Categorias on Articulos.IdCategoria=Categorias.Id inner join Marcas on Articulos.IdMarca=Marcas.Id WHERE 1=1"; // 1=1 facilita agregar condiciones dinámicas
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(nombre))
            {
                query += " AND Nombre LIKE @Nombre";
                parameters.Add(new SqlParameter("@Nombre", $"%{nombre}%")); // Búsqueda parcial
            }

            if (precio.HasValue)
            {
                query += " AND Precio = @Precio";
                parameters.Add(new SqlParameter("@Precio", precio.Value));
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                query += " AND Categorias.Descripcion = @Categoria";
                parameters.Add(new SqlParameter("@Categoria", categoria));
            }

            if (!string.IsNullOrEmpty(marca))
            {
                query += " AND Marcas.Descripcion = @Marca";
                parameters.Add(new SqlParameter("@Marca", marca));
            }

            // Ejecutar la consulta
            using (var connection = new SqlConnection("server=.\\SQLEXPRESS; database =  EcomerceTCPGrupo15A; integrated security = true"))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddRange(parameters.ToArray());

                var reader = command.ExecuteReader();
                var resultados = new List<Articulo>();

                while (reader.Read())
                {
                    resultados.Add(new Articulo
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Precio = reader.GetDecimal(2),

                    });
                }
                ImagenService imagenService = new ImagenService();
                foreach (Articulo a in resultados)
                {
                    List<Imagen> listaimagenesArticulos = imagenService.listarPorIdArticulo(a.Id);
                    a.Imagenes = listaimagenesArticulos;

                }

                //return resultados;
            }
        }
       */

        public List<Articulo> GetArticulos2()
        {
            List<Articulo> ArticulosFinal = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
           ImagenService imagenArticulos = new ImagenService();

            try
            {
                datos.setearConsulta("select ARTICULOS.Id, ARTICULOS.Nombre, ARTICULOS.Codigo ,ARTICULOS.Descripcion, ARTICULOS.Precio, MARCAS.Descripcion,CATEGORIAS.Descripcion from ARTICULOS" +
                    " INNER JOIN CATEGORIAS on ARTICULOS.IdCategoria = CATEGORIAS.Id" +
                    " INNER JOIN MARCAS on ARTICULOS.IdMarca=MARCAS.Id");
                datos.ejecutarLectura();
            


                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = Convert.ToInt32(datos.Lector["Id"]);
                    aux.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    aux.CodigoArticulo = Convert.ToString(datos.Lector["Codigo"]);
                    aux.Descripcion = Convert.ToString(datos.Lector["ARTICULOS.Descripcion"]); aux.Precio = (decimal)(datos.Lector["Precio"]);
                    aux.Marca.Descripcion = Convert.ToString(datos.Lector["MARCAS.Descripcion"]);
                    aux.Categoria.Descripcion = Convert.ToString(datos.Lector["CATEGORIAS.Descripcion"]);
                   
                    ArticulosFinal.Add(aux);
                }

                foreach (Articulo a in ArticulosFinal)
                {
                    List<Imagen> listaimagenesArticulos = imagenArticulos.listarPorIdArticulo(a.Id);
                    a.Imagenes = listaimagenesArticulos;
                   
                }

                return ArticulosFinal;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            } 
        }
        public Articulo listarXid (int ArticuloID)
        {
          
            AccesoDatos accesoDatos = new AccesoDatos();
            ImagenService imagenService = new ImagenService();
            List <Imagen>  lista = new List<Imagen>();

            try
            {
                accesoDatos.setearConsulta("SELECT A.Id, Codigo, Nombre,IdUsuario,A.Descripcion, A.IdMarca, A.IdCategoria, M.Descripcion Nombre_Marca,C.Descripcion Nombre_Categoria, M.Id Id_Marca, C.Id Id_Categoria, A.Precio,A.Stock, A.Alta FROM ARTICULOS A JOIN CATEGORIAS C ON A.IdCategoria = C.Id JOIN MARCAS M ON A.IdMarca = M.Id WHERE A.id=@idArticulo");
                accesoDatos.setearParametro("@idArticulo",ArticuloID);
                accesoDatos.ejecutarLectura();
                Articulo articulo = new Articulo();
                while (accesoDatos.Lector.Read())
                {
                    

                    articulo.Id = (int)accesoDatos.Lector["Id"];
                    articulo.CodigoArticulo = (string)accesoDatos.Lector["Codigo"];
                    articulo.Nombre = (string)accesoDatos.Lector["Nombre"];
                    articulo.IdUsuario = (int)accesoDatos.Lector["IdUsuario"];
                    articulo.Descripcion = (string)accesoDatos.Lector["Descripcion"];

                    //Creacion de Marca y relacion en datagrid
                    articulo.Marca = new Marca();
                    articulo.Marca.Descripcion = (string)accesoDatos.Lector["Nombre_Marca"];
                    articulo.Marca.Id = (int)accesoDatos.Lector["IdMarca"];

                    //Creacion de Categoria y relacion en datagrid
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Descripcion = (string)accesoDatos.Lector["Nombre_Categoria"];
                    articulo.Categoria.Id = (int)accesoDatos.Lector["IdCategoria"];

                    articulo.Precio = (decimal)accesoDatos.Lector["Precio"];
                    articulo.Stock = (int)accesoDatos.Lector["Stock"];
                    articulo.Alta = (bool)accesoDatos.Lector["Alta"];

                }

                foreach (var a in lista)
                {
                    List<Imagen> imagenes = imagenService.listarPorIdArticulo(articulo.Id);
                    articulo.Imagenes = imagenes;
                }
                return articulo ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();

            }

           
        }

        public void AgregarArticulo (Articulo nuevoArticulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta(@"INSERT INTO Articulos (Codigo, Nombre, Descripcion,IdMarca,IdCategoria,Precio, Stock, IdUsuario)
                VALUES (@codigo,@nombre,@descripcion,@IdMarca,@IdCategoria,@precio,@stock,@IdUsuario)");

                accesoDatos.setearParametro("@codigo", nuevoArticulo.CodigoArticulo);
                accesoDatos.setearParametro("@nombre", nuevoArticulo.Nombre);
                accesoDatos.setearParametro("@descripcion", nuevoArticulo.Descripcion);
                accesoDatos.setearParametro("@IdMarca", nuevoArticulo.Marca.Id);
                accesoDatos.setearParametro("@IdCategoria", nuevoArticulo.Categoria.Id);
                accesoDatos.setearParametro("@precio", nuevoArticulo.Precio);
                accesoDatos.setearParametro("@stock", nuevoArticulo.Stock);
                accesoDatos.setearParametro("@IdUsuario", nuevoArticulo.IdUsuario);
                accesoDatos.ejecutarAccion(); 
    
            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar nuevo producto: " + ex.Message);
            }
            finally { accesoDatos.cerrarConexion();}
        }
        public int TraerArticuloId(Articulo nuevoArticulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            int IdDeArticulo;
            try
            {
                accesoDatos.setearConsulta(@"select Id from ARTICULOS where Nombre=@nombre AND codigo=@codigo And idUsuario=@idUsuario");                
                accesoDatos.setearParametro("@nombre", nuevoArticulo.Nombre);
                accesoDatos.setearParametro("@codigo", nuevoArticulo.CodigoArticulo);
                accesoDatos.setearParametro("@IdUsuario", nuevoArticulo.IdUsuario);
                accesoDatos.ejecutarLectura();
                while (accesoDatos.Lector.Read())
                {
                    IdDeArticulo = (int)accesoDatos.Lector["Id"]; 
                    return IdDeArticulo;
                }

                return -1;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar nuevo producto: " + ex.Message);
            }
            finally { accesoDatos.cerrarConexion(); }
        }
        public void ModificarArticulo (int IdArticulo, string Modificacion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ARTICULOS set Descripcion=@Modificacion where Id=@IdArticulo");
                datos.setearParametro("@Modificacion", Modificacion);
                datos.setearParametro("@IdArticulos", IdArticulo);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

               throw new Exception("Error al modificar producto: " + ex.Message);
            }
            finally { datos.cerrarConexion(); }
        }
        public void LevantarArticuloPorUsuario(int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ARTICULOS set Alta=1 where IdUsuario=@IdUsuario");
                datos.setearParametro("@IdUsuario", IdUsuario);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar producto: " + ex.Message);
            }
            finally { datos.cerrarConexion(); }
        }
        public void BajarArticuloPorUsuario(int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ARTICULOS set Alta=0 where IdUsuario=@IdUsuario");
                datos.setearParametro("@IdUsuario", IdUsuario);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar producto: " + ex.Message);
            }
            finally { datos.cerrarConexion(); }
        }

        public void EliminarArticuloPorId(int IdArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE from ARTICULOS where Id=@IdArticulo");
                datos.setearParametro("@IdArticulo", IdArticulo);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar producto: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void CambiarStockArticuloPorId(int IdArticulo,int cantidadEntrante)
        {
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET stock=@stock where Id=@Id");
                datos.setearParametro("@stock", cantidadEntrante);
                datos.setearParametro("@Id", IdArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar categoria: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void BajaLogicaArticuloPorId(int IdArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Alta=0 where Id=@IdArticulo");
                datos.setearParametro("@IdArticulo", IdArticulo);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar producto: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void ModificarArticulo(int IdArticulo, Articulo articuloModificado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo=@codigo,Nombre=@nombre, Descripcion=@descripcion, Precio=@Precio, Stock=@stock, IdCategoria=@IdCategoria,IdMarca=@IdMarca  where Id=@IdArticulo");
                datos.setearParametro("@codigo", articuloModificado.CodigoArticulo);
                datos.setearParametro("@nombre", articuloModificado.Nombre);
                datos.setearParametro("@descripcion", articuloModificado.Descripcion);
                datos.setearParametro("@Precio", articuloModificado.Precio);
                datos.setearParametro("@stock", articuloModificado.Stock);
                datos.setearParametro("@IdCategoria", articuloModificado.Categoria.Id);
                datos.setearParametro("@IdMarca", articuloModificado.Marca.Id);
                datos.setearParametro("@IdArticulo", IdArticulo);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar producto: " + ex.Message);
            }
            finally { datos.cerrarConexion(); }
        }

        public List<Articulo> BusquedaAvanzadaTusArticulos(int idUsuario, string nombre, decimal? precio, string categoria, string marca)
        {
            List<Articulo> ListaFiltrada = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "";
                if (!string.IsNullOrEmpty(nombre))
                {
                    query += " AND a.nombre LIKE @Nombre"; // Búsqueda parcial


                }

                if (precio.HasValue)
                {
                    query += " AND a.Precio >= @Precio";

                }

                if (!string.IsNullOrEmpty(categoria))
                {
                    query += " AND  c.Descripcion LIKE @Categoria";

                }

                if (!string.IsNullOrEmpty(marca))
                {
                    query += " AND  m.Descripcion LIKE @Marca";

                }


                datos.setearConsulta(@"SELECT
                                                 
    a.Nombre,
    a.precio,
a.Descripcion,
    c.Descripcion,    
    m.Descripcion,
    
    a.stock
   
FROM Articulos a
INNER JOIN
    Categorias c ON c.Id = a.IdCategoria
INNER JOIN
    Marcas m ON m.Id = a.IdMarca
inner Join
    Usuario u on u.idUsuario=a.IdUsuario

  where  u.idUsuario = @idUsuario And a.Alta=1" + query);
                datos.setearParametro("@idUsuario", idUsuario);
                if (!string.IsNullOrEmpty(nombre))
                {
                    // Búsqueda parcial
                    datos.setearParametro("@Nombre", "%" + nombre + "%");

                }

                if (precio.HasValue)
                {

                    datos.setearParametro("@Precio", precio);
                }

                if (!string.IsNullOrEmpty(categoria))
                {

                    datos.setearParametro("@Categoria", "%" + categoria + "%");
                }

                if (!string.IsNullOrEmpty(marca))
                {

                    datos.setearParametro("@Marca", "%" + marca + "%");
                }
                datos.ejecutarLectura();
                // Construir la consulta dinámica



                while (datos.Lector.Read())
                {
                    
                    Articulo articulo = new Articulo();

                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Precio = Convert.ToDecimal(datos.Lector["precio"]);
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Marca.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Stock = Convert.ToInt32(datos.Lector["stock"]);

                    
                    ListaFiltrada.Add(articulo);
                }


                return ListaFiltrada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }

    
}
