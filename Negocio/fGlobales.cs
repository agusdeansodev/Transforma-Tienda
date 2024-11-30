using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Negocio
{
    public static class fGlobales
    {
        public static void MostrarAlerta(Page page, string mensaje)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", $"alert('{mensaje}');", true);
        }
        
    }
}
