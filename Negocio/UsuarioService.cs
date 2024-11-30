using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dominio;

using Negocio;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Claims;

namespace Negocio
{
    public class UsuarioService
    {    
        //Revisada: Okey
        public int Login(Usuario usuario)
        {
            int rol = 0;
            AccesoDatos datos = new AccesoDatos();          
            try
            {
                datos.setearConsulta("SELECT idRol,esActivo from USUARIOS WHERE nombreUsuario = @nombreUsuario AND clave = @contrasenia AND esActivo=1");
                datos.setearParametro("@nombreUsuario", usuario.nombre);
                datos.setearParametro("@contrasenia", usuario.clave);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                 
                    rol = (int)datos.Lector["idRol"];
                  
                    
                   
                   
                }
                return rol;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                datos.cerrarConexion();
            } 
        }
        //Revisada: Okey
        public int LoginSoloUsuarioYcontrasenia(string usuario,string contrasenia)
        {
            int rol = 0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT idRol from USUARIO WHERE nombreUsuario = @nombreUsuario AND Clave=@contrasenia AND esActivo=1");
                datos.setearParametro("@nombreUsuario", usuario);
                datos.setearParametro("@contrasenia", contrasenia);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    
                    rol = int.Parse(datos.Lector["idRol"].ToString());

                }
                
                return rol;
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
        public Usuario LoginUsuarioYcontraseniaDevuelveUsuario(string usuario, string contrasenia)
        {
            Usuario usuarioObjeto = new Usuario();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT idUsuario,nombre,correo,telefono,idRol,clave,esActivo,apellido,nombreUsuario,fechaRegistro from USUARIO WHERE nombreUsuario = @nombreUsuario AND Clave=@contrasenia AND esActivo=1");
                datos.setearParametro("@nombreUsuario", usuario);
                datos.setearParametro("@contrasenia", contrasenia);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                     
                    
                    
                    usuarioObjeto.idUsuario = int.Parse(datos.Lector["idUsuario"].ToString());
                    usuarioObjeto.nombre = datos.Lector["nombre"].ToString();
                    usuarioObjeto.correo = datos.Lector["correo"].ToString();
                    usuarioObjeto.telefono = datos.Lector["telefono"].ToString();
                    usuarioObjeto.rol = int.Parse(datos.Lector["idRol"].ToString());
                    usuarioObjeto.clave = datos.Lector["clave"].ToString();
                    usuarioObjeto.esActivo = (bool)datos.Lector["esActivo"];
                    usuarioObjeto.apellido = datos.Lector["apellido"].ToString();
                    usuarioObjeto.nombreUsuario = datos.Lector["nombreUsuario"].ToString();
                    usuarioObjeto.fechaRegistro = (DateTime)datos.Lector["fechaRegistro"];

                   

                }

                return usuarioObjeto;
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

        public bool ExisteUsuario(string nuevoNombreUsuario)
        {
           AccesoDatos datos = new AccesoDatos();

           try
            {


            datos.setearConsulta("select EsActivo from USUARIO where nombreUsuario=@nombreUsuario AND esActivo=1");
            datos.setearParametro("@nombreUsuario", nuevoNombreUsuario);
            datos.ejecutarLectura();
            while (datos.Lector.Read())
            {                  
                    
                        return true;
              
            }

                return false;

            }
            catch (Exception ex)
            {

               throw new Exception("Error en Existe Cliente (UsuarioService) Linea 108: " + ex.Message); ;
            }
            finally
            {
                datos.cerrarConexion();
            }
          
        }

