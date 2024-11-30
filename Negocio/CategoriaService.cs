using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Dominio;

namespace Negocio
{
    public class CategoriaService
    {
        public List<Categoria> getCategorias()
        {
            List<Categoria> ListaCategorias = new List<Categoria>();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);
                    ListaCategorias.Add(categoria);
                }

                return ListaCategorias;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar categorias: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public int BuscarCategoria(string Descripcion)
        {
            AccesoDatos datos = new AccesoDatos();
            int categoriaId = 0;
            try
            {
                datos.setearConsulta("SELECT Id,Descripcion from CATEGORIAS where Descripcion=@Descripcion");
                datos.setearParametro("@Descripcion", Descripcion);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    categoriaId = int.Parse(datos.Lector["Id"].ToString());
                    return categoriaId;

                }

                return categoriaId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar categoria: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Categoria BuscarCategoriaPorId(int idCategoria)
        {
            AccesoDatos datos = new AccesoDatos();
            Categoria categoriaError = new Categoria();
            categoriaError.Id = 0;
            try
            {
                datos.setearConsulta("SELECT Id,Descripcion from CATEGORIAS where Id=@Id");
                datos.setearParametro("@Id", idCategoria);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {   
                    Categoria categoria = new Categoria();

                    categoria.Id = int.Parse(datos.Lector["Id"].ToString());
                    categoria.Descripcion = datos.Lector["Id"].ToString();
                    return categoria;

                }

                return categoriaError;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar categoria: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AgregarCategoriaNueva(string Descripcion)
        {
            AccesoDatos datos = new AccesoDatos();
            Categoria categoria = new Categoria();
            try
            {
                datos.setearConsulta("Insert into Categorias (Descripcion) VALUES(@Descripcion)");
                datos.setearParametro("@Descripcion", Descripcion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar nueva categoria: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void ModificarCategoria(string Descripcion)
        {
            AccesoDatos datos = new AccesoDatos();
            Categoria categoria = new Categoria();
            try
            {
                datos.setearConsulta("UPDATE Categorias SET Descripcion=@Descripcion) where Descripcion=@Descripcion");
                datos.setearParametro("@Descripcion", Descripcion);
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
    }
}
