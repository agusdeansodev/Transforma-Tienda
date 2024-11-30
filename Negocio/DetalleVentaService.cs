using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DetalleVentaService
    {
        public void CargarDetalleVenta(DetalleVenta nuevaVenta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO DetalleVenta (idProducto,idVenta, marcaProducto, descripcionProducto, categoriaProducto, cantidad, precio, total) VALUES ( @idProducto, @idVenta,@marcaProducto, @descripcionProducto, @categoriaProducto, @cantidad, @precio, @total);");


                datos.setearParametro("@idProducto", nuevaVenta.idProducto);
                datos.setearParametro("@idVenta", nuevaVenta.idVenta);
                datos.setearParametro("@marcaProducto", nuevaVenta.marcaProducto);
                datos.setearParametro("@descripcionProducto", nuevaVenta.descripcionProducto);
                datos.setearParametro("@categoriaProducto", nuevaVenta.categoriaProducto);
                datos.setearParametro("@cantidad", nuevaVenta.cantidad);
                datos.setearParametro("@precio", nuevaVenta.precio);
                datos.setearParametro("@total", nuevaVenta.total);

                datos.ejecutarLectura();

            }
            catch (Exception ex)
            {

                throw new Exception("Error linea 23" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public DetalleVenta BuscarPorIdVenta(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();
            DetalleVenta detalleVenta = null;

            try
            {
                datos.setearConsulta(@"SELECT 
                                    idDetalleVenta,
                                    idVenta,
                                    idProducto,
                                    marcaProducto,
                                    descripcionProducto,
                                    categoriaProducto,
                                    cantidad,
                                    precio,
                                    total
                                FROM DetalleVenta 
                                WHERE idVenta = @idVenta");
                datos.setearParametro("@idVenta", idVenta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    detalleVenta = new DetalleVenta
                    {
                        idDetalleVenta = (int)datos.Lector["idDetalleVenta"],
                        idVenta = (int)datos.Lector["idVenta"],
                        idProducto = (int)datos.Lector["idProducto"],
                        marcaProducto = datos.Lector["marcaProducto"].ToString(),
                        descripcionProducto = datos.Lector["descripcionProducto"].ToString(),
                        categoriaProducto = datos.Lector["categoriaProducto"].ToString(),
                        cantidad = (int)datos.Lector["cantidad"],
                        precio = (decimal)datos.Lector["precio"],
                        total = (decimal)datos.Lector["total"]
                    };
                }

                return detalleVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el detalle de venta por ID: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
