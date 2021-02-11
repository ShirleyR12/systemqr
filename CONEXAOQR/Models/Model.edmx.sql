
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/10/2021 18:57:37
-- Generated from EDMX file: V:\001 Shirley\QR\versao1\CONEXAOQR\CONEXAOQR\CONEXAOQR\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-CONEXAOQR-20210203105021];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CanalAtracaoGestaoLeads]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GestaoLeadsSet] DROP CONSTRAINT [FK_CanalAtracaoGestaoLeads];
GO
IF OBJECT_ID(N'[dbo].[FK_JustContatoGestaoLeads]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GestaoLeadsSet] DROP CONSTRAINT [FK_JustContatoGestaoLeads];
GO
IF OBJECT_ID(N'[dbo].[FK_CanalComunicacaoGestaoLeads]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GestaoLeadsSet] DROP CONSTRAINT [FK_CanalComunicacaoGestaoLeads];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoImoveisGestaoLeads]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GestaoLeadsSet] DROP CONSTRAINT [FK_TipoImoveisGestaoLeads];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoContatoGestaoLeads]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GestaoLeadsSet] DROP CONSTRAINT [FK_TipoContatoGestaoLeads];
GO
IF OBJECT_ID(N'[dbo].[FK_RedesSociaisEmpresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmpresaSet] DROP CONSTRAINT [FK_RedesSociaisEmpresa];
GO
IF OBJECT_ID(N'[dbo].[FK_RedesSociaisFilial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FilialSet] DROP CONSTRAINT [FK_RedesSociaisFilial];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoAtividadeAtividades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AtividadesSet] DROP CONSTRAINT [FK_TipoAtividadeAtividades];
GO
IF OBJECT_ID(N'[dbo].[FK_AtividadesGestaoLeadsAtividades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GestaoLeadsAtividadesSet] DROP CONSTRAINT [FK_AtividadesGestaoLeadsAtividades];
GO
IF OBJECT_ID(N'[dbo].[FK_SituacaoAtividades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AtividadesSet] DROP CONSTRAINT [FK_SituacaoAtividades];
GO
IF OBJECT_ID(N'[dbo].[FK_EtapaFunilFaseEtapaFunil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaseEtapaFunilSet] DROP CONSTRAINT [FK_EtapaFunilFaseEtapaFunil];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaGestaoLeads]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GestaoLeadsSet] DROP CONSTRAINT [FK_EmpresaGestaoLeads];
GO
IF OBJECT_ID(N'[dbo].[FK_GestaoLeadsGestaoLeadsAtividades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GestaoLeadsAtividadesSet] DROP CONSTRAINT [FK_GestaoLeadsGestaoLeadsAtividades];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaFilial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FilialSet] DROP CONSTRAINT [FK_EmpresaFilial];
GO
IF OBJECT_ID(N'[dbo].[FK_CorretorFilial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CorretorSet] DROP CONSTRAINT [FK_CorretorFilial];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoNegocioEmpresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmpresaSet] DROP CONSTRAINT [FK_TipoNegocioEmpresa];
GO
IF OBJECT_ID(N'[dbo].[FK_CorretorEmpresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CorretorSet] DROP CONSTRAINT [FK_CorretorEmpresa];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRoles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_JustAvancoGestaoLeads]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GestaoLeadsSet] DROP CONSTRAINT [FK_JustAvancoGestaoLeads];
GO
IF OBJECT_ID(N'[dbo].[FK_FilialGestaoLeads]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GestaoLeadsSet] DROP CONSTRAINT [FK_FilialGestaoLeads];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Historial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Historial];
GO
IF OBJECT_ID(N'[dbo].[CanalAtracaoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CanalAtracaoSet];
GO
IF OBJECT_ID(N'[dbo].[CorretorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CorretorSet];
GO
IF OBJECT_ID(N'[dbo].[EmpresaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmpresaSet];
GO
IF OBJECT_ID(N'[dbo].[JustContatoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JustContatoSet];
GO
IF OBJECT_ID(N'[dbo].[EtapaFunilSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EtapaFunilSet];
GO
IF OBJECT_ID(N'[dbo].[CanalComunicacaoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CanalComunicacaoSet];
GO
IF OBJECT_ID(N'[dbo].[TipoImoveisSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoImoveisSet];
GO
IF OBJECT_ID(N'[dbo].[GestaoLeadsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GestaoLeadsSet];
GO
IF OBJECT_ID(N'[dbo].[TipoContatoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoContatoSet];
GO
IF OBJECT_ID(N'[dbo].[FilialSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilialSet];
GO
IF OBJECT_ID(N'[dbo].[TipoNegocioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoNegocioSet];
GO
IF OBJECT_ID(N'[dbo].[RedesSociaisSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RedesSociaisSet];
GO
IF OBJECT_ID(N'[dbo].[AtividadesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AtividadesSet];
GO
IF OBJECT_ID(N'[dbo].[SituacaoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SituacaoSet];
GO
IF OBJECT_ID(N'[dbo].[TipoAtividadeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoAtividadeSet];
GO
IF OBJECT_ID(N'[dbo].[GestaoLeadsAtividadesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GestaoLeadsAtividadesSet];
GO
IF OBJECT_ID(N'[dbo].[FaseEtapaFunilSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaseEtapaFunilSet];
GO
IF OBJECT_ID(N'[dbo].[C__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[C__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[JustAvancoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JustAvancoSet];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Historial'
CREATE TABLE [dbo].[Historial] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FechaHora] datetime  NOT NULL,
    [TipoAccion] varchar(max)  NOT NULL,
    [Accion] varchar(max)  NOT NULL,
    [Usuario] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CanalAtracaoSet'
CREATE TABLE [dbo].[CanalAtracaoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CorretorSet'
CREATE TABLE [dbo].[CorretorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL,
    [telefone] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NULL,
    [dtCadastro] datetime  NOT NULL,
    [dtNascimento] datetime  NULL,
    [FilialId] int  NULL,
    [EmpresaId] int  NOT NULL
);
GO

-- Creating table 'EmpresaSet'
CREATE TABLE [dbo].[EmpresaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL,
    [cnpj] nvarchar(max)  NULL,
    [email] nvarchar(max)  NULL,
    [telefone] nvarchar(max)  NULL,
    [endereco] nvarchar(max)  NULL,
    [nomeFantasia] nvarchar(max)  NULL,
    [gerente] nvarchar(max)  NULL,
    [diretor] nvarchar(max)  NULL,
    [mqi] nvarchar(max)  NULL,
    [crm] nvarchar(max)  NULL,
    [site] nvarchar(max)  NULL,
    [RedesSociaisId] int  NULL,
    [TipoNegocioId] int  NOT NULL
);
GO

-- Creating table 'JustContatoSet'
CREATE TABLE [dbo].[JustContatoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL,
    [ativo] nvarchar(max)  NOT NULL,
    [descricao] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EtapaFunilSet'
CREATE TABLE [dbo].[EtapaFunilSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL,
    [porcentagem] nvarchar(max)  NOT NULL,
    [cor] nvarchar(max)  NULL
);
GO

-- Creating table 'CanalComunicacaoSet'
CREATE TABLE [dbo].[CanalComunicacaoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TipoImoveisSet'
CREATE TABLE [dbo].[TipoImoveisSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL,
    [ativo] nvarchar(max)  NULL,
    [sigla] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GestaoLeadsSet'
CREATE TABLE [dbo].[GestaoLeadsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [dtEntrada] datetime  NULL,
    [nome] nvarchar(max)  NULL,
    [qtdContato] bigint  NULL,
    [dtPrimeiraVisita] nvarchar(max)  NULL,
    [tempoEntrada] bigint  NULL,
    [bandB] bit  NULL,
    [bandA] bit  NULL,
    [bandN] bit  NULL,
    [bandD] bit  NULL,
    [etapaLEAD] bit  NULL,
    [etapaATENDIMENTO] bit  NULL,
    [etapaAGENDAMENTO] bit  NULL,
    [etapaVISITA] bit  NULL,
    [etapaPROPOSTA] bit  NULL,
    [etapaVENDA] bit  NULL,
    [observacao] nvarchar(max)  NULL,
    [dtCadastro] datetime  NULL,
    [JustContatoId] int  NULL,
    [CanalAtracaoId] int  NULL,
    [CanalComunicacaoId] int  NULL,
    [midiaOrigem] nvarchar(max)  NULL,
    [TipoContatoId] int  NULL,
    [sexo] nvarchar(max)  NULL,
    [cidade] nvarchar(max)  NULL,
    [TipoImoveisId] int  NULL,
    [VisitasId] int  NULL,
    [SituacaoId] int  NOT NULL,
    [EmpresaId] int  NOT NULL,
    [JustAvancoId] int  NULL,
    [FilialId] int  NULL
);
GO

-- Creating table 'TipoContatoSet'
CREATE TABLE [dbo].[TipoContatoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FilialSet'
CREATE TABLE [dbo].[FilialSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL,
    [gerente] nvarchar(max)  NULL,
    [telefone] nvarchar(max)  NULL,
    [endereco] nvarchar(max)  NULL,
    [email] nvarchar(max)  NULL,
    [mqi] nvarchar(max)  NULL,
    [crm] nvarchar(max)  NULL,
    [site] nvarchar(max)  NULL,
    [RedesSociaisId] int  NULL,
    [EmpresaId] int  NOT NULL
);
GO

-- Creating table 'TipoNegocioSet'
CREATE TABLE [dbo].[TipoNegocioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RedesSociaisSet'
CREATE TABLE [dbo].[RedesSociaisSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NULL,
    [link] nvarchar(max)  NULL
);
GO

-- Creating table 'AtividadesSet'
CREATE TABLE [dbo].[AtividadesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [data] datetime  NULL,
    [observacao] nvarchar(max)  NULL,
    [TipoAtividadeId] int  NOT NULL,
    [SituacaoId] int  NOT NULL
);
GO

-- Creating table 'SituacaoSet'
CREATE TABLE [dbo].[SituacaoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NULL
);
GO

-- Creating table 'TipoAtividadeSet'
CREATE TABLE [dbo].[TipoAtividadeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GestaoLeadsAtividadesSet'
CREATE TABLE [dbo].[GestaoLeadsAtividadesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AtividadesId] int  NOT NULL,
    [GestaoLeadsId] int  NOT NULL
);
GO

-- Creating table 'FaseEtapaFunilSet'
CREATE TABLE [dbo].[FaseEtapaFunilSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL,
    [EtapaFunilId] int  NOT NULL,
    [EtapaFunilId1] int  NOT NULL
);
GO

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'JustAvancoSet'
CREATE TABLE [dbo].[JustAvancoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL,
    [descricao] nvarchar(max)  NULL,
    [ativo] int  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Historial'
ALTER TABLE [dbo].[Historial]
ADD CONSTRAINT [PK_Historial]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CanalAtracaoSet'
ALTER TABLE [dbo].[CanalAtracaoSet]
ADD CONSTRAINT [PK_CanalAtracaoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CorretorSet'
ALTER TABLE [dbo].[CorretorSet]
ADD CONSTRAINT [PK_CorretorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmpresaSet'
ALTER TABLE [dbo].[EmpresaSet]
ADD CONSTRAINT [PK_EmpresaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JustContatoSet'
ALTER TABLE [dbo].[JustContatoSet]
ADD CONSTRAINT [PK_JustContatoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EtapaFunilSet'
ALTER TABLE [dbo].[EtapaFunilSet]
ADD CONSTRAINT [PK_EtapaFunilSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CanalComunicacaoSet'
ALTER TABLE [dbo].[CanalComunicacaoSet]
ADD CONSTRAINT [PK_CanalComunicacaoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoImoveisSet'
ALTER TABLE [dbo].[TipoImoveisSet]
ADD CONSTRAINT [PK_TipoImoveisSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GestaoLeadsSet'
ALTER TABLE [dbo].[GestaoLeadsSet]
ADD CONSTRAINT [PK_GestaoLeadsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoContatoSet'
ALTER TABLE [dbo].[TipoContatoSet]
ADD CONSTRAINT [PK_TipoContatoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FilialSet'
ALTER TABLE [dbo].[FilialSet]
ADD CONSTRAINT [PK_FilialSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoNegocioSet'
ALTER TABLE [dbo].[TipoNegocioSet]
ADD CONSTRAINT [PK_TipoNegocioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RedesSociaisSet'
ALTER TABLE [dbo].[RedesSociaisSet]
ADD CONSTRAINT [PK_RedesSociaisSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AtividadesSet'
ALTER TABLE [dbo].[AtividadesSet]
ADD CONSTRAINT [PK_AtividadesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SituacaoSet'
ALTER TABLE [dbo].[SituacaoSet]
ADD CONSTRAINT [PK_SituacaoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoAtividadeSet'
ALTER TABLE [dbo].[TipoAtividadeSet]
ADD CONSTRAINT [PK_TipoAtividadeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GestaoLeadsAtividadesSet'
ALTER TABLE [dbo].[GestaoLeadsAtividadesSet]
ADD CONSTRAINT [PK_GestaoLeadsAtividadesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FaseEtapaFunilSet'
ALTER TABLE [dbo].[FaseEtapaFunilSet]
ADD CONSTRAINT [PK_FaseEtapaFunilSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JustAvancoSet'
ALTER TABLE [dbo].[JustAvancoSet]
ADD CONSTRAINT [PK_JustAvancoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CanalAtracaoId] in table 'GestaoLeadsSet'
ALTER TABLE [dbo].[GestaoLeadsSet]
ADD CONSTRAINT [FK_CanalAtracaoGestaoLeads]
    FOREIGN KEY ([CanalAtracaoId])
    REFERENCES [dbo].[CanalAtracaoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CanalAtracaoGestaoLeads'
CREATE INDEX [IX_FK_CanalAtracaoGestaoLeads]
ON [dbo].[GestaoLeadsSet]
    ([CanalAtracaoId]);
GO

-- Creating foreign key on [JustContatoId] in table 'GestaoLeadsSet'
ALTER TABLE [dbo].[GestaoLeadsSet]
ADD CONSTRAINT [FK_JustContatoGestaoLeads]
    FOREIGN KEY ([JustContatoId])
    REFERENCES [dbo].[JustContatoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JustContatoGestaoLeads'
CREATE INDEX [IX_FK_JustContatoGestaoLeads]
ON [dbo].[GestaoLeadsSet]
    ([JustContatoId]);
GO

-- Creating foreign key on [CanalComunicacaoId] in table 'GestaoLeadsSet'
ALTER TABLE [dbo].[GestaoLeadsSet]
ADD CONSTRAINT [FK_CanalComunicacaoGestaoLeads]
    FOREIGN KEY ([CanalComunicacaoId])
    REFERENCES [dbo].[CanalComunicacaoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CanalComunicacaoGestaoLeads'
CREATE INDEX [IX_FK_CanalComunicacaoGestaoLeads]
ON [dbo].[GestaoLeadsSet]
    ([CanalComunicacaoId]);
GO

-- Creating foreign key on [TipoImoveisId] in table 'GestaoLeadsSet'
ALTER TABLE [dbo].[GestaoLeadsSet]
ADD CONSTRAINT [FK_TipoImoveisGestaoLeads]
    FOREIGN KEY ([TipoImoveisId])
    REFERENCES [dbo].[TipoImoveisSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoImoveisGestaoLeads'
CREATE INDEX [IX_FK_TipoImoveisGestaoLeads]
ON [dbo].[GestaoLeadsSet]
    ([TipoImoveisId]);
GO

-- Creating foreign key on [TipoContatoId] in table 'GestaoLeadsSet'
ALTER TABLE [dbo].[GestaoLeadsSet]
ADD CONSTRAINT [FK_TipoContatoGestaoLeads]
    FOREIGN KEY ([TipoContatoId])
    REFERENCES [dbo].[TipoContatoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoContatoGestaoLeads'
CREATE INDEX [IX_FK_TipoContatoGestaoLeads]
ON [dbo].[GestaoLeadsSet]
    ([TipoContatoId]);
GO

-- Creating foreign key on [RedesSociaisId] in table 'EmpresaSet'
ALTER TABLE [dbo].[EmpresaSet]
ADD CONSTRAINT [FK_RedesSociaisEmpresa]
    FOREIGN KEY ([RedesSociaisId])
    REFERENCES [dbo].[RedesSociaisSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RedesSociaisEmpresa'
CREATE INDEX [IX_FK_RedesSociaisEmpresa]
ON [dbo].[EmpresaSet]
    ([RedesSociaisId]);
GO

-- Creating foreign key on [RedesSociaisId] in table 'FilialSet'
ALTER TABLE [dbo].[FilialSet]
ADD CONSTRAINT [FK_RedesSociaisFilial]
    FOREIGN KEY ([RedesSociaisId])
    REFERENCES [dbo].[RedesSociaisSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RedesSociaisFilial'
CREATE INDEX [IX_FK_RedesSociaisFilial]
ON [dbo].[FilialSet]
    ([RedesSociaisId]);
GO

-- Creating foreign key on [TipoAtividadeId] in table 'AtividadesSet'
ALTER TABLE [dbo].[AtividadesSet]
ADD CONSTRAINT [FK_TipoAtividadeAtividades]
    FOREIGN KEY ([TipoAtividadeId])
    REFERENCES [dbo].[TipoAtividadeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoAtividadeAtividades'
CREATE INDEX [IX_FK_TipoAtividadeAtividades]
ON [dbo].[AtividadesSet]
    ([TipoAtividadeId]);
GO

-- Creating foreign key on [AtividadesId] in table 'GestaoLeadsAtividadesSet'
ALTER TABLE [dbo].[GestaoLeadsAtividadesSet]
ADD CONSTRAINT [FK_AtividadesGestaoLeadsAtividades]
    FOREIGN KEY ([AtividadesId])
    REFERENCES [dbo].[AtividadesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AtividadesGestaoLeadsAtividades'
CREATE INDEX [IX_FK_AtividadesGestaoLeadsAtividades]
ON [dbo].[GestaoLeadsAtividadesSet]
    ([AtividadesId]);
GO

-- Creating foreign key on [SituacaoId] in table 'AtividadesSet'
ALTER TABLE [dbo].[AtividadesSet]
ADD CONSTRAINT [FK_SituacaoAtividades]
    FOREIGN KEY ([SituacaoId])
    REFERENCES [dbo].[SituacaoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SituacaoAtividades'
CREATE INDEX [IX_FK_SituacaoAtividades]
ON [dbo].[AtividadesSet]
    ([SituacaoId]);
GO

-- Creating foreign key on [EtapaFunilId1] in table 'FaseEtapaFunilSet'
ALTER TABLE [dbo].[FaseEtapaFunilSet]
ADD CONSTRAINT [FK_EtapaFunilFaseEtapaFunil]
    FOREIGN KEY ([EtapaFunilId1])
    REFERENCES [dbo].[EtapaFunilSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EtapaFunilFaseEtapaFunil'
CREATE INDEX [IX_FK_EtapaFunilFaseEtapaFunil]
ON [dbo].[FaseEtapaFunilSet]
    ([EtapaFunilId1]);
GO

-- Creating foreign key on [EmpresaId] in table 'GestaoLeadsSet'
ALTER TABLE [dbo].[GestaoLeadsSet]
ADD CONSTRAINT [FK_EmpresaGestaoLeads]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[EmpresaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaGestaoLeads'
CREATE INDEX [IX_FK_EmpresaGestaoLeads]
ON [dbo].[GestaoLeadsSet]
    ([EmpresaId]);
GO

-- Creating foreign key on [GestaoLeadsId] in table 'GestaoLeadsAtividadesSet'
ALTER TABLE [dbo].[GestaoLeadsAtividadesSet]
ADD CONSTRAINT [FK_GestaoLeadsGestaoLeadsAtividades]
    FOREIGN KEY ([GestaoLeadsId])
    REFERENCES [dbo].[GestaoLeadsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GestaoLeadsGestaoLeadsAtividades'
CREATE INDEX [IX_FK_GestaoLeadsGestaoLeadsAtividades]
ON [dbo].[GestaoLeadsAtividadesSet]
    ([GestaoLeadsId]);
GO

-- Creating foreign key on [EmpresaId] in table 'FilialSet'
ALTER TABLE [dbo].[FilialSet]
ADD CONSTRAINT [FK_EmpresaFilial]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[EmpresaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaFilial'
CREATE INDEX [IX_FK_EmpresaFilial]
ON [dbo].[FilialSet]
    ([EmpresaId]);
GO

-- Creating foreign key on [FilialId] in table 'CorretorSet'
ALTER TABLE [dbo].[CorretorSet]
ADD CONSTRAINT [FK_CorretorFilial]
    FOREIGN KEY ([FilialId])
    REFERENCES [dbo].[FilialSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CorretorFilial'
CREATE INDEX [IX_FK_CorretorFilial]
ON [dbo].[CorretorSet]
    ([FilialId]);
GO

-- Creating foreign key on [TipoNegocioId] in table 'EmpresaSet'
ALTER TABLE [dbo].[EmpresaSet]
ADD CONSTRAINT [FK_TipoNegocioEmpresa]
    FOREIGN KEY ([TipoNegocioId])
    REFERENCES [dbo].[TipoNegocioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoNegocioEmpresa'
CREATE INDEX [IX_FK_TipoNegocioEmpresa]
ON [dbo].[EmpresaSet]
    ([TipoNegocioId]);
GO

-- Creating foreign key on [EmpresaId] in table 'CorretorSet'
ALTER TABLE [dbo].[CorretorSet]
ADD CONSTRAINT [FK_CorretorEmpresa]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[EmpresaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CorretorEmpresa'
CREATE INDEX [IX_FK_CorretorEmpresa]
ON [dbo].[CorretorSet]
    ([EmpresaId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [JustAvancoId] in table 'GestaoLeadsSet'
ALTER TABLE [dbo].[GestaoLeadsSet]
ADD CONSTRAINT [FK_JustAvancoGestaoLeads]
    FOREIGN KEY ([JustAvancoId])
    REFERENCES [dbo].[JustAvancoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JustAvancoGestaoLeads'
CREATE INDEX [IX_FK_JustAvancoGestaoLeads]
ON [dbo].[GestaoLeadsSet]
    ([JustAvancoId]);
GO

-- Creating foreign key on [FilialId] in table 'GestaoLeadsSet'
ALTER TABLE [dbo].[GestaoLeadsSet]
ADD CONSTRAINT [FK_FilialGestaoLeads]
    FOREIGN KEY ([FilialId])
    REFERENCES [dbo].[FilialSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilialGestaoLeads'
CREATE INDEX [IX_FK_FilialGestaoLeads]
ON [dbo].[GestaoLeadsSet]
    ([FilialId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------