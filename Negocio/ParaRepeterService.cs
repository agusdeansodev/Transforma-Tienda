using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ParaRepeterService
    {

        public List<ParaRepeter> BusquedaAvanzadaComprados(int idUsuario,string nombre, decimal? precio, string categoria, string marca)
        {   
            List<ParaRepeter> ListaFiltrada = new List<ParaRepeter>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query="";
                if (!string.IsNullOrEmpty(nombre))
                {
                    query += " AND a.Nombre LIKE @Nombre"; // Búsqueda parcial
                    
                    
                }

                if (precio.HasValue)
                {
                    query += " AND a.Precio >= @Precio";
                    
                }

                if (!string.IsNullOrEmpty(categoria))
                {
                    query += " AND  DV.categoriaProducto LIKE @Categoria";
                    
                }

                if (!string.IsNullOrEmpty(marca))
                {
                    query += " AND  DV.marcaProducto LIKE @Marca";
                    
                }


                datos.setearConsulta(@"SELECT
                                                 v.idventa,
    a.Nombre,
    a.precio,
    DV.cantidad,
    DV.marcaProducto,
    DV.categoriaProducto,
    v.total,
    a.stock,
    u.telefono AS ClienteTelefono,
    u.correo AS ClienteCorreo,
    (SELECT uV.telefono 
     FROM Usuario uV 
     WHERE uV.idUsuario = v.IdUsuario) AS VendedorTelefono,
    (SELECT uV.correo 
     FROM Usuario uV 
     WHERE uV.idUsuario = v.IdUsuario) AS VendedorCorreo
FROM
    venta v
INNER JOIN
    DetalleVenta DV ON DV.idVenta = v.idVenta
INNER JOIN
    Usuario u ON v.Id_cliente = u.idUsuario
INNER JOIN
    ARTICULOS a ON DV.idProducto = a.Id
WHERE
    u.idUsuario = @idUsuario And v.comprado=1 And v.vendido=1" + query);
                datos.setearParametro("@idUsuario", idUsuario);
                if (!string.IsNullOrEmpty(nombre))
                {
                    // Búsqueda parcial
                    datos.setearParametro("@Nombre", "%"+nombre+"%");

                }

                if (precio.HasValue)
                {
                    
                    datos.setearParametro("@Precio", precio);
                }

                if (!string.IsNullOrEmpty(categoria))
                {
                    
                    datos.setearParametro("@Categoria", "%"+categoria+"%");
                }

                if (!string.IsNullOrEmpty(marca))
                {
                    
                    datos.setearParametro("@Marca", "%"+marca+"%");
                }
                datos.ejecutarLectura();
                // Construir la consulta dinámica



                while (datos.Lector.Read())
                {
                    ParaRepeter paraRepeterobj = new ParaRepeter();
                    paraRepeterobj.producto = (string)datos.Lector["Nombre"];
                    paraRepeterobj.precio = Convert.ToDecimal(datos.Lector["precio"]);
                    paraRepeterobj.cantidad = Convert.ToInt32(datos.Lector["cantidad"]);
                    paraRepeterobj.marca = (string)datos.Lector["marcaProducto"];
                    paraRepeterobj.categoria = (string)datos.Lector["categoriaProducto"];
                    paraRepeterobj.Total = Convert.ToDecimal(datos.Lector["total"]);
                    paraRepeterobj.Stock = Convert.ToInt32(datos.Lector["stock"]);
                    paraRepeterobj.telefono = (string)datos.Lector["ClienteTelefono"];
                    paraRepeterobj.correo = (string)datos.Lector["ClienteCorreo"];

                    ListaFiltrada.Add(paraRepeterobj);
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
        public List<ParaRepeter> BusquedaAvanzadaVendidos(int idUsuario, string nombre, decimal? precio, string categoria, string marca)
        {
            List<ParaRepeter> ListaFiltrada = new List<ParaRepeter>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "";
                if (!string.IsNullOrEmpty(nombre))
                {
                    query += " AND a.Nombre LIKE @Nombre"; // Búsqueda parcial


                }

                if (precio.HasValue)
                {
                    query += " AND a.Precio >= @Precio";

                }

                if (!string.IsNullOrEmpty(categoria))
                {
                    query += " AND  DV.categoriaProducto LIKE @Categoria";

                }

                if (!string.IsNullOrEmpty(marca))
                {
                    query += " AND  DV.marcaProducto LIKE @Marca";

                }


                datos.setearConsulta(@"SELECT
                                                 v.idventa,
    a.Nombre,
    a.precio,
    DV.cantidad,
    DV.marcaProducto,
    DV.categoriaProducto,
    v.total,
    a.stock,
    u.telefono AS ClienteTelefono,
    u.correo AS ClienteCorreo,
    (SELECT uV.telefono 
     FROM Usuario uV 
     WHERE uV.idUsuario = v.Id_cliente) AS VendedorTelefono,
    (SELECT uV.correo 
     FROM Usuario uV 
     WHERE uV.idUsuario = v.Id_cliente) AS VendedorCorreo
FROM
    venta v
INNER JOIN
    DetalleVenta DV ON DV.idVenta = v.idVenta
INNER JOIN
    Usuario u ON v.IdUsuario = u.idUsuario
INNER JOIN
    ARTICULOS a ON DV.idProducto = a.Id
WHERE
    u.idUsuario = @idUsuario And v.comprado=1 And v.vendido=1 " + query);
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
                    ParaRepeter paraRepeterobj = new ParaRepeter();
                    paraRepeterobj.producto = (string)datos.Lector["Nombre"];
                    paraRepeterobj.precio = Convert.ToDecimal(datos.Lector["precio"]);
                    paraRepeterobj.cantidad = Convert.ToInt32(datos.Lector["cantidad"]);
                    paraRepeterobj.marca = (string)datos.Lector["marcaProducto"];
                    paraRepeterobj.categoria = (string)datos.Lector["categoriaProducto"];
                    paraRepeterobj.Total = Convert.ToDecimal(datos.Lector["total"]);
                    paraRepeterobj.Stock = Convert.ToInt32(datos.Lector["stock"]);
                    paraRepeterobj.telefono = (string)datos.Lector["ClienteTelefono"];
                    paraRepeterobj.correo = (string)datos.Lector["ClienteCorreo"];

                    ListaFiltrada.Add(paraRepeterobj);
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
