//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CONEXAOQR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Historial
    {
        public int Id { get; set; }
        public System.DateTime FechaHora { get; set; }
        public string TipoAccion { get; set; }
        public string Accion { get; set; }
        public string Usuario { get; set; }
    }
}