using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class VentaService
    {
        public void CargarVenta(Venta nuevaVenta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO venta (idUsuario, nombreCliente, subTotal,Total, fechaRegistro, Id_cliente) VALUES (@idUsuario, @nombreCliente, @subTotal, @Total, @fechaRegistro, @Id_cliente);");
                
                datos.setearParametro("@idUsuario", nuevaVenta.idUsuario);             
                datos.setearParametro("@nombreCliente", nuevaVenta.nombreCliente);
                datos.setearParametro("@subTotal", nuevaVenta.subTotal);
                datos.setearParametro("@Total", nuevaVenta.Total);
                datos.setearParametro("@fechaRegistro", nuevaVenta.fechaRegistro);
                datos.setearParametro("@Id_cliente", nuevaVenta.Id_cliente);

                datos.ejecutarAccion();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar una nueva venta:" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Venta> buscarComprado(int idCliente)
        {
            List<Venta> ListaDeCompras = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT idVenta,idUsuario, nombreCliente, subTotal,Total, fechaRegistro, Id_cliente,comprado,vendido FROM Venta WHERE id_cliente=@idCliente");
                datos.setearParametro("@idCliente",idCliente);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta venta = new Venta();
                    venta.idVenta = (int)datos.Lector["idVenta"];
                    venta.idUsuario = (int)datos.Lector["idUsuario"];
                    venta.nombreCliente = (string)datos.Lector["nombreCliente"];
                    venta.subTotal = (decimal)datos.Lector["subTotal"];
                    venta.Total = (decimal)datos.Lector["Total"];
                    venta.fechaRegistro = (DateTime)datos.Lector["fechaRegistro"];
                    venta.Id_cliente = (int)datos.Lector["Id_cliente"];
                    venta.Comprado = (bool)datos.Lector["comprado"];
                    venta.Vendido = (bool)datos.Lector["vendido"];

                    if(venta.Comprado==true && venta.Vendido == true)
                    {
                        ListaDeCompras.Add(venta);
                    }
                }
                return ListaDeCompras;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void MarcarComoVendido(int idVentaEntrante)
        {
            
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update Venta set vendido=1 where idVenta=@idVenta");
                datos.setearParametro("@idVenta", idVentaEntrante);
                datos.ejecutarAccion();
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void MarcarComoComprado(int idVentaEntrante)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update Venta set comprado=1 where idVenta=@idVenta");
                datos.setearParametro("@idVenta", idVentaEntrante);
                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<Venta> buscarVendido(int idUsuario)
        {
            List<Venta> ListaDeVentas = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT idVenta,idUsuario, nombreCliente, subTotal,Total, fechaRegistro, Id_cliente,comprado,vendido FROM Venta WHERE idUsuario=@idUsuario");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta venta = new Venta();
                    venta.idVenta = (int)datos.Lector["idVenta"];
                    venta.idUsuario = (int)datos.Lector["idUsuario"];
                    venta.nombreCliente = (string)datos.Lector["nombreCliente"];
                    venta.subTotal = (decimal)datos.Lector["subTotal"];
                    venta.Total = (decimal)datos.Lector["Total"];
                    venta.fechaRegistro = (DateTime)datos.Lector["fechaRegistro"];
                    venta.Id_cliente = (int)datos.Lector["Id_cliente"];
                    venta.Comprado = (bool)datos.Lector["comprado"];
                    venta.Vendido = (bool)datos.Lector["vendido"];

                    if (venta.Comprado == true && venta.Vendido == true)
                    {
                        ListaDeVentas.Add(venta);
                    }
                }
                return ListaDeVentas;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Venta> buscarEnCaminoVentas(int idUsuario)
        {
            List<Venta> ListaDeVentas = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT idVenta,idUsuario, nombreCliente, subTotal,Total, fechaRegistro, Id_cliente,comprado,vendido FROM Venta WHERE idUsuario=@idUsuario");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta venta = new Venta();
                    venta.idVenta = (int)datos.Lector["idVenta"];
                    venta.idUsuario = (int)datos.Lector["idUsuario"];
                    venta.nombreCliente = (string)datos.Lector["nombreCliente"];
                    venta.subTotal = (decimal)datos.Lector["subTotal"];
                    venta.Total = (decimal)datos.Lector["Total"];
                    venta.fechaRegistro = (DateTime)datos.Lector["fechaRegistro"];
                    venta.Id_cliente = (int)datos.Lector["Id_cliente"];
                    venta.Comprado = (bool)datos.Lector["comprado"];
                    venta.Vendido = (bool)datos.Lector["vendido"];

                    if (venta.Comprado == false || venta.Vendido == false)
                    {
                        ListaDeVentas.Add(venta);
                    }
                }
                return ListaDeVentas;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Venta> buscarEnCaminoCompras(int idCliente)
        {
            List<Venta> ListaDeVentas = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT idVenta,idUsuario, nombreCliente, subTotal,Total, fechaRegistro, Id_cliente,comprado,vendido FROM Venta WHERE id_cliente=@idCliente");
                datos.setearParametro("@idCliente", idCliente);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta venta = new Venta();
                    venta.idVenta = (int)datos.Lector["idVenta"];
                    venta.idUsuario = (int)datos.Lector["idUsuario"];
                    venta.nombreCliente = (string)datos.Lector["nombreCliente"];
                    venta.subTotal = (decimal)datos.Lector["subTotal"];
                    venta.Total = (decimal)datos.Lector["Total"];
                    venta.fechaRegistro = (DateTime)datos.Lector["fechaRegistro"];
                    venta.Id_cliente = (int)datos.Lector["Id_cliente"];
                    venta.Comprado = (bool)datos.Lector["comprado"];
                    venta.Vendido = (bool)datos.Lector["vendido"];

                    if (venta.Comprado == false || venta.Vendido == false)
                    {
                        ListaDeVentas.Add(venta);
                    }
                }
                return ListaDeVentas;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int UltimaVenta()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT MAX(idVenta) AS idVenta FROM Venta");
                datos.ejecutarLectura();
                int idVenta=0;
                while (datos.Lector.Read())
                {
                   idVenta = (int)datos.Lector["idVenta"];
                }
                return idVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar una nueva venta:" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
