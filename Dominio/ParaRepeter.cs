using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ParaRepeter
    {   
        public int idVenta {  get; set; }
        public string producto {  get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public string marca { get; set; }
        public string categoria { get; set; }
        public decimal Total { get; set; }
        public int Stock { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public bool EnCamino { get; set; }

    }
}
