﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelContainer : DbContext
    {
        public ModelContainer()
            : base("name=ModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Historial> Historial { get; set; }
        public virtual DbSet<CanalAtracao> CanalAtracaoSet { get; set; }
        public virtual DbSet<Corretor> CorretorSet { get; set; }
        public virtual DbSet<Empresa> EmpresaSet { get; set; }
        public virtual DbSet<JustContato> JustContatoSet { get; set; }
        public virtual DbSet<EtapaFunil> EtapaFunilSet { get; set; }
        public virtual DbSet<CanalComunicacao> CanalComunicacaoSet { get; set; }
        public virtual DbSet<TipoImoveis> TipoImoveisSet { get; set; }
        public virtual DbSet<GestaoLeads> GestaoLeadsSet { get; set; }
        public virtual DbSet<TipoContato> TipoContatoSet { get; set; }
        public virtual DbSet<Filial> FilialSet { get; set; }
        public virtual DbSet<TipoNegocio> TipoNegocioSet { get; set; }
        public virtual DbSet<RedesSociais> RedesSociaisSet { get; set; }
        public virtual DbSet<Atividades> AtividadesSet { get; set; }
        public virtual DbSet<Situacao> SituacaoSet { get; set; }
        public virtual DbSet<TipoAtividade> TipoAtividadeSet { get; set; }
        public virtual DbSet<GestaoLeadsAtividades> GestaoLeadsAtividadesSet { get; set; }
        public virtual DbSet<FaseEtapaFunil> FaseEtapaFunilSet { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<JustAvanco> JustAvancoSet { get; set; }
    }
}