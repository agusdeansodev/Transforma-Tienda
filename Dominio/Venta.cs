using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int idVenta { get; set; }
        public string numeroVenta { get; set; }        
        public int idUsuario { get; set; }
        public string nombreCliente { get; set; }
        public decimal subTotal { get; set; }
        public decimal Total { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int Id_cliente { get; set; }
        public bool Comprado { get; set; }
        public bool Vendido { get; set; }

    }
}
 