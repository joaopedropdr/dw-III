using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Data
{
    public class FakeContext:DbContext 
    {
        public DbSet<UsuarioLog> UsuarioLogs { get; set; }
        public DbSet<ContaBancariaLog> ContaBancariaLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BancoTemp");
        }
    }
}
