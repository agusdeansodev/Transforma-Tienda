using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleVenta
    {
        public int idDetalleVenta { get; set; }
        public int idVenta {get;set;}
        public int idProducto {get;set;}
        public string marcaProducto {get;set;}
        public string descripcionProducto {get;set;}
        public string categoriaProducto  {get;set;}
        public int cantidad  {get;set;}
        public decimal precio    {get;set;}
        public decimal total { get; set; }

    }
}
;