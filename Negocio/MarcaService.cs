using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaService
    {
        public List<Marca> getMarcas()
        {
            List<Marca> ListaMarcas = new List<Marca>();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Descripcion from MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);
                    ListaMarcas.Add(marca);
                }

                return ListaMarcas;
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
        public int BuscarMarca(string Descripcion)
        {
            AccesoDatos datos = new AccesoDatos();
            int marcaId =0;
            try
            {
                datos.setearConsulta("SELECT Id,Descripcion from MARCAS where Descripcion=@Descripcion");
                datos.setearParametro("@Descripcion", Descripcion);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    marcaId = int.Parse(datos.Lector["Id"].ToString());
                    return marcaId;

                }

                return 0;
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

        public void AgregarMarcaNueva(string Descripcion)
        {
            AccesoDatos datos = new AccesoDatos();
            Marca Marca = new Marca();
            try
            {
                datos.setearConsulta("Insert into Marcas (Descripcion) VALUES(@Descripcion)");
                datos.setearParametro("@Descripcion", Descripcion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar nueva marca: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void ModificarMarca(string Descripcion)
        {
            AccesoDatos datos = new AccesoDatos();
            Marca marca = new Marca();
            try
            {
                datos.setearConsulta("UPDATE Marcas SET Descripcion=@Descripcion where Descripcion=@Descripcion");
                datos.setearParametro("@Descripcion", Descripcion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar marca: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
