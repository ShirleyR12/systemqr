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
    
    public partial class Usuario
    {
        public int Id { get; set; }
        public bool ativo { get; set; }
        public string tipoPessoa { get; set; }
        public string observacao { get; set; }
        public int EmpresaId { get; set; }
        public int FilialId { get; set; }
        public string imagem { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public System.DateTime dtCriacao { get; set; }
    
        public virtual Empresa Empresa { get; set; }
        public virtual Filial Filial { get; set; }
    }
}
