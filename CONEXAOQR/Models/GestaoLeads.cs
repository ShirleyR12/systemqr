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
    
    public partial class GestaoLeads
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GestaoLeads()
        {
            this.GestaoLeadsAtividades = new HashSet<GestaoLeadsAtividades>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> dtEntrada { get; set; }
        public string nome { get; set; }
        public Nullable<long> qtdContato { get; set; }
        public string dtPrimeiraVisita { get; set; }
        public Nullable<long> tempoEntrada { get; set; }
        public Nullable<bool> bandB { get; set; }
        public Nullable<bool> bandA { get; set; }
        public Nullable<bool> bandN { get; set; }
        public Nullable<bool> bandD { get; set; }
        public Nullable<bool> etapaLEAD { get; set; }
        public Nullable<bool> etapaATENDIMENTO { get; set; }
        public Nullable<bool> etapaAGENDAMENTO { get; set; }
        public Nullable<bool> etapaVISITA { get; set; }
        public Nullable<bool> etapaPROPOSTA { get; set; }
        public Nullable<bool> etapaVENDA { get; set; }
        public string observacao { get; set; }
        public Nullable<System.DateTime> dtCadastro { get; set; }
        public Nullable<int> JustContatoId { get; set; }
        public Nullable<int> CanalAtracaoId { get; set; }
        public Nullable<int> CanalComunicacaoId { get; set; }
        public string midiaOrigem { get; set; }
        public Nullable<int> TipoContatoId { get; set; }
        public string sexo { get; set; }
        public string cidade { get; set; }
        public Nullable<int> TipoImoveisId { get; set; }
        public Nullable<int> VisitasId { get; set; }
        public int SituacaoId { get; set; }
        public int EmpresaId { get; set; }
        public Nullable<int> JustAvancoId { get; set; }
        public Nullable<int> FilialId { get; set; }
    
        public virtual CanalAtracao CanalAtracao { get; set; }
        public virtual JustContato JustContato { get; set; }
        public virtual CanalComunicacao CanalComunicacao { get; set; }
        public virtual TipoImoveis TipoImoveis { get; set; }
        public virtual TipoContato TipoContato { get; set; }
        public virtual Empresa Empresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GestaoLeadsAtividades> GestaoLeadsAtividades { get; set; }
        public virtual JustAvanco JustAvanco { get; set; }
        public virtual Filial Filial { get; set; }
    }
}