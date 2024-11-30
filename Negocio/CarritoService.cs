
using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;


namespace Negocio
{
    public class CarritoService
    {
        public void GuardarEnCarritoArticulo(int idUsuarioEntrante, int idArticuloEntrante, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into Carrito(idUsuario,idProducto,Cantidad) values(@idUsuario,@idArticulo,@Cantidad)");
                datos.setearParametro("@idUsuario", idUsuarioEntrante);
                datos.setearParametro("@idArticulo", idArticuloEntrante);
                datos.setearParametro("@Cantidad", cantidad);
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
        public int TraerIdCarrito(int idUsuarioEntrante, int idArticuloEntrante)
        {
            AccesoDatos datos = new AccesoDatos();
            int Id = 0;
            try
            {
                datos.setearConsulta("SELECT Id from Carrito where idUsuario=@idUsuario And idProducto=@idProducto");
                datos.setearParametro("@idUsuario", idUsuarioEntrante);
                datos.setearParametro("@idProducto", idArticuloEntrante);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {


                    Id = (int)datos.Lector["Id"];


                }
                return Id;
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
        public int BuscarArticuloEnCarrito(int idCarrito)
        {
            AccesoDatos datos = new AccesoDatos();
            int cantidad = 0;
            try
            {
                datos.setearConsulta("SELECT Cantidad from Carrito where id=@idCarrito");
                datos.setearParametro("@idCarrito", idCarrito);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {


                    cantidad = (int)datos.Lector["Cantidad"];


                }
                return cantidad;
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
        
        public void EliminarArticulosEnCarritoPorId(int idProducto,int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DElete Carrito where idProducto=@IdProducto AND IdUsuario=@IdUsuario");
                datos.setearParametro("@IdProducto", idProducto);
                datos.setearParametro("@IdUsuario", IdUsuario);
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
        public void EliminarEnCarritoPorIdCarrito(int idCarrito)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DElete Carrito where id=@IdCarrito");
                datos.setearParametro("@IdCarrito", idCarrito);
               
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
        public List<Carrito> BuscarEnCarritoporIdUsuario(int idUsuarioEntrante)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Dominio.Carrito> listaCarrito = new List<Dominio.Carrito>();
            
            try
            {
                datos.setearConsulta("SELECT id,idUsuario,idProducto,Cantidad from Carrito where idUsuario=@idUsuario");
                datos.setearParametro("@idUsuario", idUsuarioEntrante);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    Carrito carrito = new Carrito();
                    carrito.Id = (int)datos.Lector["id"];
                    carrito.IdUsuario = (int)datos.Lector["idUsuario"];
                    carrito.IdProducto = (int)datos.Lector["idProducto"];
                    carrito.Cantidad = (int)datos.Lector["Cantidad"];
                    listaCarrito.Add(carrito);

                }
                return listaCarrito;
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

        public void CarritoCambiarCantidad(int idCarritoEntrante,int cantidadEntrante)
        {
            AccesoDatos datos = new AccesoDatos();
            

            try
            {
                datos.setearConsulta("UPDATE Carrito SET Cantidad = @Cantidad WHERE id=@id;");
                datos.setearParametro("@Cantidad", cantidadEntrante);
                datos.setearParametro("@id", idCarritoEntrante);
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
        /*
            public void VerificarProductoExistenteEnCarrito(Articulo producto)
            {

                var productoExistente = producto.FirstOrDefault(p => p.Id == producto.Id);

                if (productoExistente != null)
                {

                    productoExistente.Cantidad += producto.Cantidad;
                }
                else
                {

                    Productos.Add(producto);
                }
            }
        */

    }
}


