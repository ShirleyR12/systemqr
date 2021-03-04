using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CONEXAOQR.Models
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adicionar declarações de usuário personalizado aqui
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<CONEXAOQR.Models.JustAvanco> JustAvancoes { get; set; }

        public System.Data.Entity.DbSet<CONEXAOQR.Models.GestaoLeads> GestaoLeads { get; set; }

        public System.Data.Entity.DbSet<CONEXAOQR.Models.CanalAtracao> CanalAtracaos { get; set; }

        public System.Data.Entity.DbSet<CONEXAOQR.Models.CanalComunicacao> CanalComunicacaos { get; set; }

        public System.Data.Entity.DbSet<CONEXAOQR.Models.Empresa> Empresas { get; set; }

        public System.Data.Entity.DbSet<CONEXAOQR.Models.JustContato> JustContatoes { get; set; }

        public System.Data.Entity.DbSet<CONEXAOQR.Models.TipoContato> TipoContatoes { get; set; }

        public System.Data.Entity.DbSet<CONEXAOQR.Models.TipoImoveis> TipoImoveis { get; set; }
    }
}