        public bool NoExisteUsuario(string email)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.setearConsulta("select correo from USUARIO where correo=@email");
                datos.setearParametro("@email", email);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    return false;

                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error en Existe Cliente (UsuarioService) Linea 108: " + ex.Message); ;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public bool NoExisteUsuarioSinChequearElmismo(string email,int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.setearConsulta("select correo from USUARIO where correo=@email And idUsuario!=@IdUsuario");
                datos.setearParametro("@email", email);
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    return false;

                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Error en Existe Cliente (UsuarioService) Linea 108: " + ex.Message); ;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void RegistrarUsuario (Usuario usuario)
        { 
            AccesoDatos datos = new AccesoDatos ();
            DateTime dateTime = DateTime.Now;

            try
            {
                datos.setearConsulta (@"Insert into USUARIO(nombre,correo,telefono,idRol,clave,esActivo,apellido,nombreUsuario, fechaRegistro) VALUES
                                        (@nombre,@correo, @telefono, @idRol, @clave, @esActivo, @apellido, @nombreUsuario, @fechaRegistro)");

 
                datos.setearParametro("@nombre", usuario.nombre);
                datos.setearParametro("@correo", usuario.correo);
                datos.setearParametro("@telefono", usuario.telefono);
                datos.setearParametro("@idRol", usuario.rol);
                datos.setearParametro("@clave", usuario.clave);
                datos.setearParametro("@esActivo", 1);
                datos.setearParametro("@apellido", usuario.apellido);
                datos.setearParametro("@nombreUsuario", usuario.nombreUsuario);
                datos.setearParametro("@fechaRegistro", dateTime);

      

                datos.ejecutarAccion(); 

            }
            catch (Exception ex)
            {

                throw new Exception("Error al Registrar cliente: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ActualizarPerfil (Usuario usuario,int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            DateTime dateTime = DateTime.Now;

            try
            {
                datos.setearConsulta(@"UPDATE USUARIO set nombre=@nombre,apellido=@ape,correo=@correo,nombreUsuario=@nombreusuario,clave=@clave,
                                      telefono=@telefono,
                                      idRol=@idRol,
                                      esActivo=@esActivo,
                                      fechaRegistro=@fechaRegistro 
                                      where idUsuario=@idUsuario");

                datos.setearParametro("@nombre", usuario.nombre);
                datos.setearParametro("@ape",usuario.apellido);
                datos.setearParametro("@nombreUsuario", usuario.nombreUsuario);
                datos.setearParametro("@correo", usuario.correo);
                datos.setearParametro("@clave", usuario.clave);
                datos.setearParametro("@telefono", usuario.telefono);
                datos.setearParametro("@idRol", usuario.rol);
                datos.setearParametro("@esActivo", 1);
                datos.setearParametro("@fechaRegistro", dateTime);
                datos.setearParametro("@idUsuario", usuario.idUsuario);

                datos.ejecutarAccion();

               
            }
            catch (Exception ex)
            {

                throw new Exception("Error al actualizar sus datos: linea 190 UsuarioService " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Usuario TraerUsuarioPorId(int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            DateTime dateTime = DateTime.Now;

            try
            {
                datos.setearConsulta("SELECT idUsuario,nombre,correo,telefono,idRol,clave,esActivo,apellido,nombreUsuario from USUARIO WHERE idUsuario=@idUsuario");
                datos.setearParametro("@idUsuario", IdUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {   Usuario usuario = new Usuario();
                    
                    
                    
                    usuario.idUsuario = (int)datos.Lector["idUsuario"];
                    usuario.nombre = (string)datos.Lector["nombre"];
                    usuario.correo = (string)datos.Lector["correo"];
                    usuario.telefono = (string)datos.Lector["telefono"];
                    usuario.rol = (int)datos.Lector["idRol"];
                    usuario.clave = (string)datos.Lector["clave"];
                    usuario.esActivo = (bool)datos.Lector["esActivo"];
                    usuario.apellido = (string)datos.Lector["apellido"];
                    usuario.nombreUsuario= (string)datos.Lector["nombreUsuario"];

                   

                    return usuario;


                }
                
                Usuario usuario1 = new Usuario();
                usuario1.idUsuario = 0;
                return usuario1;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al actualizar sus datos: linea 190 UsuarioService " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void CambiarRolUsuarioPorId(int rol,int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("UPDATE Usuario set idRol=@idRol where idUsuario=@idUsuario");
                datos.setearParametro("@idRol", rol);
                datos.setearParametro("@idUsuario", IdUsuario);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw new Exception("Error al actualizar su usuario Rol" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Usuario> listarUsuarios () {
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> listaUsuarios = new List<Usuario>();
            try
            {

                datos.setearConsulta("SELECT idUsuario,nombre,correo,telefono,idRol,clave,esActivo,apellido,nombreUsuario, fechaRegistro from USUARIO where telefono IS NOT NULL");
                datos.ejecutarLectura();

                

                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();

                    

                    usuario.idUsuario = (int)datos.Lector["idUsuario"];

                        usuario.nombre = (string)datos.Lector["nombre"];
                    
                        
                    usuario.correo = (string)datos.Lector["correo"];
                    
                    
                      usuario.telefono = (string)datos.Lector["telefono"];  
                    
                    
                    usuario.rol = (int)datos.Lector["idRol"];
                    usuario.clave = (string)datos.Lector["clave"];
                    usuario.esActivo = (bool)datos.Lector["esActivo"];
                    
                    
                        usuario.apellido = (string)datos.Lector["apellido"];
                    
                    usuario.nombreUsuario = (string)datos.Lector["nombreUsuario"];
                    usuario.fechaRegistro = (DateTime)datos.Lector["fechaRegistro"];


                   
                        listaUsuarios.Add(usuario);
                            




                }
                return listaUsuarios;

            }

            catch (Exception ex)
            {

                throw new Exception("Error" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void EliminarUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"UPDATE USUARIO set esActivo=0 where idUsuario=@idUsuario");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw new Exception("Error" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void DarAltaUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"UPDATE USUARIO set esActivo=1 where idUsuario=@idUsuario");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw new Exception("Error" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void actualizarContrasenia(string contraseniaPin,string nuevaContrasenia,string mailRecuperacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE USUARIO SET clave=@nuevaContrasenia WHERE correo=@emailRecuperacion and clave=@contraseniaPin");
                datos.setearParametro("@nuevaContrasenia",nuevaContrasenia);
                datos.setearParametro("@emailRecuperacion", mailRecuperacion);
                datos.setearParametro("@contraseniaPin",contraseniaPin);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw new Exception("Error Cambiar Contraseña" + ex.Message);
            }

        }

    }
}
