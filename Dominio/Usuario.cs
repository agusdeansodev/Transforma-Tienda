using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        Admin = 1,
        usuario = 2
    }
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nombreUsuario { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public int rol { get; set; }
        public string clave { get; set; }
        public bool esActivo {get;set;}
        public DateTime fechaRegistro { get; set; }

        public Usuario(string nombreEntrante, string contraseniaEntrante)
        {

            nombre = nombreEntrante;
            clave = contraseniaEntrante;

        } 
        
        public Usuario() { }
    }
}
