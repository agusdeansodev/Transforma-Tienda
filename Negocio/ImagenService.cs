using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenService
    {
            public List<Imagen> listar()
            {
                List<Imagen> lista = new List<Imagen>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta("Select Id,IdArticulo,ImagenUrl FROM Imagenes");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {

                        Imagen aux = new Imagen();
                        aux.Id = (int)datos.Lector["Id"];
                        aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                        lista.Add(aux);
                    }
                    return lista;
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
            public List<string> ImagenesUrlporId(int id)
            {
                List<string> lista = new List<string>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta("select ImagenUrl from IMAGENES inner join ARTICULOS on ARTICULOS.Id=IMAGENES.IdArticulo where ARTICULOS.Id=@id");
                    datos.setearParametro("@id", id);

                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        string auxiliar = (string)datos.Lector["ImagenUrl"];

                        lista.Add(auxiliar);
                    }
                    return lista;
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
        public void AgregarImagenesUrlporId(int id,string ImagenRecibida)
        {
            
            AccesoDatos datos = new AccesoDatos();

            try
            {   
                datos.setearConsulta("INSERT into IMAGENES(IdArticulo,ImagenUrl) values (@id,@imagenUrl)");
                datos.setearParametro("@id", id);
                datos.setearParametro("@imagenUrl", ImagenRecibida);

                datos.ejecutarLectura();

                
                
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


        public List<Imagen> listarPorIdArticulo(int id)
            {
                List<Imagen> lista = new List<Imagen>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta(" Select Id,IdArticulo,ImagenUrl FROM IMAGENES WHERE IDArticulo=@id_articulo");
                    datos.setearParametro("@id_articulo", id);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {

                        Imagen aux = new Imagen();
                        aux.Id = (int)datos.Lector["Id"];
                        aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                        lista.Add(aux);
                    }
                    return lista;
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

        public void EliminarPorIdImagen(int id)
        {
            
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE from IMAGENES where IdArticulo=@IdImagen");
                datos.setearParametro("@IdImagen", id);
                datos.ejecutarAccion();
         
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

        public void EliminarImagenesArticulo(int id)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE from IMAGENES where IdArticulo=@IdArticuloImagen");
                datos.setearParametro("@IdArticuloImagen", id);
                datos.ejecutarAccion();

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

        public bool ModificarImagenporUrl(string urlImagenNueva,string urlImagenvieja,string idArticulo)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE IMAGENES SET ImagenUrl=@urlImagenNueva WHERE ImagenUrl = @urlImagenAnterior AND IdArticulo = @idArticulo");
                datos.setearParametro("@urlImagenNueva", urlImagenNueva);
                datos.setearParametro("@urlImagenAnterior",urlImagenvieja);
                datos.setearParametro("@idArticulo", idArticulo);
                int filasafectadas=datos.ejecutarAccion2();

                if (filasafectadas > 0)
                {
                    return true;
                }
                else 
                {
                    return false;
                }

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
