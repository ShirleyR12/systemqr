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
    
    public partial class TipoImoveis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoImoveis()
        {
            this.GestaoLeads = new HashSet<GestaoLeads>();
        }
    
        public int Id { get; set; }
        public string nome { get; set; }
        public string ativo { get; set; }
        public string sigla { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GestaoLeads> GestaoLeads { get; set; }
    }
}
