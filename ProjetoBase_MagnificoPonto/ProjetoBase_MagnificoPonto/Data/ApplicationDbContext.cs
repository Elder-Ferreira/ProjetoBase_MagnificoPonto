using ProjetoBase_MagnificoPonto.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjetoBase_MagnificoPonto.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<FormEntregaModel> FormEntregas { get; set; }
        public DbSet<RelatorioModel> Relatorios { get; set; }
    }
}
