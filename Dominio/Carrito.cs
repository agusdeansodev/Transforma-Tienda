using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dominio
{
    public class Carrito 
    { public int Id { get; set; } 
        [DisplayName("Id Carrito")] 
        public int IdProducto { get; set; } 
        [DisplayName("Id Producto")]
        public int IdUsuario { get; set; }
        [DisplayName("Id Usuario")]

        public int Cantidad { get; set; }
    }
}