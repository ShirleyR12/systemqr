using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CONEXAOQR.Models
{
    public class ReporteHistorial
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public System.DateTime FechayHora { get; set; }
        public string TipoDeAccion { get; set; }
        public string Accion { get; set; }
      
        public int OcultarUsuario { get; set; }
        public int OcultarFechayHora { get; set; }
        public int OcultarTipoDeAccion { get; set; }
        public int OcultarAccion { get; set; }

    }
}