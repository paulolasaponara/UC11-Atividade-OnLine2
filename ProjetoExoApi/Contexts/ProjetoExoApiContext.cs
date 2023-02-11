using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;
using ProjetoExoApi.Models;

namespace ProjetoExoApi.Contexts
{
    public class ProjetoExoApiContext : DbContext
    {
        public ProjetoExoApiContext()
        {
        }
        public ProjetoExoApiContext(DbContextOptions<ProjetoExoApiContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-UNHD8A18\\SQLEXPRESS; initial catalog = ProjetoExoApi;User Id= sa; pwd= 310579; TrustServerCertificate=True");
            }
        }
        public DbSet<ExoApi> ExoApi { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        
    }
}
