using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CarritoSubMenu
    {

        public int IdCarrito { get; set; }
        [DisplayName("Id Carrito")]
        public int IdProducto { get; set; }
        [DisplayName("IdProducto")]
        public decimal Precio { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripcíon")]
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
