using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechPort.Models;

namespace TechPort.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Conteiner>? Conteiners { get; set; }
        public DbSet<Navio>? Navios { get; set; }
        public DbSet<Viagem>? Viagens { get; set; }
        public DbSet<VidaConteiner>? VidasConteiner { get; set; }
        public DbSet<TechPort.Models.Empresa> Empresa { get; set; }
    }
}